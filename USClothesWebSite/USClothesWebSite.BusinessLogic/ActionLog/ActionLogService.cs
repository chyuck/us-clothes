using System;
using System.Linq;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.ActionLog
{
    internal class ActionLogService : BaseService, IActionLogService
    {
        #region Constants

        public const string USER_CREATED_TYPE_NAME = "Пользователь создан";
        public const string USER_CHANGED_TYPE_NAME = "Пользователь изменен";
        public const string USER_CHANGED_PASSWORD_TYPE_NAME = "Пользователь сменил пароль";
        public const string PASSWORD_WAS_RESETED_FOR_USER_TYPE_NAME = "Пароль был сброшен для пользователя";

        #endregion


        #region Constructors

        [Inject]
        public ActionLogService(IReadOnlyContainer container) 
            : base(container)
        {
        }
        
        #endregion


        #region Methods

        private DTO.ActionLogType GetActionLogTypeByName(string name)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(name, "name");

            var persistentService = Container.Get<IPersistentService>();
            var dtoService = Container.Get<IDtoService>();

            var actionLogType =
                persistentService
                    .GetEntitySet<ActionLogType>()
                    .Single(t => t.Name == name);

            return dtoService.CreateActionLogType(actionLogType);
        }

        #endregion


        #region IActionLogService

        public DTO.ActionLogType UserCreatedType
        {
            get
            {
                if (!Container.Get<ISecurityService>().IsLoggedIn)
                    return null;

                var actionLogType =
                    CacheHelper.Get(ref _userCreatedType, () => GetActionLogTypeByName(USER_CREATED_TYPE_NAME));

                return (DTO.ActionLogType) actionLogType.Clone();
            }
        }
        private DTO.ActionLogType _userCreatedType;

        public DTO.ActionLogType UserChangedType
        {
            get
            {
                if (!Container.Get<ISecurityService>().IsLoggedIn)
                    return null;

                var actionLogType =
                    CacheHelper.Get(ref _userChangedType, () => GetActionLogTypeByName(USER_CHANGED_TYPE_NAME));

                return (DTO.ActionLogType)actionLogType.Clone();
            }
        }
        private DTO.ActionLogType _userChangedType;

        public DTO.ActionLogType UserChangedPasswordType
        {
            get
            {
                if (!Container.Get<ISecurityService>().IsLoggedIn)
                    return null;

                var actionLogType =
                    CacheHelper.Get(ref _userChangedPasswordType, () => GetActionLogTypeByName(USER_CHANGED_PASSWORD_TYPE_NAME));

                return (DTO.ActionLogType)actionLogType.Clone();
            }
        }
        private DTO.ActionLogType _userChangedPasswordType;
        
        public DTO.ActionLogType PasswordWasResetedForUserType
        {
            get
            {
                if (!Container.Get<ISecurityService>().IsLoggedIn)
                    return null;

                var actionLogType =
                    CacheHelper.Get(ref _passwordWasResetedForUserType, () => GetActionLogTypeByName(PASSWORD_WAS_RESETED_FOR_USER_TYPE_NAME));

                return (DTO.ActionLogType)actionLogType.Clone();
            }
        }
        private DTO.ActionLogType _passwordWasResetedForUserType;

        public DTO.ActionLog[] GetActionLogs(DateTime startDate, DateTime endDate, string filter)
        {
            CheckHelper.ArgumentWithinCondition(startDate <= endDate, "startDate <= endDate");

            CheckHelper.WithinCondition(Container.Get<ISecurityService>().IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(Container.Get<ISecurityService>().IsCurrentUserAdministrator, "User is not administrator.");

            var dtoService = Container.Get<IDtoService>();

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.ActionLog>()
                    .Where(al => startDate <= al.CreateDate && al.CreateDate <= endDate);

            if (!string.IsNullOrWhiteSpace(filter))
                query =
                    query
                        .Where(al =>
                               al.Text.Contains(filter) ||
                               al.ActionLogType.Name.Contains(filter));

            return
                query
                    .OrderBy(al => al.CreateDate)
                    .AsEnumerable()
                    .Select(dtoService.CreateActionLog)
                    .ToArray();
        }

        public void CreateActionLog(DTO.ActionLog createdActionLog)
        {
            CheckHelper.ArgumentNotNull(createdActionLog, "createdActionLog");
            CheckHelper.ArgumentWithinCondition(createdActionLog.IsNew(), "Action Log is not new.");

            var securityService = Container.Get<ISecurityService>();
            CheckHelper.WithinCondition(securityService.IsLoggedIn, "User is not logged in.");

            Container.Get<IValidateService>().CheckIsValid(createdActionLog);
            
            var persistentService = Container.Get<IPersistentService>();
            var actionLogType = persistentService.GetEntityById<ActionLogType>(createdActionLog.ActionLogType.Id);
            var currentUser = persistentService.GetEntityById<User>(securityService.CurrentUser.Id);

            var utcNow = Container.Get<ITimeService>().UtcNow;

            var actionLog =
                new DataAccess.ActionLog
                {
                    Text = createdActionLog.Text,
                    DocumentId = createdActionLog.DocumentId,
                    ActionLogType = actionLogType,
                    ActionLogTypeId = actionLogType.Id,
                    CreateUser = currentUser,
                    CreateUserId = currentUser.Id,
                    CreateDate = utcNow
                };
            persistentService.Add(actionLog);

            persistentService.SaveChanges();

            createdActionLog.Id = actionLog.Id;
            createdActionLog.CreateDate = actionLog.CreateDate;
            createdActionLog.CreateUser = actionLog.CreateUser.GetFullName();
        }

        #endregion
    }
}
