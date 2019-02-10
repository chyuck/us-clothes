using System.Data.Entity;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class ProductSizeMockFactory
    {
        public static DataAccess.ProductSize Boys_Sweater_0_3_Months
        {
            get
            {
                return CacheHelper.Get(ref _boys_Sweater_0_3_Months,
                    () =>
                        new DataAccess.ProductSize
                        {

                            Id = 1,
                            Price = 3100m,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.ProductSize _boys_Sweater_0_3_Months;

        public static DataAccess.ProductSize Boys_Sweater_3_6_Months
        {
            get
            {
                return CacheHelper.Get(ref _boys_Sweater_3_6_Months,
                    () =>
                        new DataAccess.ProductSize
                        {

                            Id = 2,
                            Price = 3400m,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date3
                        });
            }
        }
        private static DataAccess.ProductSize _boys_Sweater_3_6_Months;

        public static DataAccess.ProductSize Girls_Sweater_0_3_Months
        {
            get
            {
                return CacheHelper.Get(ref _girls_Sweater_0_3_Months,
                    () =>
                        new DataAccess.ProductSize
                        {

                            Id = 3,
                            Price = 2700m,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date2
                        });
            }
        }
        private static DataAccess.ProductSize _girls_Sweater_0_3_Months;

        public static DataAccess.ProductSize Girls_Sweater_3_6_Months
        {
            get
            {
                return CacheHelper.Get(ref _girls_Sweater_3_6_Months,
                    () =>
                        new DataAccess.ProductSize
                        {

                            Id = 4,
                            Price = 2900m,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date4
                        });
            }
        }
        private static DataAccess.ProductSize _girls_Sweater_3_6_Months;

        public static IDbSet<DataAccess.ProductSize> ProductSizes
        {
            get
            {
                return CacheHelper.Get(ref _productSizes,
                    () =>
                    {
                        var productSizes =
                            new[]
                            {
                                Boys_Sweater_0_3_Months,
                                Boys_Sweater_3_6_Months,
                                Girls_Sweater_0_3_Months,
                                Girls_Sweater_3_6_Months
                            };

                        return new DbSetMock<DataAccess.ProductSize>(productSizes);
                    });
            }
        }
        private static IDbSet<DataAccess.ProductSize> _productSizes;

        public static void Reset()
        {
            _boys_Sweater_0_3_Months = null;
            _boys_Sweater_3_6_Months = null;
            _girls_Sweater_0_3_Months = null;
            _girls_Sweater_3_6_Months = null;

            _productSizes = null;
        }

        public static void InitializeRelations()
        {
            Boys_Sweater_0_3_Months.CreateUserId = UserMockFactory.Andrey.Id;
            Boys_Sweater_0_3_Months.CreatedBy = UserMockFactory.Andrey;
            Boys_Sweater_0_3_Months.ChangeUserId = UserMockFactory.Andrey.Id;
            Boys_Sweater_0_3_Months.ChangedBy = UserMockFactory.Andrey;
            Boys_Sweater_0_3_Months.ProductId = ProductMockFactory.TheChildrensPlace_Boys_Sweater.Id;
            Boys_Sweater_0_3_Months.Product = ProductMockFactory.TheChildrensPlace_Boys_Sweater;
            Boys_Sweater_0_3_Months.SizeId = SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months.Id;
            Boys_Sweater_0_3_Months.Size = SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months;

            Boys_Sweater_3_6_Months.CreateUserId = UserMockFactory.Andrey.Id;
            Boys_Sweater_3_6_Months.CreatedBy = UserMockFactory.Andrey;
            Boys_Sweater_3_6_Months.ChangeUserId = UserMockFactory.Jenya.Id;
            Boys_Sweater_3_6_Months.ChangedBy = UserMockFactory.Jenya;
            Boys_Sweater_3_6_Months.ProductId = ProductMockFactory.TheChildrensPlace_Boys_Sweater.Id;
            Boys_Sweater_3_6_Months.Product = ProductMockFactory.TheChildrensPlace_Boys_Sweater;
            Boys_Sweater_3_6_Months.SizeId = SizeMockFactory.TheChildrensPlace_Boys_0_2_3_6_Months.Id;
            Boys_Sweater_3_6_Months.Size = SizeMockFactory.TheChildrensPlace_Boys_0_2_3_6_Months;

            Girls_Sweater_0_3_Months.CreateUserId = UserMockFactory.Jenya.Id;
            Girls_Sweater_0_3_Months.CreatedBy = UserMockFactory.Jenya;
            Girls_Sweater_0_3_Months.ChangeUserId = UserMockFactory.Jenya.Id;
            Girls_Sweater_0_3_Months.ChangedBy = UserMockFactory.Jenya;
            Girls_Sweater_0_3_Months.ProductId = ProductMockFactory.TheChildrensPlace_Girls_Sweater.Id;
            Girls_Sweater_0_3_Months.Product = ProductMockFactory.TheChildrensPlace_Girls_Sweater;
            Girls_Sweater_0_3_Months.SizeId = SizeMockFactory.TheChildrensPlace_Girls_0_2_0_3_Months.Id;
            Girls_Sweater_0_3_Months.Size = SizeMockFactory.TheChildrensPlace_Girls_0_2_0_3_Months;

            Girls_Sweater_3_6_Months.CreateUserId = UserMockFactory.Jenya.Id;
            Girls_Sweater_3_6_Months.CreatedBy = UserMockFactory.Jenya;
            Girls_Sweater_3_6_Months.ChangeUserId = UserMockFactory.Diana.Id;
            Girls_Sweater_3_6_Months.ChangedBy = UserMockFactory.Diana;
            Girls_Sweater_3_6_Months.ProductId = ProductMockFactory.TheChildrensPlace_Girls_Sweater.Id;
            Girls_Sweater_3_6_Months.Product = ProductMockFactory.TheChildrensPlace_Girls_Sweater;
            Girls_Sweater_3_6_Months.SizeId = SizeMockFactory.TheChildrensPlace_Girls_0_2_3_6_Months.Id;
            Girls_Sweater_3_6_Months.Size = SizeMockFactory.TheChildrensPlace_Girls_0_2_3_6_Months;
        }

        public static void InitializeCollections()
        {
        }
    }
}
