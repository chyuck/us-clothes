using System.Data.Entity;
using System.Linq;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class SubCategoryMockFactory
    {
        public static SubCategory Girls_0_2
        {
            get
            {
                return CacheHelper.Get(ref _girls_0_2,
                    () =>
                        new SubCategory
                        {
                            Id = 1,
                            Name = "Девочки (0-24 мес)",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static SubCategory _girls_0_2;

        public static SubCategory Girls_2_5
        {
            get
            {
                return CacheHelper.Get(ref _girls_2_5,
                    () =>
                        new SubCategory
                        {
                            Id = 2,
                            Name = "Девочки (2-5 лет)",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static SubCategory _girls_2_5;

        public static SubCategory Girls_5_12
        {
            get
            {
                return CacheHelper.Get(ref _girls_5_12,
                    () =>
                        new SubCategory
                        {
                            Id = 3,
                            Name = "Девочки (5-12 лет)",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static SubCategory _girls_5_12;

        public static SubCategory Boys_0_2
        {
            get
            {
                return CacheHelper.Get(ref _boys_0_2,
                    () =>
                        new SubCategory
                        {
                            Id = 4,
                            Name = "Мальчики (0-24 мес)",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static SubCategory _boys_0_2;

        public static SubCategory Boys_2_5
        {
            get
            {
                return CacheHelper.Get(ref _boys_2_5,
                    () =>
                        new SubCategory
                        {
                            Id = 5,
                            Name = "Мальчики (2-5 лет)",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static SubCategory _boys_2_5;

        public static SubCategory Boys_5_12
        {
            get
            {
                return CacheHelper.Get(ref _boys_5_12,
                    () =>
                        new SubCategory
                        {
                            Id = 6,
                            Name = "Мальчики (5-12 лет)",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static SubCategory _boys_5_12;

        public static SubCategory ManAccessories
        {
            get
            {
                return CacheHelper.Get(ref _manAccessories,
                    () =>
                        new SubCategory
                        {
                            Id = 7,
                            Name = "Аксессуары",
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date3
                        });
            }
        }
        private static SubCategory _manAccessories;

        public static SubCategory ManOuterwear
        {
            get
            {
                return CacheHelper.Get(ref _manOuterwear,
                    () =>
                        new SubCategory
                        {
                            Id = 8,
                            Name = "Верхняя одежда",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static SubCategory _manOuterwear;

        public static SubCategory ManClothes
        {
            get
            {
                return CacheHelper.Get(ref _manClothes,
                    () =>
                        new SubCategory
                        {
                            Id = 9,
                            Name = "Повседневная одежда",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static SubCategory _manClothes;

        public static SubCategory WomanAccessories
        {
            get
            {
                return CacheHelper.Get(ref _womanAccessories,
                    () =>
                        new SubCategory
                        {
                            Id = 10,
                            Name = "Аксессуары",
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date3
                        });
            }
        }
        private static SubCategory _womanAccessories;

        public static SubCategory WomanOuterwear
        {
            get
            {
                return CacheHelper.Get(ref _womanOuterwear,
                    () =>
                        new SubCategory
                        {
                            Id = 11,
                            Name = "Верхняя одежда",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static SubCategory _womanOuterwear;

        public static SubCategory WomanClothes
        {
            get
            {
                return CacheHelper.Get(ref _womanClothes,
                    () =>
                        new SubCategory
                        {
                            Id = 12,
                            Name = "Повседневная одежда",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static SubCategory _womanClothes;

        public static IDbSet<SubCategory> SubCategories
        {
            get
            {
                return CacheHelper.Get(ref _subCategories,
                    () =>
                    {
                        var subCategories =
                            new[]
                            {
                                Girls_0_2, 
                                Girls_2_5, 
                                Girls_5_12,
                                Boys_0_2,
                                Boys_2_5,
                                Boys_5_12,
                                ManAccessories,
                                ManOuterwear,
                                ManClothes,
                                WomanAccessories,
                                WomanOuterwear,
                                WomanClothes
                            };

                        return new DbSetMock<SubCategory>(subCategories);
                    });
            }
        }
        private static IDbSet<SubCategory> _subCategories;

        public static void Reset()
        {
            _girls_0_2 = null;
            _girls_2_5 = null;
            _girls_5_12 = null;
            _boys_0_2 = null;
            _boys_2_5 = null;
            _boys_5_12 = null;
            _manAccessories = null;
            _manOuterwear = null;
            _manClothes = null;
            _womanAccessories = null;
            _womanOuterwear = null;
            _womanClothes = null;
            _subCategories = null;
        }

        public static void InitializeRelations()
        {
            // Children
            Girls_0_2.CreateUserId = UserMockFactory.Andrey.Id;
            Girls_0_2.CreatedBy = UserMockFactory.Andrey;
            Girls_0_2.ChangeUserId = UserMockFactory.Andrey.Id;
            Girls_0_2.ChangedBy = UserMockFactory.Andrey;
            Girls_0_2.CategoryId = CategoryMockFactory.Children.Id;
            Girls_0_2.Category = CategoryMockFactory.Children;

            Girls_2_5.CreateUserId = UserMockFactory.Andrey.Id;
            Girls_2_5.CreatedBy = UserMockFactory.Andrey;
            Girls_2_5.ChangeUserId = UserMockFactory.Andrey.Id;
            Girls_2_5.ChangedBy = UserMockFactory.Andrey;
            Girls_2_5.CategoryId = CategoryMockFactory.Children.Id;
            Girls_2_5.Category = CategoryMockFactory.Children;
            
            Girls_5_12.CreateUserId = UserMockFactory.Andrey.Id;
            Girls_5_12.CreatedBy = UserMockFactory.Andrey;
            Girls_5_12.ChangeUserId = UserMockFactory.Andrey.Id;
            Girls_5_12.ChangedBy = UserMockFactory.Andrey;
            Girls_5_12.CategoryId = CategoryMockFactory.Children.Id;
            Girls_5_12.Category = CategoryMockFactory.Children;
            
            Boys_0_2.CreateUserId = UserMockFactory.Andrey.Id;
            Boys_0_2.CreatedBy = UserMockFactory.Andrey;
            Boys_0_2.ChangeUserId = UserMockFactory.Andrey.Id;
            Boys_0_2.ChangedBy = UserMockFactory.Andrey;
            Boys_0_2.CategoryId = CategoryMockFactory.Children.Id;
            Boys_0_2.Category = CategoryMockFactory.Children;
            
            Boys_2_5.CreateUserId = UserMockFactory.Andrey.Id;
            Boys_2_5.CreatedBy = UserMockFactory.Andrey;
            Boys_2_5.ChangeUserId = UserMockFactory.Andrey.Id;
            Boys_2_5.ChangedBy = UserMockFactory.Andrey;
            Boys_2_5.CategoryId = CategoryMockFactory.Children.Id;
            Boys_2_5.Category = CategoryMockFactory.Children;
            
            Boys_5_12.CreateUserId = UserMockFactory.Andrey.Id;
            Boys_5_12.CreatedBy = UserMockFactory.Andrey;
            Boys_5_12.ChangeUserId = UserMockFactory.Andrey.Id;
            Boys_5_12.ChangedBy = UserMockFactory.Andrey;
            Boys_5_12.CategoryId = CategoryMockFactory.Children.Id;
            Boys_5_12.Category = CategoryMockFactory.Children;

            // Men
            ManAccessories.CreateUserId = UserMockFactory.Andrey.Id;
            ManAccessories.CreatedBy = UserMockFactory.Andrey;
            ManAccessories.ChangeUserId = UserMockFactory.Jenya.Id;
            ManAccessories.ChangedBy = UserMockFactory.Jenya;
            ManAccessories.CategoryId = CategoryMockFactory.Men.Id;
            ManAccessories.Category = CategoryMockFactory.Men;

            ManOuterwear.CreateUserId = UserMockFactory.Andrey.Id;
            ManOuterwear.CreatedBy = UserMockFactory.Andrey;
            ManOuterwear.ChangeUserId = UserMockFactory.Andrey.Id;
            ManOuterwear.ChangedBy = UserMockFactory.Andrey;
            ManOuterwear.CategoryId = CategoryMockFactory.Men.Id;
            ManOuterwear.Category = CategoryMockFactory.Men;

            ManClothes.CreateUserId = UserMockFactory.Andrey.Id;
            ManClothes.CreatedBy = UserMockFactory.Andrey;
            ManClothes.ChangeUserId = UserMockFactory.Andrey.Id;
            ManClothes.ChangedBy = UserMockFactory.Andrey;
            ManClothes.CategoryId = CategoryMockFactory.Men.Id;
            ManClothes.Category = CategoryMockFactory.Men;

            // Woman
            WomanAccessories.CreateUserId = UserMockFactory.Andrey.Id;
            WomanAccessories.CreatedBy = UserMockFactory.Andrey;
            WomanAccessories.ChangeUserId = UserMockFactory.Jenya.Id;
            WomanAccessories.ChangedBy = UserMockFactory.Jenya;
            WomanAccessories.CategoryId = CategoryMockFactory.Women.Id;
            WomanAccessories.Category = CategoryMockFactory.Women;

            WomanOuterwear.CreateUserId = UserMockFactory.Andrey.Id;
            WomanOuterwear.CreatedBy = UserMockFactory.Andrey;
            WomanOuterwear.ChangeUserId = UserMockFactory.Andrey.Id;
            WomanOuterwear.ChangedBy = UserMockFactory.Andrey;
            WomanOuterwear.CategoryId = CategoryMockFactory.Women.Id;
            WomanOuterwear.Category = CategoryMockFactory.Women;

            WomanClothes.CreateUserId = UserMockFactory.Andrey.Id;
            WomanClothes.CreatedBy = UserMockFactory.Andrey;
            WomanClothes.ChangeUserId = UserMockFactory.Andrey.Id;
            WomanClothes.ChangedBy = UserMockFactory.Andrey;
            WomanClothes.CategoryId = CategoryMockFactory.Women.Id;
            WomanClothes.Category = CategoryMockFactory.Women;
        }

        public static void InitializeCollections()
        {
            foreach (var subCategory in SubCategories)
            {
                subCategory.Sizes =
                    SizeMockFactory.Sizes
                        .Where(s => s.SubCategory == subCategory)
                        .ToArray();
            }
        }
    }
}
