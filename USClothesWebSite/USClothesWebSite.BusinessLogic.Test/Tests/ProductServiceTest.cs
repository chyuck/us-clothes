using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Product;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.BusinessLogic.Test.Extensions;
using USClothesWebSite.BusinessLogic.Test.Mocks;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.DataAccess;
using USClothesWebSite.Test.Common;
using USClothesWebSite.BusinessLogic.Extensions;

namespace USClothesWebSite.BusinessLogic.Test
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void GetActiveProductsBySubCategory_Should_Return_All_Active_Products_By_SubCategory()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            container.Get<ISecurityService>().LogInGuest();

            var dtoService = container.Get<IDtoService>();
            var productService = container.Get<IProductService>();

            var subCategory = dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_0_2);

            // Act
            var products = productService.GetActiveProductsBySubCategory(subCategory);

            // Assert
            var expectedProducts =
                new[]
                {
                    dtoService.CreateProduct(ProductMockFactory.Carters_Boys_Shorts),
                    dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Boys_Sweater)
                };

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void GetActiveProductsBySubCategory_Should_Throw_Exception_When_User_Is_Not_Logged_In()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var dtoService = container.Get<IDtoService>();
            var productService = container.Get<IProductService>();

            var subCategory = dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_0_2);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => productService.GetActiveProductsBySubCategory(subCategory),
                "User is not logged in.");
        }

        [TestMethod]
        public void GetActiveProductsByBrand_Should_Return_All_Active_Products_By_Brand()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            container.Get<ISecurityService>().LogInGuest();

            var dtoService = container.Get<IDtoService>();
            var productService = container.Get<IProductService>();

            var brand = dtoService.CreateBrand(BrandMockFactory.TheChildrensPlace);

            // Act
            var products = productService.GetActiveProductsByBrand(brand);

            // Assert
            var expectedProducts =
                new[]
                {
                    dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Girls_Shorts),
                    dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Girls_Sweater),
                    dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Boys_Sweater)
                };

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void GetActiveProductsByBrand_Should_Throw_Exception_When_User_Is_Not_Logged_In()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var dtoService = container.Get<IDtoService>();
            var productService = container.Get<IProductService>();

            var brand = dtoService.CreateBrand(BrandMockFactory.TheChildrensPlace);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => productService.GetActiveProductsByBrand(brand),
                "User is not logged in.");
        }

        [TestMethod]
        public void GetProducts_Should_Return_Products_By_Dates()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var productService = container.Get<IProductService>();

            // Act
            var products = productService.GetProducts(TimeServiceMockFactory.Date2, TimeServiceMockFactory.Date3, null);

            // Assert
            var expectedProducts =
                new[]
                {
                    dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Girls_Sweater),
                    dtoService.CreateProduct(ProductMockFactory.Carters_Boys_Shorts)
                };

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void GetProducts_Should_Return_All_Products_When_Filter_Is_Empty()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var productService = container.Get<IProductService>();

            // Act
            var products = productService.GetProducts(TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null);

            // Assert
            var expectedProducts =
                new[]
                {
                    dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Boys_TShirt),  //Date5
                    dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Girls_Shorts), //Date4
                    dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Girls_Sweater),//Date3
                    dtoService.CreateProduct(ProductMockFactory.Carters_Boys_Shorts),            //Date2
                    dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Boys_Sweater)  //Date1
                };

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void GetProducts_Should_Return_Products_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var productService = container.Get<IProductService>();

            // Act
            var products = productService.GetProducts(TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, "Свитер");

            // Assert
            var expectedProducts =
                new[]
                {
                    dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Girls_Sweater), //Date3
                    dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Boys_Sweater)   //Date1
                };

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void GetProducts_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var productService = container.Get<IProductService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => productService.GetProducts(TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null),
                "Only seller can get all products.");
        }

        [TestMethod]
        public void CreateProduct_Should_Create_Product()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_PRODUCT_NAME = "New Product";
            const string NEW_PRODUCT_DESCRIPTION = "New Description";
            const string NEW_PRODUCT_FULL_PICTURE_URL = "Images/full_g9e8ryg89rygyg89rey.jpg";
            const string NEW_PRODUCT_PREVIEW_PICTURE_URL = "Images/preview_g9e8ryg89rygyg89rey.jpg";
            const string NEW_PRODUCT_VENDOR_SHOP_URL = "http://www.carters.com/carters/Surf-Sunglasses/V_24960,default,pd.html?dwvar_V__24960_color=Gray&cgid=carters-toddler-boy-swim-shop-sunglasses&start=";

            var brand = container.Get<IDtoService>().CreateBrand(BrandMockFactory.Carters);
            var subCategory = container.Get<IDtoService>().CreateSubCategory(SubCategoryMockFactory.Boys_2_5);

            var createdProduct =
                new DTO.Product
                {
                    Name = NEW_PRODUCT_NAME,
                    Active = true,
                    Description = NEW_PRODUCT_DESCRIPTION,
                    PreviewPictureURL = HttpServiceMockFactory.APPLICATION_URL + NEW_PRODUCT_PREVIEW_PICTURE_URL,
                    FullPictureURL = HttpServiceMockFactory.APPLICATION_URL + NEW_PRODUCT_FULL_PICTURE_URL,
                    VendorShopURL = NEW_PRODUCT_VENDOR_SHOP_URL,
                    Brand = brand,
                    SubCategory = subCategory
                };

            var productService = container.Get<IProductService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            productService.CreateProduct(createdProduct);
            
            // Assert
            Assert.IsTrue(createdProduct.Id > 0);

            var actualProduct =
                persistentService
                    .GetEntitySet<DataAccess.Product>()
                    .Single(s => s.Id == createdProduct.Id);

            Assert.AreEqual(NEW_PRODUCT_NAME, actualProduct.Name);
            Assert.IsTrue(actualProduct.Active);
            Assert.AreEqual(NEW_PRODUCT_DESCRIPTION, actualProduct.Description);
            Assert.AreEqual(NEW_PRODUCT_PREVIEW_PICTURE_URL, actualProduct.PreviewPictureURL);
            Assert.AreEqual(NEW_PRODUCT_FULL_PICTURE_URL, actualProduct.FullPictureURL);
            Assert.AreEqual(NEW_PRODUCT_VENDOR_SHOP_URL, actualProduct.VendorShopURL);
            Assert.AreEqual(SubCategoryMockFactory.Boys_2_5.Id, actualProduct.SubCategory.Id);
            Assert.AreEqual(SubCategoryMockFactory.Boys_2_5.Name, actualProduct.SubCategory.Name);
            Assert.AreEqual(SubCategoryMockFactory.Boys_2_5.Active, actualProduct.SubCategory.Active);
            Assert.AreEqual(BrandMockFactory.Carters.Id, actualProduct.Brand.Id);
            Assert.AreEqual(BrandMockFactory.Carters.Name, actualProduct.Brand.Name);
            Assert.AreEqual(BrandMockFactory.Carters.Active, actualProduct.Brand.Active);
            Assert.AreEqual(timeService.UtcNow, actualProduct.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualProduct.ChangeDate);
            Assert.AreEqual(UserMockFactory.Diana, actualProduct.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualProduct.ChangedBy);

            Assert.AreEqual(createdProduct, container.Get<IDtoService>().CreateProduct(actualProduct));
        }

        [TestMethod]
        public void CreateProduct_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            const string NEW_PRODUCT_NAME = "New Product";
            const string NEW_PRODUCT_DESCRIPTION = "New Description";
            const string NEW_PRODUCT_FULL_PICTURE_URL = "Images/full_g9e8ryg89rygyg89rey.jpg";
            const string NEW_PRODUCT_PREVIEW_PICTURE_URL = "Images/preview_g9e8ryg89rygyg89rey.jpg";
            const string NEW_PRODUCT_VENDOR_SHOP_URL = "http://www.carters.com/carters/Surf-Sunglasses/V_24960,default,pd.html?dwvar_V__24960_color=Gray&cgid=carters-toddler-boy-swim-shop-sunglasses&start=";

            var brand = container.Get<IDtoService>().CreateBrand(BrandMockFactory.Carters);
            var subCategory = container.Get<IDtoService>().CreateSubCategory(SubCategoryMockFactory.Boys_2_5);

            var createdProduct =
                new DTO.Product
                {
                    Name = NEW_PRODUCT_NAME,
                    Active = true,
                    Description = NEW_PRODUCT_DESCRIPTION,
                    PreviewPictureURL = HttpServiceMockFactory.APPLICATION_URL + NEW_PRODUCT_PREVIEW_PICTURE_URL,
                    FullPictureURL = HttpServiceMockFactory.APPLICATION_URL + NEW_PRODUCT_FULL_PICTURE_URL,
                    VendorShopURL = NEW_PRODUCT_VENDOR_SHOP_URL,
                    Brand = brand,
                    SubCategory = subCategory
                };

            var productService = container.Get<IProductService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => productService.CreateProduct(createdProduct),
                "Only seller can create product.");
        }

        [TestMethod]
        public void UpdateProduct_Should_Update_Product()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_PRODUCT_NAME = "New Product";
            const string NEW_PRODUCT_DESCRIPTION = "New Description";
            const string NEW_PRODUCT_FULL_PICTURE_URL = "Images/full_g9e8ryg89rygyg89rey.jpg";
            const string NEW_PRODUCT_PREVIEW_PICTURE_URL = "Images/preview_g9e8ryg89rygyg89rey.jpg";
            const string NEW_PRODUCT_VENDOR_SHOP_URL = "http://www.carters.com/carters/Surf-Sunglasses/V_24960,default,pd.html?dwvar_V__24960_color=Gray&cgid=carters-toddler-boy-swim-shop-sunglasses&start=";
            var createDate = ProductMockFactory.TheChildrensPlace_Girls_Shorts.CreateDate;
            var createdBy = ProductMockFactory.TheChildrensPlace_Girls_Shorts.CreatedBy;

            var brand = container.Get<IDtoService>().CreateBrand(BrandMockFactory.Carters);
            var subCategory = container.Get<IDtoService>().CreateSubCategory(SubCategoryMockFactory.Boys_2_5);

            var updatedProduct =
                new DTO.Product
                {
                    Id = ProductMockFactory.TheChildrensPlace_Girls_Shorts.Id,
                    Name = NEW_PRODUCT_NAME,
                    Active = true,
                    Description = NEW_PRODUCT_DESCRIPTION,
                    PreviewPictureURL = HttpServiceMockFactory.APPLICATION_URL + NEW_PRODUCT_PREVIEW_PICTURE_URL,
                    FullPictureURL = HttpServiceMockFactory.APPLICATION_URL + NEW_PRODUCT_FULL_PICTURE_URL,
                    VendorShopURL = NEW_PRODUCT_VENDOR_SHOP_URL,
                    Brand = brand,
                    SubCategory = subCategory
                };

            var productService = container.Get<IProductService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            productService.UpdateProduct(updatedProduct);

            // Assert
            var actualProduct = persistentService.GetEntityById<DataAccess.Product>(ProductMockFactory.TheChildrensPlace_Girls_Shorts.Id);

            Assert.AreEqual(NEW_PRODUCT_NAME, actualProduct.Name);
            Assert.IsTrue(actualProduct.Active);
            Assert.AreEqual(NEW_PRODUCT_DESCRIPTION, actualProduct.Description);
            Assert.AreEqual(NEW_PRODUCT_PREVIEW_PICTURE_URL, actualProduct.PreviewPictureURL);
            Assert.AreEqual(NEW_PRODUCT_FULL_PICTURE_URL, actualProduct.FullPictureURL);
            Assert.AreEqual(NEW_PRODUCT_VENDOR_SHOP_URL, actualProduct.VendorShopURL);
            Assert.AreEqual(SubCategoryMockFactory.Boys_2_5.Id, actualProduct.SubCategory.Id);
            Assert.AreEqual(SubCategoryMockFactory.Boys_2_5.Name, actualProduct.SubCategory.Name);
            Assert.AreEqual(SubCategoryMockFactory.Boys_2_5.Active, actualProduct.SubCategory.Active);
            Assert.AreEqual(BrandMockFactory.Carters.Id, actualProduct.Brand.Id);
            Assert.AreEqual(BrandMockFactory.Carters.Name, actualProduct.Brand.Name);
            Assert.AreEqual(BrandMockFactory.Carters.Active, actualProduct.Brand.Active);
            Assert.AreEqual(createDate, actualProduct.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualProduct.ChangeDate);
            Assert.AreEqual(createdBy, actualProduct.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualProduct.ChangedBy);

            Assert.AreEqual(updatedProduct, container.Get<IDtoService>().CreateProduct(actualProduct));
        }

        [TestMethod]
        public void UpdateProduct_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            const string NEW_PRODUCT_NAME = "New Product";
            const string NEW_PRODUCT_DESCRIPTION = "New Description";
            const string NEW_PRODUCT_FULL_PICTURE_URL = "Images/full_g9e8ryg89rygyg89rey.jpg";
            const string NEW_PRODUCT_PREVIEW_PICTURE_URL = "Images/preview_g9e8ryg89rygyg89rey.jpg";
            const string NEW_PRODUCT_VENDOR_SHOP_URL = "http://www.carters.com/carters/Surf-Sunglasses/V_24960,default,pd.html?dwvar_V__24960_color=Gray&cgid=carters-toddler-boy-swim-shop-sunglasses&start=";

            var brand = container.Get<IDtoService>().CreateBrand(BrandMockFactory.Carters);
            var subCategory = container.Get<IDtoService>().CreateSubCategory(SubCategoryMockFactory.Boys_2_5);

            var updatedProduct =
                new DTO.Product
                {
                    Id = ProductMockFactory.TheChildrensPlace_Girls_Shorts.Id,
                    Name = NEW_PRODUCT_NAME,
                    Active = true,
                    Description = NEW_PRODUCT_DESCRIPTION,
                    PreviewPictureURL = HttpServiceMockFactory.APPLICATION_URL + NEW_PRODUCT_PREVIEW_PICTURE_URL,
                    FullPictureURL = HttpServiceMockFactory.APPLICATION_URL + NEW_PRODUCT_FULL_PICTURE_URL,
                    VendorShopURL = NEW_PRODUCT_VENDOR_SHOP_URL,
                    Brand = brand,
                    SubCategory = subCategory
                };

            var productService = container.Get<IProductService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => productService.UpdateProduct(updatedProduct),
                "Only seller can change product.");
        }
    }
}
