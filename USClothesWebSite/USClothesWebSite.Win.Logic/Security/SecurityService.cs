using System.Linq;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Helpers;
using USClothesWebSite.Win.Logic.SecurityAPI;

namespace USClothesWebSite.Win.Logic.Security
{
    internal class SecurityService : BaseService, ISecurityService
    {
        [Inject]
        public SecurityService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        public string Login(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) && string.IsNullOrWhiteSpace(password))
                return @"Не заданы ""Логин"" и ""Пароль""";

            if (string.IsNullOrWhiteSpace(login))
                return @"Не задан ""Логин""";

            if (string.IsNullOrWhiteSpace(password))
                return @"Не задан ""Пароль""";

            var securityData =
                new SecurityData
                {
                    Login = login,
                    Password = password
                };

            var errorMessage = APIClientHelper<SecurityAPIClient>.Call(c => c.LogIn(securityData));

            if (string.IsNullOrEmpty(errorMessage))
            {
                _securityData = securityData;
            }

            return errorMessage;
        }

        public SecurityData SecurityData 
        {
            get
            {
                if (_securityData == null)
                    return null;

                return (SecurityData)_securityData.Clone();
            }
        }
        private SecurityData _securityData;
        
        public User CurrentUser
        {
            get
            {
                if (!IsLoggedIn)
                    return null;

                if (_currentUser == null)
                {
                    _currentUser = APIClientHelper<SecurityAPIClient>.Call(c => c.GetCurrentUser());
                    CheckHelper.NotNull(_currentUser, "_currentUser");
                }

                return (User)_currentUser.Clone();
            }
        }
        private User _currentUser;

        public bool IsLoggedIn
        {
            get { return _securityData != null; }
        }

        public Role[] CurrentRoles
        {
            get
            {
                if (!IsLoggedIn)
                    return new Role[] { };

                return CurrentUser.Roles;
            }
        }
        
        public bool IsCurrentUserAdministrator
        {
            get { return CurrentRoles.Any(r => r.Name == Role.ADMINISTRATOR_ROLE_NAME); }
        }

        public bool IsCurrentUserPurchaser
        {
            get { return CurrentRoles.Any(r => r.Name == Role.PURCHASER_ROLE_NAME); }
        }

        public bool IsCurrentUserDistributor
        {
            get { return CurrentRoles.Any(r => r.Name == Role.DISTRIBUTOR_ROLE_NAME); }
        }

        public bool IsCurrentUserSeller
        {
            get { return CurrentRoles.Any(r => r.Name == Role.SELLER_ROLE_NAME); }
        }
        
        public Role[] AvailableRoles
        {
            get
            {
                if (!IsLoggedIn)
                    return new Role[] { };

                if (_availableRoles == null)
                {
                    _availableRoles = APIClientHelper<SecurityAPIClient>.Call(c => c.GetAvailableRoles());
                    CheckHelper.NotNull(_availableRoles, "_availableRoles");
                }

                return
                    _availableRoles
                        .Select(r => (Role)r.Clone())
                        .ToArray();
            }
        }
        private Role[] _availableRoles;
        
        public string CreateUser(User user)
        {
            CheckHelper.ArgumentNotNull(user, "user");
            CheckHelper.WithinCondition(IsLoggedIn, "IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(user);
            if (errors != null)
                return errors.ToErrorMessage();

            var createdUser = (User) user.Clone();

            var errorMessage = APIClientHelper<SecurityAPIClient>.Call(c => c.CreateUser(ref createdUser));

            user.Id = createdUser.Id;

            return errorMessage;
        }

        public string UpdateUser(User user)
        {
            CheckHelper.ArgumentNotNull(user, "user");
            CheckHelper.WithinCondition(IsLoggedIn, "IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(user);
            if (errors != null)
                return errors.ToErrorMessage();

            var errorMessage = APIClientHelper<SecurityAPIClient>.Call(c => c.UpdateUser(user));

            if (errorMessage == null && _currentUser.Id == user.Id)
            {
                _securityData.Login = user.Login;
                _currentUser = null;
            }

            return errorMessage;
        }
        
        public string ChangePassword(string newPassword, string passwordConfirmation)
        {
            CheckHelper.WithinCondition(IsLoggedIn, "IsLoggedIn");

            if (string.IsNullOrWhiteSpace(newPassword) && string.IsNullOrWhiteSpace(passwordConfirmation))
                return @"Не заданы ""Новый пароль"" и ""Подтверждение пароля""";

            if (string.IsNullOrWhiteSpace(newPassword))
                return @"Не задан ""Новый пароль""";

            if (string.IsNullOrWhiteSpace(passwordConfirmation))
                return @"Не задано ""Подтверждение пароля""";

            if (newPassword != passwordConfirmation)
                return @"""Новый пароль"" и ""Подтверждение пароля"" не совпадают";

            if (!StringValidator.ValidatePassword(newPassword))
                return "Пароль должен иметь длину от 5 до 50 символов.";

            var errorMessage = APIClientHelper<SecurityAPIClient>.Call(c => c.ChangePassword(newPassword));

            if (string.IsNullOrEmpty(errorMessage))
                _securityData.Password = newPassword;

            return errorMessage;
        }
        
        public User[] GetUsers(string filter)
        {
            CheckHelper.WithinCondition(IsLoggedIn, "IsLoggedIn");

            return APIClientHelper<SecurityAPIClient>.Call(c => c.GetUsers(filter));
        }
        
        public string ResetPassword(User user)
        {
            CheckHelper.ArgumentNotNull(user, "user");
            CheckHelper.ArgumentWithinCondition(user.Id > 0, "user.Id > 0");
            CheckHelper.WithinCondition(IsLoggedIn, "IsLoggedIn");

            if (_currentUser.Id == user.Id)
                return "Пользователь не может сбросить себе пароль.";

            return APIClientHelper<SecurityAPIClient>.Call(c => c.ResetPassword(user));
        }
    }
}
