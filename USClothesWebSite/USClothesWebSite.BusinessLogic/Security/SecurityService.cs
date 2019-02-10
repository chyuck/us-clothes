using System.Linq;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.BusinessLogic.ActionLog;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.BusinessLogic.Notification;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Encrypt;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Security
{
    internal class SecurityService : BaseService, ISecurityService
    {
        #region Constructors

        [Inject]
        public SecurityService(IReadOnlyContainer container)
            : base(container)
        {
        }

        #endregion


        #region ISecurityService

        public void LogIn(DTO.SecurityData securityData)
        {
            CheckHelper.ArgumentNotNull(securityData, "securityData");
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(securityData.Login, "securityData.Login");
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(securityData.Password, "securityData.Password");
            CheckHelper.ArgumentWithinCondition(securityData.Login != DTO.User.GUEST_LOGIN, "To log in as a guest use LogInGuest method.");

            CheckHelper.WithinCondition(!IsLoggedIn, "User is already logged in.");
            
            var persistentService = Container.Get<IPersistentService>();
            var user =
                persistentService
                    .GetEntitySet<User>()
                    .SingleOrDefault(u => u.Login == securityData.Login);
            if (user == null)
                throw new SecurityServiceException("Пользователь с заданным логином и паролем не существует.");
            if (!user.Active)
                throw new SecurityServiceException("Пользователь с заданным логином отключен администратором.");

            var passwordData = Container.Get<IEncryptService>().EncryptPassword(securityData.Password, user.PasswordSalt);
            if (passwordData.PasswordHash != user.PasswordHash)
                throw new SecurityServiceException("Пользователь с заданным логином и паролем не существует.");

            var dtoService = Container.Get<IDtoService>();
            _currentUser = dtoService.CreateUser(user);
        }

        public void LogOut()
        {
            CheckHelper.WithinCondition(IsLoggedIn, "User is not logged in.");

            _currentUser = null;
        }

        public bool IsLoggedIn 
        {
            get { return _currentUser != null; }
        }

        public DTO.User CurrentUser
        {
            get
            {
                if (!IsLoggedIn)
                    return null;

                return (DTO.User)_currentUser.Clone();
            }
        }
        private DTO.User _currentUser;

        public DTO.Role[] CurrentRoles
        {
            get
            {
                if (!IsLoggedIn)
                    return new DTO.Role[] {};
                
                return 
                    _currentUser.Roles
                        .Select(r => (DTO.Role)r.Clone())
                        .ToArray();
            }
        }

        public DTO.Role[] AvailableRoles
        {
            get
            {
                if (!IsLoggedIn)
                    return new DTO.Role[] { }; 

                var roles =
                    CacheHelper.Get(ref _availableRoles,
                        () =>
                        {
                            var persistentService = Container.Get<IPersistentService>();
                            var dtoService = Container.Get<IDtoService>();

                            return
                                persistentService
                                    .GetEntitySet<Role>()
                                    .OrderBy(r => r.Name)
                                    .AsEnumerable()
                                    .Select(r => dtoService.CreateRole(r))
                                    .ToArray();
                        });

                return
                    roles
                        .Select(r => (DTO.Role)r.Clone())
                        .ToArray();
            }
        }
        private DTO.Role[] _availableRoles;

        public bool IsCurrentUserAdministrator 
        {
            get
            {
                if (!IsLoggedIn)
                    return false;

                return 
                    _currentUser.Roles
                        .Any(r => r.Name == DTO.Role.ADMINISTRATOR_ROLE_NAME);
            }
        }
        
        public bool IsCurrentUserPurchaser
        {
            get
            {
                if (!IsLoggedIn)
                    return false;

                return
                    _currentUser.Roles
                        .Any(r => r.Name == DTO.Role.PURCHASER_ROLE_NAME);
            }
        }

        public bool IsCurrentUserDistributor
        {
            get
            {
                if (!IsLoggedIn)
                    return false;

                return
                    _currentUser.Roles
                        .Any(r => r.Name == DTO.Role.DISTRIBUTOR_ROLE_NAME);
            }
        }
        
        public bool IsCurrentUserGuest
        {
            get
            {
                if (!IsLoggedIn)
                    return false;

                return _currentUser.Login == DTO.User.GUEST_LOGIN;
            }
        }

        public bool IsCurrentUserSeller
        {
            get
            {
                if (!IsLoggedIn)
                    return false;

                return
                    _currentUser.Roles
                        .Any(r => r.Name == DTO.Role.SELLER_ROLE_NAME);
            }
        }

        public void LogInGuest()
        {
            CheckHelper.WithinCondition(!IsLoggedIn, "User is already logged in.");

            var persistentService = Container.Get<IPersistentService>();
            var user =
                persistentService
                    .GetEntitySet<User>()
                    .SingleOrDefault(u => u.Login == DTO.User.GUEST_LOGIN);
            CheckHelper.NotNull(user, "Guest user does not exist.");
            CheckHelper.WithinCondition(user.Active, "Guest user is inactive.");

            var dtoService = Container.Get<IDtoService>();
            _currentUser = dtoService.CreateUser(user);
        }

        public void ChangePassword(string newPassword)
        {
            CheckHelper.ArgumentNotNullAndNotEmpty(newPassword, "newPassword");
            CheckHelper.ArgumentWithinCondition(
                StringValidator.ValidatePassword(newPassword), 
                "Password has invalid format.");

            CheckHelper.WithinCondition(IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(_currentUser.Login != DTO.User.GUEST_LOGIN, "Guest cannot change password.");

            var persistentService = Container.Get<IPersistentService>();
            var user = persistentService.GetEntityById<User>(_currentUser.Id);
            CheckHelper.NotNull(user, "Current user does not exist.");
            if (!user.Active)
                throw new SecurityServiceException("Пользователь отключен администратором.");

            var encryptService = Container.Get<IEncryptService>();
            var passwordData = encryptService.EncryptPassword(newPassword);

            user.UpdatePasswordData(passwordData);
            user.UpdateTrackFields(Container);

            persistentService.SaveChanges();

            var actionLogService = Container.Get<IActionLogService>();
            var actionLog =
                new DTO.ActionLog
                {
                    Text = string.Format("{0} сменил пароль.", user.GetDataString()),
                    DocumentId = user.Id,
                    ActionLogType = actionLogService.UserChangedPasswordType
                };
            actionLogService.CreateActionLog(actionLog);
        }

        public void UpdateUser(DTO.User updatedUser)
        {
            CheckHelper.ArgumentNotNull(updatedUser, "updatedUser");
            CheckHelper.ArgumentWithinCondition(!updatedUser.IsNew(), "User is new.");
            CheckHelper.ArgumentNotNull(updatedUser.Roles, "updatedUser.Roles");
            CheckHelper.ArgumentWithinCondition(updatedUser.Roles.All(r => !r.IsNew()), "One of the roles is new.");
            Container.Get<IValidateService>().CheckIsValid(updatedUser);
            CheckHelper.ArgumentWithinCondition(updatedUser.Login != DTO.User.GUEST_LOGIN, "Guest user cannot be updated.");

            CheckHelper.WithinCondition(IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(IsCurrentUserAdministrator, "Only administrator can change user data.");
            
            if (updatedUser.Id == _currentUser.Id)
            {
                if (!updatedUser.Active)
                    throw new SecurityServiceException("Пользователь не может отключить себя.");

                if (updatedUser.Roles.All(r => r.Name != DTO.Role.ADMINISTRATOR_ROLE_NAME))
                    throw new SecurityServiceException("Пользователь не может удалить роль администратора у себя.");
            }
            
            var persistentService = Container.Get<IPersistentService>();
            var user = persistentService.GetEntityById<User>(updatedUser.Id);
            CheckHelper.NotNull(user, "User does not exist.");

            if (user.Login != updatedUser.Login)
            {
                var doesAnotherUserWithTheSameLoginExist =
                    persistentService
                        .GetEntitySet<User>()
                        .Any(u => u.Login == updatedUser.Login);

                if (doesAnotherUserWithTheSameLoginExist)
                    throw new SecurityServiceException("Пользователь с заданным логином уже существует.");
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Login = updatedUser.Login;
            user.Active = updatedUser.Active;
            user.Email = updatedUser.Email;
            user.UpdateTrackFields(Container);

            foreach (var userRole in user.UserRoles)
            {
                // Role needs to be activated
                if (updatedUser.Roles.Any(r => r.Id == userRole.RoleId))
                {
                    // Role is not active
                    if (!userRole.Active)
                    {
                        // Activate role
                        userRole.Active = true;
                        userRole.UpdateTrackFields(Container);
                    }
                }
                // Role needs to be deactivated and it is active
                else if (userRole.Active)
                {
                    // Deactivate role
                    userRole.Active = false;
                    userRole.UpdateTrackFields(Container);
                }
            }

            persistentService.SaveChanges();

            // Refresh current user if it is updated
            if (updatedUser.Id == _currentUser.Id)
            {
                var currentUser = persistentService.GetEntityById<User>(_currentUser.Id);

                var dtoService = Container.Get<IDtoService>();
                _currentUser = dtoService.CreateUser(currentUser);
            }

            updatedUser.ChangeDate = user.ChangeDate;
            updatedUser.ChangeUser = user.ChangedBy.GetFullName();

            var actionLogService = Container.Get<IActionLogService>();
            var actionLog =
                new DTO.ActionLog
                {
                    Text = string.Format("{0} изменен.", user.GetDataString()),
                    DocumentId = user.Id,
                    ActionLogType = actionLogService.UserChangedType
                };
            actionLogService.CreateActionLog(actionLog);
        }
        
        public void CreateUser(DTO.User createdUser)
        {
            CheckHelper.ArgumentNotNull(createdUser, "createdUser");
            CheckHelper.ArgumentWithinCondition(createdUser.IsNew(), "User is not new.");
            CheckHelper.ArgumentNotNull(createdUser.Roles, "createdUser.Roles");
            CheckHelper.ArgumentWithinCondition(createdUser.Roles.All(r => !r.IsNew()), "One of the roles is new.");
            Container.Get<IValidateService>().CheckIsValid(createdUser);

            CheckHelper.WithinCondition(IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(IsCurrentUserAdministrator, "Only administrator can create user.");

            if (!createdUser.Roles.Any())
                throw new SecurityServiceException("Пользователь должен иметь хотя бы одну роль.");
            
            var persistentService = Container.Get<IPersistentService>();

            var doesAnotherUserWithTheSameLoginExist =
                    persistentService
                        .GetEntitySet<User>()
                        .Any(u => u.Login == createdUser.Login);

            if (doesAnotherUserWithTheSameLoginExist)
                throw new SecurityServiceException("Пользователь с заданным логином уже существует.");

            var passwordGeneratorService = Container.Get<IPasswordGeneratorService>();
            var password = passwordGeneratorService.GenerateTemporaryPassword(createdUser.Login);

            var encryptService = Container.Get<IEncryptService>();
            var passwordData = encryptService.EncryptPassword(password);

            var user =
                new User
                {
                    FirstName = createdUser.FirstName,
                    LastName = createdUser.LastName,
                    Login = createdUser.Login,
                    Active = createdUser.Active,
                    Email = createdUser.Email,
                    PasswordHash = passwordData.PasswordHash,
                    PasswordSalt = passwordData.PasswordSalt
                };
            user.UpdateTrackFields(Container);
            persistentService.Add(user);

            var availableRoles = persistentService.GetEntitySet<Role>().ToArray();

            foreach (var availableRole in availableRoles)
            {
                var userRole =
                    new UserRole
                    {
                        Active = createdUser.Roles.Any(r => r.Id == availableRole.Id),
                        Role = availableRole,
                        RoleId = availableRole.Id,
                        User = user,
                        UserId = user.Id
                    };
                userRole.UpdateTrackFields(Container);
                persistentService.Add(userRole);
            }

            persistentService.SaveChanges();

            createdUser.Id = user.Id;
            createdUser.CreateDate = user.CreateDate;
            createdUser.CreateUser = user.CreatedBy.GetFullName();
            createdUser.ChangeDate = user.ChangeDate;
            createdUser.ChangeUser = user.ChangedBy.GetFullName();

            var actionLogService = Container.Get<IActionLogService>();
            var actionLog =
                new DTO.ActionLog
                {
                    Text = string.Format("{0} создан.", user.GetDataString()),
                    DocumentId = user.Id,
                    ActionLogType = actionLogService.UserCreatedType
                };
            actionLogService.CreateActionLog(actionLog);

            Container.Get<INotificationService>().NotifyUserCreated(createdUser, passwordData.Password);
        }

        public DTO.User[] GetUsers(string filter)
        {
            CheckHelper.WithinCondition(IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(
                IsCurrentUserAdministrator || IsCurrentUserPurchaser, 
                "Only administrator and purchaser can get all users.");

            var persistentService = Container.Get<IPersistentService>();

            var query = 
                persistentService
                    .GetEntitySet<User>()
                    .Where(u => u.Login != DTO.User.GUEST_LOGIN);

            if (IsCurrentUserPurchaser && !IsCurrentUserAdministrator)
            {
                const string distributorRoleName = DTO.Role.DISTRIBUTOR_ROLE_NAME;

                query =
                    query
                        .Where(u => 
                            u.UserRoles.Any(ur => ur.Role.Name == distributorRoleName && ur.Active)
                            &&
                            u.Active);
            }

            if (!string.IsNullOrWhiteSpace(filter))
            {
                query =
                    query
                        .Where(u =>
                               u.FirstName.Contains(filter) ||
                               u.LastName.Contains(filter) ||
                               u.Email.Contains(filter) ||
                               u.Login.Contains(filter));
            }

            var dtoService = Container.Get<IDtoService>();

            return
                query
                    .OrderBy(u => u.Id)
                    .ToArray()
                    .Select(u => dtoService.CreateUser(u))
                    .ToArray();
        }

        public void ResetPassword(DTO.User user)
        {
            CheckHelper.ArgumentNotNull(user, "user");
            CheckHelper.ArgumentWithinCondition(!user.IsNew(), "!user.IsNew()");
            Container.Get<IValidateService>().CheckIsValid(user);
            
            CheckHelper.WithinCondition(IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(IsCurrentUserAdministrator, "Only administrator can reset password.");

            var persistentService = Container.Get<IPersistentService>();
            var changedUser = persistentService.GetEntityById<User>(user.Id);
            CheckHelper.NotNull(changedUser, "User does not exist.");
            
            if (!changedUser.Active)
                throw new SecurityServiceException("Пользователь отключен администратором.");

            if (changedUser.Id == _currentUser.Id)
                throw new SecurityServiceException("Пользователь не может сбросить себе пароль.");

            var passwordGeneratorService = Container.Get<IPasswordGeneratorService>();
            var password = passwordGeneratorService.GenerateTemporaryPassword(changedUser.Login);

            var encryptService = Container.Get<IEncryptService>();
            var passwordData = encryptService.EncryptPassword(password);

            changedUser.UpdatePasswordData(passwordData);
            changedUser.UpdateTrackFields(Container);

            persistentService.SaveChanges();

            var actionLogService = Container.Get<IActionLogService>();
            var actionLog =
                new DTO.ActionLog
                {
                    Text = string.Format("Для {0} был сброшен пароль.", changedUser.GetDataString()),
                    DocumentId = changedUser.Id,
                    ActionLogType = actionLogService.PasswordWasResetedForUserType
                };
            actionLogService.CreateActionLog(actionLog);

            Container.Get<INotificationService>().NotifyPasswordReseted(user, passwordData.Password);
        }

        #endregion
    }
}
