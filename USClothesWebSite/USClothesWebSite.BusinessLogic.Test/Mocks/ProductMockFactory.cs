using System.Data.Entity;
using System.Linq;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class ProductMockFactory
    {
        public static DataAccess.Product TheChildrensPlace_Boys_Sweater
        {
            get
            {
                return CacheHelper.Get(ref _theChildrensPlace_Boys_Sweater,
                    () =>
                        new DataAccess.Product
                        {

                            Id = 1,
                            Name = "Свитер детский (м)",
                            Active = true,
                            Description = "Свитер детский (м), желтый с красной полосой.",
                            FullPictureURL = @"/Images/full_45645g6jk45h6kj56456.jpg",
                            PreviewPictureURL = @"/Images/preview_45645g6jk45h6kj56456.jpg",
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Product _theChildrensPlace_Boys_Sweater;

        public static DataAccess.Product Carters_Boys_Shorts
        {
            get
            {
                return CacheHelper.Get(ref _carters_Boys_Shorts,
                    () =>
                        new DataAccess.Product
                        {

                            Id = 2,
                            Name = "Шорты",
                            Active = true,
                            Description = "Шорты детские по колено, синие.",
                            FullPictureURL = @"/Images/full_546tdfg455465tger54645.jpg",
                            PreviewPictureURL = @"/Images/preview_546tdfg455465tger54645.jpg",
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date2
                        });
            }
        }
        private static DataAccess.Product _carters_Boys_Shorts;

        public static DataAccess.Product TheChildrensPlace_Boys_TShirt
        {
            get
            {
                return CacheHelper.Get(ref _theChildrensPlace_Boys_TShirt,
                    () =>
                        new DataAccess.Product
                        {
                            Id = 3,
                            Name = "Майка",
                            Active = false,
                            Description = "Майка детская, зеленая с рисунком.",
                            FullPictureURL = @"/Images/full_45645е54е45е546456.jpg",
                            PreviewPictureURL = @"/Images/preview_45645е54е45е546456.jpg",
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.Product _theChildrensPlace_Boys_TShirt;

        public static DataAccess.Product TheChildrensPlace_Girls_Sweater
        {
            get
            {
                return CacheHelper.Get(ref _theChildrensPlace_Girls_Sweater,
                    () =>
                        new DataAccess.Product
                        {

                            Id = 4,
                            Name = "Свитер детский (ж)",
                            Active = true,
                            Description = "Свитер девчячий, клетчатый.",
                            FullPictureURL = @"/Images/full_45645е54е45yui789yuu.jpg",
                            PreviewPictureURL = @"/Images/preview_45645е54е45yui789yuu.jpg",
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date3
                        });
            }
        }
        private static DataAccess.Product _theChildrensPlace_Girls_Sweater;

        public static DataAccess.Product TheChildrensPlace_Girls_Shorts
        {
            get
            {
                return CacheHelper.Get(ref _theChildrensPlace_Girls_Shorts,
                    () =>
                        new DataAccess.Product
                        {

                            Id = 5,
                            Name = "Шорты",
                            Active = true,
                            Description = "Шорты для девочек, в карпинку голубой.",
                            FullPictureURL = @"/Images/full_у32уу32yui789yuu.jpg",
                            PreviewPictureURL = @"/Images/preview_у32уу32yui789yuu.jpg",
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date4
                        });
            }
        }
        private static DataAccess.Product _theChildrensPlace_Girls_Shorts;

        public static IDbSet<DataAccess.Product> Products
        {
            get
            {
                return CacheHelper.Get(ref _products,
                    () =>
                    {
                        var products =
                            new[]
                            {
                                TheChildrensPlace_Boys_Sweater,
                                Carters_Boys_Shorts,
                                TheChildrensPlace_Boys_TShirt,
                                TheChildrensPlace_Girls_Sweater,
                                TheChildrensPlace_Girls_Shorts
                            };

                        return new DbSetMock<DataAccess.Product>(products);
                    });
            }
        }
        private static IDbSet<DataAccess.Product> _products;

        public static void Reset()
        {
            _theChildrensPlace_Boys_Sweater = null;
            _carters_Boys_Shorts = null;
            _theChildrensPlace_Boys_TShirt = null;
            _theChildrensPlace_Boys_Sweater = null;
            _theChildrensPlace_Girls_Shorts = null;

            _products = null;
        }

        public static void InitializeRelations()
        {
            TheChildrensPlace_Boys_Sweater.CreateUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Boys_Sweater.CreatedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Boys_Sweater.ChangeUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Boys_Sweater.ChangedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Boys_Sweater.SubCategoryId = SubCategoryMockFactory.Boys_0_2.Id;
            TheChildrensPlace_Boys_Sweater.SubCategory = SubCategoryMockFactory.Boys_0_2;
            TheChildrensPlace_Boys_Sweater.BrandId = BrandMockFactory.TheChildrensPlace.Id;
            TheChildrensPlace_Boys_Sweater.Brand = BrandMockFactory.TheChildrensPlace;

            Carters_Boys_Shorts.CreateUserId = UserMockFactory.Andrey.Id;
            Carters_Boys_Shorts.CreatedBy = UserMockFactory.Andrey;
            Carters_Boys_Shorts.ChangeUserId = UserMockFactory.Diana.Id;
            Carters_Boys_Shorts.ChangedBy = UserMockFactory.Diana;
            Carters_Boys_Shorts.SubCategoryId = SubCategoryMockFactory.Boys_0_2.Id;
            Carters_Boys_Shorts.SubCategory = SubCategoryMockFactory.Boys_0_2;
            Carters_Boys_Shorts.BrandId = BrandMockFactory.Carters.Id;
            Carters_Boys_Shorts.Brand = BrandMockFactory.Carters;

            TheChildrensPlace_Boys_TShirt.CreateUserId = UserMockFactory.Jenya.Id;
            TheChildrensPlace_Boys_TShirt.CreatedBy = UserMockFactory.Jenya;
            TheChildrensPlace_Boys_TShirt.ChangeUserId = UserMockFactory.Jenya.Id;
            TheChildrensPlace_Boys_TShirt.ChangedBy = UserMockFactory.Jenya;
            TheChildrensPlace_Boys_TShirt.SubCategoryId = SubCategoryMockFactory.Boys_0_2.Id;
            TheChildrensPlace_Boys_TShirt.SubCategory = SubCategoryMockFactory.Boys_0_2;
            TheChildrensPlace_Boys_TShirt.BrandId = BrandMockFactory.TheChildrensPlace.Id;
            TheChildrensPlace_Boys_TShirt.Brand = BrandMockFactory.TheChildrensPlace;

            TheChildrensPlace_Girls_Sweater.CreateUserId = UserMockFactory.Jenya.Id;
            TheChildrensPlace_Girls_Sweater.CreatedBy = UserMockFactory.Jenya;
            TheChildrensPlace_Girls_Sweater.ChangeUserId = UserMockFactory.Diana.Id;
            TheChildrensPlace_Girls_Sweater.ChangedBy = UserMockFactory.Diana;
            TheChildrensPlace_Girls_Sweater.SubCategoryId = SubCategoryMockFactory.Girls_0_2.Id;
            TheChildrensPlace_Girls_Sweater.SubCategory = SubCategoryMockFactory.Girls_0_2;
            TheChildrensPlace_Girls_Sweater.BrandId = BrandMockFactory.TheChildrensPlace.Id;
            TheChildrensPlace_Girls_Sweater.Brand = BrandMockFactory.TheChildrensPlace;

            TheChildrensPlace_Girls_Shorts.CreateUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Girls_Shorts.CreatedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Girls_Shorts.ChangeUserId = UserMockFactory.Andrey.Id;
            TheChildrensPlace_Girls_Shorts.ChangedBy = UserMockFactory.Andrey;
            TheChildrensPlace_Girls_Shorts.SubCategoryId = SubCategoryMockFactory.Girls_0_2.Id;
            TheChildrensPlace_Girls_Shorts.SubCategory = SubCategoryMockFactory.Girls_0_2;
            TheChildrensPlace_Girls_Shorts.BrandId = BrandMockFactory.TheChildrensPlace.Id;
            TheChildrensPlace_Girls_Shorts.Brand = BrandMockFactory.TheChildrensPlace;
        }

        public static void InitializeCollections()
        {
            foreach (var product in Products)
            {
                product.ProductSizes =
                    ProductSizeMockFactory.ProductSizes
                        .Where(ps => ps.Product == product)
                        .ToArray();
            }
        }
    }
}
