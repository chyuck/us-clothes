using System.Data.Entity;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class SettingsMockFactory
    {
        public static DataAccess.Settings SingleSettings
        {
            get
            {
                return CacheHelper.Get(ref _singleSettings,
                    () =>
                        new DataAccess.Settings
                        {
                            Id = 1,
                            RublesPerDollar = 33,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Settings _singleSettings;

        public static IDbSet<DataAccess.Settings> Settings
        {
            get
            {
                return CacheHelper.Get(ref _settings,
                    () =>
                    {
                        var settings =
                            new[]
                            {
                                SingleSettings
                            };

                        return new DbSetMock<DataAccess.Settings>(settings);
                    });
            }
        }
        private static IDbSet<DataAccess.Settings> _settings;

        public static void Reset()
        {
            _singleSettings = null;
            _settings = null;
        }

        public static void InitializeRelations()
        {
            SingleSettings.CreateUserId = UserMockFactory.Andrey.Id;
            SingleSettings.CreatedBy = UserMockFactory.Andrey;
            SingleSettings.ChangeUserId = UserMockFactory.Andrey.Id;
            SingleSettings.ChangedBy = UserMockFactory.Andrey;
        }

        public static void InitializeCollections()
        {
        }
    }
}
