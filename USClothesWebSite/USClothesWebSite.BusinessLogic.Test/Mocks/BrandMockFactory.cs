using System.Data.Entity;
using System.Linq;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class BrandMockFactory
    {
        public static DataAccess.Brand OshKosh
        {
            get
            {
                return CacheHelper.Get(ref _oshKosh,
                    () =>
                        new DataAccess.Brand
                        {
                            Id = 1,
                            Name = "OshKosh",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Brand _oshKosh;

        public static DataAccess.Brand Carters
        {
            get
            {
                return CacheHelper.Get(ref _carters,
                    () =>
                        new DataAccess.Brand
                        {
                            Id = 2,
                            Name = "Carter's",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Brand _carters;
        
        public static DataAccess.Brand Crazy8
        {
            get
            {
                return CacheHelper.Get(ref _crazy8,
                    () =>
                        new DataAccess.Brand
                        {
                            Id = 3,
                            Name = "Crazy 8",
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.Brand _crazy8;

        public static DataAccess.Brand TheChildrensPlace
        {
            get
            {
                return CacheHelper.Get(ref _theChildrensPlace,
                    () =>
                        new DataAccess.Brand
                        {
                            Id = 4,
                            Name = "The Children's Place",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Brand _theChildrensPlace;

        public static IDbSet<DataAccess.Brand> Brands
        {
            get
            {
                return CacheHelper.Get(ref _brands,
                    () =>
                    {
                        var brands =
                            new[]
                            {
                                OshKosh, 
                                Carters, 
                                Crazy8,
                                TheChildrensPlace
                            };

                        return new DbSetMock<DataAccess.Brand>(brands);
                    });
            }
        }
        private static IDbSet<DataAccess.Brand> _brands;

        public static void Reset()
        {
            _oshKosh = null;
            _carters = null;
            _crazy8 = null;
            _theChildrensPlace = null;
            _brands = null;
        }

        public static void InitializeRelations()
        {
            // OshKosh
            OshKosh.CreateUserId = UserMockFactory.Andrey.Id;
            OshKosh.CreatedBy = UserMockFactory.Andrey;
            OshKosh.ChangeUserId = UserMockFactory.Andrey.Id;
            OshKosh.ChangedBy = UserMockFactory.Andrey;

            // Carter's
            Carters.CreateUserId = UserMockFactory.Andrey.Id;
            Carters.CreatedBy = UserMockFactory.Andrey;
            Carters.ChangeUserId = UserMockFactory.Andrey.Id;
            Carters.ChangedBy = UserMockFactory.Andrey;

            // Crazy 8
            Crazy8.CreateUserId = UserMockFactory.Andrey.Id;
            Crazy8.CreatedBy = UserMockFactory.Andrey;
            Crazy8.ChangeUserId = UserMockFactory.Jenya.Id;
            Crazy8.ChangedBy = UserMockFactory.Jenya;

            // The Children's Place
            TheChildrensPlace.CreateUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace.CreatedBy = UserMockFactory.Andrey;
            TheChildrensPlace.ChangeUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace.ChangedBy = UserMockFactory.Andrey;
        }

        public static void InitializeCollections()
        {
            foreach (var brand in Brands)
            {
                brand.Sizes =
                    SizeMockFactory.Sizes
                        .Where(s => s.Brand == brand)
                        .ToArray();
            }
        }
    }
}
