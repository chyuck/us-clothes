using System.Data.Entity;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class ActionLogMockFactory
    {
        public static DataAccess.ActionLog AndreyCreated
        {
            get
            {
                return CacheHelper.Get(ref _andreyCreated,
                    () =>
                        new DataAccess.ActionLog
                        {

                            Id = 1,
                            Text = "Пользователь chyuck создан",
                            CreateDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.ActionLog _andreyCreated;

        public static DataAccess.ActionLog AndreyChanged
        {
            get
            {
                return CacheHelper.Get(ref _andreyChanged,
                    () =>
                        new DataAccess.ActionLog
                        {

                            Id = 2,
                            Text = "Пользователь chyuck изменен",
                            CreateDate = TimeServiceMockFactory.Date3
                        });
            }
        }
        private static DataAccess.ActionLog _andreyChanged;

        public static DataAccess.ActionLog JenyaCreated
        {
            get
            {
                return CacheHelper.Get(ref _jenyaCreated,
                    () =>
                        new DataAccess.ActionLog
                        {

                            Id = 3,
                            Text = "Пользователь jenya создан",
                            CreateDate = TimeServiceMockFactory.Date2
                        });
            }
        }
        private static DataAccess.ActionLog _jenyaCreated;

        public static DataAccess.ActionLog JenyaChangedPassword
        {
            get
            {
                return CacheHelper.Get(ref _jenyaChangedPassword,
                    () =>
                        new DataAccess.ActionLog
                        {

                            Id = 4,
                            Text = "Пользователь jenya сменил пароль",
                            CreateDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.ActionLog _jenyaChangedPassword;

        public static IDbSet<DataAccess.ActionLog> ActionLogs
        {
            get
            {
                return CacheHelper.Get(ref _actionLogs,
                    () =>
                    {
                        var actionLogs =
                            new[]
                            {
                                AndreyCreated,
                                AndreyChanged,
                                JenyaCreated,
                                JenyaChangedPassword
                            };

                        return new DbSetMock<DataAccess.ActionLog>(actionLogs);
                    });
            }
        }
        private static IDbSet<DataAccess.ActionLog> _actionLogs;

        public static void Reset()
        {
            _andreyCreated = null;
            _andreyChanged = null;
            _jenyaCreated = null;
            _jenyaChangedPassword = null;
            _actionLogs = null;
        }

        public static void InitializeRelations()
        {
            AndreyCreated.DocumentId = UserMockFactory.Andrey.Id;
            AndreyCreated.CreateUserId = UserMockFactory.Andrey.Id;
            AndreyCreated.CreateUser = UserMockFactory.Andrey;
            AndreyCreated.ActionLogType = ActionLogTypeMockFactory.UserCreatedType;
            AndreyCreated.ActionLogTypeId = ActionLogTypeMockFactory.UserCreatedType.Id;

            AndreyChanged.DocumentId = UserMockFactory.Andrey.Id;
            AndreyChanged.CreateUserId = UserMockFactory.Jenya.Id;
            AndreyChanged.CreateUser = UserMockFactory.Jenya;
            AndreyChanged.ActionLogType = ActionLogTypeMockFactory.UserChangedType;
            AndreyChanged.ActionLogTypeId = ActionLogTypeMockFactory.UserChangedType.Id;

            JenyaCreated.DocumentId = UserMockFactory.Jenya.Id;
            JenyaCreated.CreateUserId = UserMockFactory.Andrey.Id;
            JenyaCreated.CreateUser = UserMockFactory.Andrey;
            JenyaCreated.ActionLogType = ActionLogTypeMockFactory.UserCreatedType;
            JenyaCreated.ActionLogTypeId = ActionLogTypeMockFactory.UserCreatedType.Id;

            JenyaChangedPassword.DocumentId = UserMockFactory.Jenya.Id;
            JenyaChangedPassword.CreateUserId = UserMockFactory.Jenya.Id;
            JenyaChangedPassword.CreateUser = UserMockFactory.Jenya;
            JenyaChangedPassword.ActionLogType = ActionLogTypeMockFactory.UserChangedPasswordType;
            JenyaChangedPassword.ActionLogTypeId = ActionLogTypeMockFactory.UserChangedPasswordType.Id;
        }

        public static void InitializeCollections()
        {
        }
    }
}
