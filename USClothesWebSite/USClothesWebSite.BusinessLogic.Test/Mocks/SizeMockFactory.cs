using System.Data.Entity;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class SizeMockFactory
    {
        public static DataAccess.Size TheChildrensPlace_Boys_0_2_Newborn
        {
            get
            {
                return CacheHelper.Get(ref _theChildrensPlace_Boys_0_2_Newborn,
                    () =>
                        new DataAccess.Size
                        {

                            Id = 1,
                            Name = "newborn",
                            Height = "up to 46 cm",
                            Weight = "up to 3 kg",
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Size _theChildrensPlace_Boys_0_2_Newborn;

        public static DataAccess.Size TheChildrensPlace_Boys_0_2_0_3_Months
        {
            get
            {
                return CacheHelper.Get(ref _theChildrensPlace_Boys_0_2_0_3_Months,
                    () =>
                        new DataAccess.Size
                        {

                            Id = 2,
                            Name = "0-3 months",
                            Height = "46-58 cm",
                            Weight = "3-5 kg",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Size _theChildrensPlace_Boys_0_2_0_3_Months;

        public static DataAccess.Size TheChildrensPlace_Boys_0_2_3_6_Months
        {
            get
            {
                return CacheHelper.Get(ref _theChildrensPlace_Boys_0_2_3_6_Months,
                    () =>
                        new DataAccess.Size
                        {

                            Id = 3,
                            Name = "3-6 months",
                            Height = "58-64 cm",
                            Weight = "5-7 kg",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Size _theChildrensPlace_Boys_0_2_3_6_Months;

        public static DataAccess.Size TheChildrensPlace_Girls_0_2_Newborn
        {
            get
            {
                return CacheHelper.Get(ref _theChildrensPlace_Girls_0_2_Newborn,
                    () =>
                        new DataAccess.Size
                        {

                            Id = 4,
                            Name = "newborn",
                            Height = "up to 46 cm",
                            Weight = "up to 3 kg",
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Size _theChildrensPlace_Girls_0_2_Newborn;

        public static DataAccess.Size TheChildrensPlace_Girls_0_2_0_3_Months
        {
            get
            {
                return CacheHelper.Get(ref _theChildrensPlace_Girls_0_2_0_3_Months,
                    () =>
                        new DataAccess.Size
                        {

                            Id = 5,
                            Name = "0-3 months",
                            Height = "46-58 cm",
                            Weight = "3-5 kg",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Size _theChildrensPlace_Girls_0_2_0_3_Months;

        public static DataAccess.Size TheChildrensPlace_Girls_0_2_3_6_Months
        {
            get
            {
                return CacheHelper.Get(ref _theChildrensPlace_Girls_0_2_3_6_Months,
                    () =>
                        new DataAccess.Size
                        {

                            Id = 6,
                            Name = "3-6 months",
                            Height = "58-64 cm",
                            Weight = "5-7 kg",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Size _theChildrensPlace_Girls_0_2_3_6_Months;

        public static DataAccess.Size Carters_Boys_0_2_3M
        {
            get
            {
                return CacheHelper.Get(ref _carters_Boys_0_2_3M,
                    () =>
                        new DataAccess.Size
                        {

                            Id = 7,
                            Name = "3M",
                            Height = "52.7-61 cm",
                            Weight = "3.6-5.7 kg",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Size _carters_Boys_0_2_3M;

        public static DataAccess.Size Carters_Boys_0_2_6M
        {
            get
            {
                return CacheHelper.Get(ref _carters_Boys_0_2_6M,
                    () =>
                        new DataAccess.Size
                        {

                            Id = 8,
                            Name = "6M",
                            Height = "61-67 cm",
                            Weight = "5.7-7.5 kg",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Size _carters_Boys_0_2_6M;

        public static DataAccess.Size Carters_Girls_0_2_3M
        {
            get
            {
                return CacheHelper.Get(ref _carters_Girls_0_2_3M,
                    () =>
                        new DataAccess.Size
                        {

                            Id = 9,
                            Name = "3M",
                            Height = "52.7-61 cm",
                            Weight = "3.6-5.7 kg",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Size _carters_Girls_0_2_3M;

        public static DataAccess.Size Carters_Girls_0_2_6M
        {
            get
            {
                return CacheHelper.Get(ref _carters_Girls_0_2_6M,
                    () =>
                        new DataAccess.Size
                        {

                            Id = 10,
                            Name = "6M",
                            Height = "61-67 cm",
                            Weight = "5.7-7.5 kg",
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Size _carters_Girls_0_2_6M;

        public static IDbSet<DataAccess.Size> Sizes
        {
            get
            {
                return CacheHelper.Get(ref _sizes,
                    () =>
                    {
                        var sizes =
                            new[]
                            {
                                TheChildrensPlace_Boys_0_2_Newborn,
                                TheChildrensPlace_Boys_0_2_0_3_Months,
                                TheChildrensPlace_Boys_0_2_3_6_Months,
                                TheChildrensPlace_Girls_0_2_Newborn,
                                TheChildrensPlace_Girls_0_2_0_3_Months,
                                TheChildrensPlace_Girls_0_2_3_6_Months,
                                Carters_Boys_0_2_3M,
                                Carters_Boys_0_2_6M,
                                Carters_Girls_0_2_3M,
                                Carters_Girls_0_2_6M
                            };

                        return new DbSetMock<DataAccess.Size>(sizes);
                    });
            }
        }
        private static IDbSet<DataAccess.Size> _sizes;

        public static void Reset()
        {
            _theChildrensPlace_Boys_0_2_Newborn = null;
            _theChildrensPlace_Boys_0_2_0_3_Months = null;
            _theChildrensPlace_Boys_0_2_3_6_Months = null;
            _theChildrensPlace_Girls_0_2_Newborn = null;
            _theChildrensPlace_Girls_0_2_0_3_Months = null;
            _theChildrensPlace_Girls_0_2_3_6_Months = null;
            _carters_Boys_0_2_3M = null;
            _carters_Boys_0_2_6M = null;
            _carters_Girls_0_2_3M = null;
            _carters_Girls_0_2_6M = null;
            _sizes = null;
        }

        public static void InitializeRelations()
        {
            // The Children's Place
            TheChildrensPlace_Boys_0_2_Newborn.CreateUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Boys_0_2_Newborn.CreatedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Boys_0_2_Newborn.ChangeUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Boys_0_2_Newborn.ChangedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Boys_0_2_Newborn.SubCategoryId = SubCategoryMockFactory.Boys_0_2.Id;
            TheChildrensPlace_Boys_0_2_Newborn.SubCategory = SubCategoryMockFactory.Boys_0_2;
            TheChildrensPlace_Boys_0_2_Newborn.BrandId = BrandMockFactory.TheChildrensPlace.Id;
            TheChildrensPlace_Boys_0_2_Newborn.Brand = BrandMockFactory.TheChildrensPlace;

            TheChildrensPlace_Boys_0_2_0_3_Months.CreateUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Boys_0_2_0_3_Months.CreatedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Boys_0_2_0_3_Months.ChangeUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Boys_0_2_0_3_Months.ChangedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Boys_0_2_0_3_Months.SubCategoryId = SubCategoryMockFactory.Boys_0_2.Id;
            TheChildrensPlace_Boys_0_2_0_3_Months.SubCategory = SubCategoryMockFactory.Boys_0_2;
            TheChildrensPlace_Boys_0_2_0_3_Months.BrandId = BrandMockFactory.TheChildrensPlace.Id;
            TheChildrensPlace_Boys_0_2_0_3_Months.Brand = BrandMockFactory.TheChildrensPlace;

            TheChildrensPlace_Boys_0_2_3_6_Months.CreateUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Boys_0_2_3_6_Months.CreatedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Boys_0_2_3_6_Months.ChangeUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Boys_0_2_3_6_Months.ChangedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Boys_0_2_3_6_Months.SubCategoryId = SubCategoryMockFactory.Boys_0_2.Id;
            TheChildrensPlace_Boys_0_2_3_6_Months.SubCategory = SubCategoryMockFactory.Boys_0_2;
            TheChildrensPlace_Boys_0_2_3_6_Months.BrandId = BrandMockFactory.TheChildrensPlace.Id;
            TheChildrensPlace_Boys_0_2_3_6_Months.Brand = BrandMockFactory.TheChildrensPlace;

            TheChildrensPlace_Girls_0_2_Newborn.CreateUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Girls_0_2_Newborn.CreatedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Girls_0_2_Newborn.ChangeUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Girls_0_2_Newborn.ChangedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Girls_0_2_Newborn.SubCategoryId = SubCategoryMockFactory.Girls_0_2.Id;
            TheChildrensPlace_Girls_0_2_Newborn.SubCategory = SubCategoryMockFactory.Girls_0_2;
            TheChildrensPlace_Girls_0_2_Newborn.BrandId = BrandMockFactory.TheChildrensPlace.Id;
            TheChildrensPlace_Girls_0_2_Newborn.Brand = BrandMockFactory.TheChildrensPlace;

            TheChildrensPlace_Girls_0_2_0_3_Months.CreateUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Girls_0_2_0_3_Months.CreatedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Girls_0_2_0_3_Months.ChangeUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Girls_0_2_0_3_Months.ChangedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Girls_0_2_0_3_Months.SubCategoryId = SubCategoryMockFactory.Girls_0_2.Id;
            TheChildrensPlace_Girls_0_2_0_3_Months.SubCategory = SubCategoryMockFactory.Girls_0_2;
            TheChildrensPlace_Girls_0_2_0_3_Months.BrandId = BrandMockFactory.TheChildrensPlace.Id;
            TheChildrensPlace_Girls_0_2_0_3_Months.Brand = BrandMockFactory.TheChildrensPlace;

            TheChildrensPlace_Girls_0_2_3_6_Months.CreateUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Girls_0_2_3_6_Months.CreatedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Girls_0_2_3_6_Months.ChangeUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Girls_0_2_3_6_Months.ChangedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Girls_0_2_3_6_Months.SubCategoryId = SubCategoryMockFactory.Girls_0_2.Id;
            TheChildrensPlace_Girls_0_2_3_6_Months.SubCategory = SubCategoryMockFactory.Girls_0_2;
            TheChildrensPlace_Girls_0_2_3_6_Months.BrandId = BrandMockFactory.TheChildrensPlace.Id;
            TheChildrensPlace_Girls_0_2_3_6_Months.Brand = BrandMockFactory.TheChildrensPlace;

            // Carter's
            Carters_Boys_0_2_3M.CreateUserId = UserMockFactory.Andrey.Id;
            Carters_Boys_0_2_3M.CreatedBy = UserMockFactory.Andrey;
            Carters_Boys_0_2_3M.ChangeUserId = UserMockFactory.Andrey.Id;
            Carters_Boys_0_2_3M.ChangedBy = UserMockFactory.Andrey;
            Carters_Boys_0_2_3M.SubCategoryId = SubCategoryMockFactory.Boys_0_2.Id;
            Carters_Boys_0_2_3M.SubCategory = SubCategoryMockFactory.Boys_0_2;
            Carters_Boys_0_2_3M.BrandId = BrandMockFactory.Carters.Id;
            Carters_Boys_0_2_3M.Brand = BrandMockFactory.Carters;

            Carters_Boys_0_2_6M.CreateUserId = UserMockFactory.Andrey.Id;
            Carters_Boys_0_2_6M.CreatedBy = UserMockFactory.Andrey;
            Carters_Boys_0_2_6M.ChangeUserId = UserMockFactory.Andrey.Id;
            Carters_Boys_0_2_6M.ChangedBy = UserMockFactory.Andrey;
            Carters_Boys_0_2_6M.SubCategoryId = SubCategoryMockFactory.Boys_0_2.Id;
            Carters_Boys_0_2_6M.SubCategory = SubCategoryMockFactory.Boys_0_2;
            Carters_Boys_0_2_6M.BrandId = BrandMockFactory.Carters.Id;
            Carters_Boys_0_2_6M.Brand = BrandMockFactory.Carters;

            Carters_Girls_0_2_3M.CreateUserId = UserMockFactory.Andrey.Id;
            Carters_Girls_0_2_3M.CreatedBy = UserMockFactory.Andrey;
            Carters_Girls_0_2_3M.ChangeUserId = UserMockFactory.Andrey.Id;
            Carters_Girls_0_2_3M.ChangedBy = UserMockFactory.Andrey;
            Carters_Girls_0_2_3M.SubCategoryId = SubCategoryMockFactory.Girls_0_2.Id;
            Carters_Girls_0_2_3M.SubCategory = SubCategoryMockFactory.Girls_0_2;
            Carters_Girls_0_2_3M.BrandId = BrandMockFactory.Carters.Id;
            Carters_Girls_0_2_3M.Brand = BrandMockFactory.Carters;

            Carters_Girls_0_2_6M.CreateUserId = UserMockFactory.Andrey.Id;
            Carters_Girls_0_2_6M.CreatedBy = UserMockFactory.Andrey;
            Carters_Girls_0_2_6M.ChangeUserId = UserMockFactory.Andrey.Id;
            Carters_Girls_0_2_6M.ChangedBy = UserMockFactory.Andrey;
            Carters_Girls_0_2_6M.SubCategoryId = SubCategoryMockFactory.Girls_0_2.Id;
            Carters_Girls_0_2_6M.SubCategory = SubCategoryMockFactory.Girls_0_2;
            Carters_Girls_0_2_6M.BrandId = BrandMockFactory.Carters.Id;
            Carters_Girls_0_2_6M.Brand = BrandMockFactory.Carters;
        }

        public static void InitializeCollections()
        {
        }
    }
}
