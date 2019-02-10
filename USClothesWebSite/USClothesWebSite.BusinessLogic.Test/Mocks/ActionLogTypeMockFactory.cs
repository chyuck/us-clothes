using System.Data.Entity;
using System.Linq;
using USClothesWebSite.BusinessLogic.ActionLog;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class ActionLogTypeMockFactory
    {
        public static ActionLogType UserCreatedType
        {
            get
            {
                return CacheHelper.Get(ref _userCreatedType,
                    () =>
                        new ActionLogType
                        {

                            Id = 1,
                            Name = ActionLogService.USER_CREATED_TYPE_NAME
                        });
            }
        }
        private static ActionLogType _userCreatedType;

        public static ActionLogType UserChangedType
        {
            get
            {
                return CacheHelper.Get(ref _userChangedType,
                    () =>
                        new ActionLogType
                        {

                            Id = 2,
                            Name = ActionLogService.USER_CHANGED_TYPE_NAME
                        });
            }
        }
        private static ActionLogType _userChangedType;

        public static ActionLogType UserChangedPasswordType
        {
            get
            {
                return CacheHelper.Get(ref _userChangedPasswordType,
                    () =>
                        new ActionLogType
                        {

                            Id = 3,
                            Name = ActionLogService.USER_CHANGED_PASSWORD_TYPE_NAME
                        });
            }
        }
        private static ActionLogType _userChangedPasswordType;

        public static ActionLogType PasswordWasResetedForUserType
        {
            get
            {
                return CacheHelper.Get(ref _passwordWasResetedForUserType,
                    () =>
                        new ActionLogType
                        {

                            Id = 4,
                            Name = ActionLogService.PASSWORD_WAS_RESETED_FOR_USER_TYPE_NAME
                        });
            }
        }
        private static ActionLogType _passwordWasResetedForUserType;

        public static IDbSet<ActionLogType> ActionLogTypes
        {
            get
            {
                return CacheHelper.Get(ref _actionLogTypes,
                    () =>
                    {
                        var actionLogTypes =
                            new[]
                            {
                                UserCreatedType,
                                UserChangedType,
                                UserChangedPasswordType,
                                PasswordWasResetedForUserType
                            };

                        return new DbSetMock<ActionLogType>(actionLogTypes);
                    });
            }
        }
        private static IDbSet<ActionLogType> _actionLogTypes;
        
        public static void Reset()
        {
            _userCreatedType = null;
            _userChangedType = null;
            _userChangedPasswordType = null;
            _actionLogTypes = null;
            _passwordWasResetedForUserType = null;
        }

        public static void InitializeRelations()
        {
        }

        public static void InitializeCollections()
        {
            foreach (var actionLogType in ActionLogTypes)
            {
                actionLogType.ActionLogs =
                    ActionLogMockFactory.ActionLogs
                        .Where(al => al.ActionLogType == actionLogType)
                        .ToArray();
            }
        }
    }
}
