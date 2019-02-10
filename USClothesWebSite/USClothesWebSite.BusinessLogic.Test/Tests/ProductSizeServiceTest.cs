using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.ProductSize;
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
    public class ProductSizeServiceTest
    {
        [TestMethod]
        public void GetProductSizesByProduct_Should_Return_All_ProductSizes_When_Filter_Is_Empty()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var productSizeService = container.Get<IProductSizeService>();

            var product = dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Girls_Sweater);

            // Act
            var productSizes = productSizeService.GetProductSizes(product, null);
            
            // Assert
            var expectedProductSizes =
                new[]
                {
                    dtoService.CreateProductSize(ProductSizeMockFactory.Girls_Sweater_0_3_Months),
                    dtoService.CreateProductSize(ProductSizeMockFactory.Girls_Sweater_3_6_Months)
                };

            CollectionAssert.AreEqual(expectedProductSizes, productSizes);
        }

        [TestMethod]
        public void GetProductSizesByProduct_Should_Return_ProductSizes_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var productSizeService = container.Get<IProductSizeService>();

            var product = dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Girls_Sweater);

            // Act
            var productSizes = productSizeService.GetProductSizes(product, "6");

            // Assert
            var expectedProductSizes =
                new[]
                {
                    dtoService.CreateProductSize(ProductSizeMockFactory.Girls_Sweater_3_6_Months)
                };

            CollectionAssert.AreEqual(expectedProductSizes, productSizes);
        }

        [TestMethod]
        public void GetProductSizesByProduct_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var productSizeService = container.Get<IProductSizeService>();

            var product = dtoService.CreateProduct(ProductMockFactory.TheChildrensPlace_Girls_Sweater);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => productSizeService.GetProductSizes(product, null),
                "Only seller can get all product sizes.");
        }

        [TestMethod]
        public void GetProductSizes_Should_Return_All_ProductSizes_When_Filter_Is_Empty()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var productSizeService = container.Get<IProductSizeService>();

            // Act
            var productSizes = productSizeService.GetProductSizes(null);

            // Assert
            var expectedProductSizes =
                new[]
                {
                    dtoService.CreateProductSize(ProductSizeMockFactory.Girls_Sweater_0_3_Months),
                    dtoService.CreateProductSize(ProductSizeMockFactory.Girls_Sweater_3_6_Months),
                    dtoService.CreateProductSize(ProductSizeMockFactory.Boys_Sweater_0_3_Months),
                    dtoService.CreateProductSize(ProductSizeMockFactory.Boys_Sweater_3_6_Months)
                };

            CollectionAssert.AreEqual(expectedProductSizes, productSizes);
        }

        [TestMethod]
        public void GetProductSizes_Should_Return_ProductSizes_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var productSizeService = container.Get<IProductSizeService>();

            // Act
            var productSizes = productSizeService.GetProductSizes("6");

            // Assert
            var expectedProductSizes =
                new[]
                {
                    dtoService.CreateProductSize(ProductSizeMockFactory.Girls_Sweater_3_6_Months),
                    dtoService.CreateProductSize(ProductSizeMockFactory.Boys_Sweater_3_6_Months)
                };

            CollectionAssert.AreEqual(expectedProductSizes, productSizes);
        }

        [TestMethod]
        public void GetProductSizes_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var productSizeService = container.Get<IProductSizeService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => productSizeService.GetProductSizes(null),
                "Only seller can get all product sizes.");
        }

        [TestMethod]
        public void CreateProductSize_Should_Create_ProductSize()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var size = container.Get<IDtoService>().CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_Newborn);
            var product = container.Get<IDtoService>().CreateProduct(ProductMockFactory.TheChildrensPlace_Boys_TShirt);

            const decimal NEW_PRODUCT_SIZE_PRICE = 1200;

            var createdProductSize =
                new DTO.ProductSize
                {
                    Size = size,
                    Product = product,
                    Active = true,
                    Price = NEW_PRODUCT_SIZE_PRICE
                };

            var productSizeService = container.Get<IProductSizeService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            productSizeService.CreateProductSize(createdProductSize);

            // Assert
            Assert.IsTrue(createdProductSize.Id > 0);

            var actualProductSize =
                persistentService
                    .GetEntitySet<DataAccess.ProductSize>()
                    .Single(ps => ps.Id == createdProductSize.Id);

            Assert.IsTrue(actualProductSize.Active);
            Assert.AreEqual(NEW_PRODUCT_SIZE_PRICE, actualProductSize.Price);
            Assert.AreEqual(SizeMockFactory.TheChildrensPlace_Boys_0_2_Newborn.Id, actualProductSize.Size.Id);
            Assert.AreEqual(SizeMockFactory.TheChildrensPlace_Boys_0_2_Newborn.Name, actualProductSize.Size.Name);
            Assert.AreEqual(SizeMockFactory.TheChildrensPlace_Boys_0_2_Newborn.Active, actualProductSize.Size.Active);
            Assert.AreEqual(ProductMockFactory.TheChildrensPlace_Boys_TShirt.Id, actualProductSize.Product.Id);
            Assert.AreEqual(ProductMockFactory.TheChildrensPlace_Boys_TShirt.Name, actualProductSize.Product.Name);
            Assert.AreEqual(ProductMockFactory.TheChildrensPlace_Boys_TShirt.Description, actualProductSize.Product.Description);
            Assert.AreEqual(ProductMockFactory.TheChildrensPlace_Boys_TShirt.Active, actualProductSize.Product.Active);
            Assert.AreEqual(timeService.UtcNow, actualProductSize.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualProductSize.ChangeDate);
            Assert.AreEqual(UserMockFactory.Diana, actualProductSize.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualProductSize.ChangedBy);

            Assert.AreEqual(createdProductSize, container.Get<IDtoService>().CreateProductSize(actualProductSize));
        }

        [TestMethod]
        public void CreateProductSize_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var size = container.Get<IDtoService>().CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_Newborn);
            var product = container.Get<IDtoService>().CreateProduct(ProductMockFactory.TheChildrensPlace_Boys_TShirt);

            const decimal NEW_PRODUCT_SIZE_PRICE = 1200;

            var createdProductSize =
                new DTO.ProductSize
                {
                    Size = size,
                    Product = product,
                    Active = true,
                    Price = NEW_PRODUCT_SIZE_PRICE
                };

            var productSizeService = container.Get<IProductSizeService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => productSizeService.CreateProductSize(createdProductSize),
                "Only seller can create product size.");
        }

        [TestMethod]
        public void CreateProductSize_Should_Throw_Exception_When_ProductSize_With_The_Same_Product_Size_Already_Exists()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var size = container.Get<IDtoService>().CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months);
            var product = container.Get<IDtoService>().CreateProduct(ProductMockFactory.TheChildrensPlace_Boys_Sweater);

            const decimal NEW_PRODUCT_SIZE_PRICE = 1200;

            var createdProductSize =
                new DTO.ProductSize
                {
                    Size = size,
                    Product = product,
                    Active = true,
                    Price = NEW_PRODUCT_SIZE_PRICE
                };

            var productSizeService = container.Get<IProductSizeService>();

            // Act
            // Assert
            ExceptionAssert.Throw<ProductSizeServiceException>(
                () => productSizeService.CreateProductSize(createdProductSize),
                "Размер товара с заданным размером уже существует для данного товара.");
        }

        [TestMethod]
        public void UpdateProductSize_Should_Update_ProductSize()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var size = container.Get<IDtoService>().CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_Newborn);
            var product = container.Get<IDtoService>().CreateProduct(ProductMockFactory.TheChildrensPlace_Boys_TShirt);

            const decimal NEW_PRODUCT_SIZE_PRICE = 1200;
            var createDate = ProductSizeMockFactory.Boys_Sweater_0_3_Months.CreateDate;
            var createdBy = ProductSizeMockFactory.Boys_Sweater_0_3_Months.CreatedBy;

            var updatedProductSize =
                new DTO.ProductSize
                {
                    Id = ProductSizeMockFactory.Boys_Sweater_0_3_Months.Id,
                    Size = size,
                    Product = product,
                    Active = false,
                    Price = NEW_PRODUCT_SIZE_PRICE
                };

            var productSizeService = container.Get<IProductSizeService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            productSizeService.UpdateProductSize(updatedProductSize);

            // Assert
            var actualProductSize = persistentService.GetEntityById<DataAccess.ProductSize>(ProductSizeMockFactory.Boys_Sweater_0_3_Months.Id);

            Assert.IsFalse(actualProductSize.Active);
            Assert.AreEqual(NEW_PRODUCT_SIZE_PRICE, actualProductSize.Price);
            Assert.AreEqual(SizeMockFactory.TheChildrensPlace_Boys_0_2_Newborn.Id, actualProductSize.Size.Id);
            Assert.AreEqual(SizeMockFactory.TheChildrensPlace_Boys_0_2_Newborn.Name, actualProductSize.Size.Name);
            Assert.AreEqual(SizeMockFactory.TheChildrensPlace_Boys_0_2_Newborn.Active, actualProductSize.Size.Active);
            Assert.AreEqual(ProductMockFactory.TheChildrensPlace_Boys_TShirt.Id, actualProductSize.Product.Id);
            Assert.AreEqual(ProductMockFactory.TheChildrensPlace_Boys_TShirt.Name, actualProductSize.Product.Name);
            Assert.AreEqual(ProductMockFactory.TheChildrensPlace_Boys_TShirt.Description, actualProductSize.Product.Description);
            Assert.AreEqual(ProductMockFactory.TheChildrensPlace_Boys_TShirt.Active, actualProductSize.Product.Active);
            Assert.AreEqual(createDate, actualProductSize.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualProductSize.ChangeDate);
            Assert.AreEqual(createdBy, actualProductSize.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualProductSize.ChangedBy);

            Assert.AreEqual(updatedProductSize, container.Get<IDtoService>().CreateProductSize(actualProductSize));
        }

        [TestMethod]
        public void UpdateProductSize_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var size = container.Get<IDtoService>().CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_Newborn);
            var product = container.Get<IDtoService>().CreateProduct(ProductMockFactory.TheChildrensPlace_Boys_TShirt);

            const decimal NEW_PRODUCT_SIZE_PRICE = 1200;

            var updatedProductSize =
                new DTO.ProductSize
                {
                    Id = ProductSizeMockFactory.Boys_Sweater_0_3_Months.Id,
                    Size = size,
                    Product = product,
                    Active = false,
                    Price = NEW_PRODUCT_SIZE_PRICE
                };

            var productSizeService = container.Get<IProductSizeService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => productSizeService.UpdateProductSize(updatedProductSize),
                "Only seller can change product size.");
        }

        [TestMethod]
        public void UpdateProductSize_Should_Throw_Exception_When_ProductSize_With_The_Same_Product_Size_Already_Exists()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var size = container.Get<IDtoService>().CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months);
            var product = container.Get<IDtoService>().CreateProduct(ProductMockFactory.TheChildrensPlace_Boys_Sweater);

            const decimal NEW_PRODUCT_SIZE_PRICE = 1200;

            var updatedProductSize =
                new DTO.ProductSize
                {
                    Id = ProductSizeMockFactory.Girls_Sweater_0_3_Months.Id,
                    Size = size,
                    Product = product,
                    Active = true,
                    Price = NEW_PRODUCT_SIZE_PRICE
                };

            var productSizeService = container.Get<IProductSizeService>();

            // Act
            // Assert
            ExceptionAssert.Throw<ProductSizeServiceException>(
                () => productSizeService.UpdateProductSize(updatedProductSize),
                "Размер товара с заданным размером уже существует для данного товара.");
        }
    }
}
