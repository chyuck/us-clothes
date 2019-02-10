using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.Brand;
using USClothesWebSite.BusinessLogic.Dto;
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
    public class BrandServiceTest
    {
        [TestMethod]
        public void ActiveBrands_Should_Return_All_Active_Brands()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            container.Get<ISecurityService>().LogInGuest();

            var dtoService = container.Get<IDtoService>();
            var brandService = container.Get<IBrandService>();

            // Act
            var brands = brandService.ActiveBrands;

            // Assert
            var expectedBrands = 
                new[]
                {
                    dtoService.CreateBrand(BrandMockFactory.Carters),
                    dtoService.CreateBrand(BrandMockFactory.OshKosh),
                    dtoService.CreateBrand(BrandMockFactory.TheChildrensPlace)
                };

            CollectionAssert.AreEqual(expectedBrands, brands);
        }

        [TestMethod]
        public void ActiveBrands_Should_Return_Empty_Collection_When_User_Is_Not_Logged_In()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var brandService = container.Get<IBrandService>();

            // Act
            var brands = brandService.ActiveBrands;

            // Assert
            CollectionAssert.AreEqual(new DTO.Brand[] { }, brands);
        }

        [TestMethod]
        public void GetBrands_Should_Return_All_Brands_When_Filter_Is_Empty()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var brandService = container.Get<IBrandService>();

            // Act
            var brands = brandService.GetBrands(null);

            // Assert
            var expectedBrands =
                new[]
                {
                    dtoService.CreateBrand(BrandMockFactory.OshKosh),
                    dtoService.CreateBrand(BrandMockFactory.Carters),
                    dtoService.CreateBrand(BrandMockFactory.Crazy8),
                    dtoService.CreateBrand(BrandMockFactory.TheChildrensPlace)
                };

            CollectionAssert.AreEqual(expectedBrands, brands);
        }

        [TestMethod]
        public void GetBrands_Should_Return_Brands_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var brandService = container.Get<IBrandService>();

            // Act
            var brands = brandService.GetBrands("a");

            // Assert
            var expectedBrands =
                new[]
                {
                    dtoService.CreateBrand(BrandMockFactory.Carters),
                    dtoService.CreateBrand(BrandMockFactory.Crazy8),
                    dtoService.CreateBrand(BrandMockFactory.TheChildrensPlace)
                };

            CollectionAssert.AreEqual(expectedBrands, brands);
        }

        [TestMethod]
        public void GetBrands_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var brandService = container.Get<IBrandService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => brandService.GetBrands(null),
                "Only seller can get all brands.");
        }

        [TestMethod]
        public void CreateBrand_Should_Create_Brand()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_BRAND_NAME = "New Brand";

            var createdBrand =
                new DTO.Brand
                {
                    Name = NEW_BRAND_NAME,
                    Active = true
                };

            var brandService = container.Get<IBrandService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            brandService.CreateBrand(createdBrand);

            // Assert
            var actualBrand =
                persistentService
                    .GetEntitySet<DataAccess.Brand>()
                    .Single(b => b.Name == NEW_BRAND_NAME);

            Assert.IsTrue(actualBrand.Id > 0);
            Assert.AreEqual(NEW_BRAND_NAME, actualBrand.Name);
            Assert.IsTrue(actualBrand.Active);
            Assert.AreEqual(timeService.UtcNow, actualBrand.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualBrand.ChangeDate);
            Assert.AreEqual(UserMockFactory.Diana, actualBrand.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualBrand.ChangedBy);

            Assert.AreEqual(createdBrand, container.Get<IDtoService>().CreateBrand(actualBrand));
        }

        [TestMethod]
        public void CreateBrand_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var createdBrand =
                new DTO.Brand
                {
                    Name = "New Brand",
                    Active = true
                };

            var brandService = container.Get<IBrandService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => brandService.CreateBrand(createdBrand),
                "Only seller can create brand.");
        }

        [TestMethod]
        public void CreateBrand_Should_Throw_Exception_When_Brand_With_The_Same_Name_Already_Exists()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var createdBrand =
                new DTO.Brand
                {
                    Name = BrandMockFactory.Carters.Name,
                    Active = true
                };

            var brandService = container.Get<IBrandService>();

            // Act
            // Assert
            ExceptionAssert.Throw<BrandServiceException>(
                () => brandService.CreateBrand(createdBrand),
                "Бренд с заданным названием уже существует.");
        }

        [TestMethod]
        public void UpdateBrand_Should_Update_Brand()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_BRAND_NAME = "New Brand";
            var createDate = BrandMockFactory.Crazy8.CreateDate;
            var createdBy = BrandMockFactory.Crazy8.CreatedBy;

            var updatedBrand =
                new DTO.Brand
                {
                    Id = BrandMockFactory.Crazy8.Id,
                    Name = NEW_BRAND_NAME,
                    Active = true
                };
            
            var brandService = container.Get<IBrandService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            brandService.UpdateBrand(updatedBrand);

            // Assert
            var actualBrand = persistentService.GetEntityById<DataAccess.Brand>(BrandMockFactory.Crazy8.Id);

            Assert.AreEqual(NEW_BRAND_NAME, actualBrand.Name);
            Assert.IsTrue(actualBrand.Active);
            Assert.AreEqual(createDate, actualBrand.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualBrand.ChangeDate);
            Assert.AreEqual(createdBy, actualBrand.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualBrand.ChangedBy);

            Assert.AreEqual(updatedBrand, container.Get<IDtoService>().CreateBrand(actualBrand));
        }

        [TestMethod]
        public void UpdateBrand_Should_Update_Brand_When_Name_Is_Not_Changed()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var createDate = BrandMockFactory.Crazy8.CreateDate;
            var createdBy = BrandMockFactory.Crazy8.CreatedBy;
            var name = BrandMockFactory.Crazy8.Name;

            var updatedBrand =
                new DTO.Brand
                {
                    Id = BrandMockFactory.Crazy8.Id,
                    Name = BrandMockFactory.Crazy8.Name,
                    Active = true
                };

            var brandService = container.Get<IBrandService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            brandService.UpdateBrand(updatedBrand);

            // Assert
            var actualBrand = persistentService.GetEntityById<DataAccess.Brand>(BrandMockFactory.Crazy8.Id);

            Assert.AreEqual(name, actualBrand.Name);
            Assert.IsTrue(actualBrand.Active);
            Assert.AreEqual(createDate, actualBrand.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualBrand.ChangeDate);
            Assert.AreEqual(createdBy, actualBrand.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualBrand.ChangedBy);

            Assert.AreEqual(updatedBrand, container.Get<IDtoService>().CreateBrand(actualBrand));
        }

        [TestMethod]
        public void UpdateBrand_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var updatedBrand =
                new DTO.Brand
                {
                    Id = BrandMockFactory.Crazy8.Id,
                    Name = "New Brand",
                    Active = true
                };

            var brandService = container.Get<IBrandService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => brandService.UpdateBrand(updatedBrand),
                "Only seller can change brand.");
        }

        [TestMethod]
        public void UpdateBrand_Should_Throw_Exception_When_Brand_With_The_Same_Name_Already_Exists()
        {
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var updatedBrand =
                new DTO.Brand
                {
                    Id = BrandMockFactory.Crazy8.Id,
                    Name = BrandMockFactory.Carters.Name,
                    Active = true
                };

            var brandService = container.Get<IBrandService>();

            // Act
            // Assert
            ExceptionAssert.Throw<BrandServiceException>(
                () => brandService.UpdateBrand(updatedBrand),
                "Бренд с заданным названием уже существует.");
        }
    }
}
