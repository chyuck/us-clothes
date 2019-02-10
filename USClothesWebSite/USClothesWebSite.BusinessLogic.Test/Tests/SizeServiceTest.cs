using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.BusinessLogic.Size;
using USClothesWebSite.BusinessLogic.Test.Extensions;
using USClothesWebSite.BusinessLogic.Test.Mocks;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.DataAccess;
using USClothesWebSite.Test.Common;
using USClothesWebSite.BusinessLogic.Extensions;

namespace USClothesWebSite.BusinessLogic.Test
{
    [TestClass]
    public class SizeServiceTest
    {
        [TestMethod]
        public void GetActiveSizes_Should_Return_All_Active_Sizes_By_SubCategory_And_Brand()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            container.Get<ISecurityService>().LogInGuest();

            var dtoService = container.Get<IDtoService>();
            
            var subCategory = dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_0_2);
            var brand = dtoService.CreateBrand(BrandMockFactory.Carters);

            var sizeService = container.Get<ISizeService>();

            // Act
            var sizes = sizeService.GetActiveSizes(subCategory, brand);

            // Assert
            var expectedSizes =
                new[]
                {
                    dtoService.CreateSize(SizeMockFactory.Carters_Boys_0_2_3M),
                    dtoService.CreateSize(SizeMockFactory.Carters_Boys_0_2_6M)
                };

            CollectionAssert.AreEqual(expectedSizes, sizes);
        }

        [TestMethod]
        public void GetActiveSizes_Should_Throw_Exception_When_User_Is_Not_Logged_In()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var dtoService = container.Get<IDtoService>();

            var subCategory = dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_0_2);
            var brand = dtoService.CreateBrand(BrandMockFactory.Carters);

            var sizeService = container.Get<ISizeService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => sizeService.GetActiveSizes(subCategory, brand),
                "User is not logged in.");
        }
        
        [TestMethod]
        public void GetSizes_Should_Return_All_Sizes_When_Filter_Is_Empty()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var sizeService = container.Get<ISizeService>();

            // Act
            var sizes = sizeService.GetSizes(null);

            // Assert
            var expectedSizes =
                new[]
                {
                    dtoService.CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_Newborn),
                    dtoService.CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months),
                    dtoService.CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_3_6_Months),
                    dtoService.CreateSize(SizeMockFactory.TheChildrensPlace_Girls_0_2_Newborn),
                    dtoService.CreateSize(SizeMockFactory.TheChildrensPlace_Girls_0_2_0_3_Months),
                    dtoService.CreateSize(SizeMockFactory.TheChildrensPlace_Girls_0_2_3_6_Months),
                    dtoService.CreateSize(SizeMockFactory.Carters_Boys_0_2_3M),
                    dtoService.CreateSize(SizeMockFactory.Carters_Boys_0_2_6M),
                    dtoService.CreateSize(SizeMockFactory.Carters_Girls_0_2_3M),
                    dtoService.CreateSize(SizeMockFactory.Carters_Girls_0_2_6M)
                };

            CollectionAssert.AreEqual(expectedSizes, sizes);
        }

        [TestMethod]
        public void GetSizes_Should_Return_SubCategories_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var sizeService = container.Get<ISizeService>();

            // Act
            var sizes = sizeService.GetSizes("months");

            // Assert
            var expectedSizes =
                new[]
                {
                    dtoService.CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months),
                    dtoService.CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_3_6_Months),
                    dtoService.CreateSize(SizeMockFactory.TheChildrensPlace_Girls_0_2_0_3_Months),
                    dtoService.CreateSize(SizeMockFactory.TheChildrensPlace_Girls_0_2_3_6_Months)
                };

            CollectionAssert.AreEqual(expectedSizes, sizes);
        }

        [TestMethod]
        public void GetSizes_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var sizeService = container.Get<ISizeService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => sizeService.GetSizes(null),
                "Only seller can get all sizes.");
        }

        [TestMethod]
        public void GetSizesByBrandAndSubCategory_Should_Return_All_Sizes_When_Filter_Is_Empty()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var sizeService = container.Get<ISizeService>();

            var subCategory = dtoService.CreateSubCategory(SubCategoryMockFactory.Girls_0_2);
            var brand = dtoService.CreateBrand(BrandMockFactory.Carters);

            // Act
            var sizes = sizeService.GetSizes(subCategory, brand, null);

            // Assert
            var expectedSizes =
                new[]
                {
                    dtoService.CreateSize(SizeMockFactory.Carters_Girls_0_2_3M),
                    dtoService.CreateSize(SizeMockFactory.Carters_Girls_0_2_6M)
                };

            CollectionAssert.AreEqual(expectedSizes, sizes);
        }

        [TestMethod]
        public void GetSizesByBrandAndSubCategory_Should_Return_Sizes_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var sizeService = container.Get<ISizeService>();

            var subCategory = dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_0_2);
            var brand = dtoService.CreateBrand(BrandMockFactory.TheChildrensPlace);

            // Act
            var sizes = sizeService.GetSizes(subCategory, brand, "5");

            // Assert
            var expectedSizes =
                new[]
                {
                    dtoService.CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months),
                    dtoService.CreateSize(SizeMockFactory.TheChildrensPlace_Boys_0_2_3_6_Months)
                };

            CollectionAssert.AreEqual(expectedSizes, sizes);
        }

        [TestMethod]
        public void GetSizesByBrandAndSubCategory_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var sizeService = container.Get<ISizeService>();

            var subCategory = dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_0_2);
            var brand = dtoService.CreateBrand(BrandMockFactory.TheChildrensPlace);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => sizeService.GetSizes(subCategory, brand, null),
                "Only seller can get all sizes.");
        }
        
        [TestMethod]
        public void CreateSize_Should_Create_Size()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_SIZE_NAME = "New Size";
            const string NEW_SIZE_WEIGHT = "New Weight";
            const string NEW_SIZE_HEIGHT = "New Height";
            
            var createdSize =
                new DTO.Size
                {
                    Name = NEW_SIZE_NAME,
                    Brand = container.Get<IDtoService>().CreateBrand(BrandMockFactory.TheChildrensPlace),
                    SubCategory = container.Get<IDtoService>().CreateSubCategory(SubCategoryMockFactory.Boys_0_2),
                    Weight = NEW_SIZE_WEIGHT,
                    Height = NEW_SIZE_HEIGHT,
                    Active = true
                };

            var sizeService = container.Get<ISizeService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            sizeService.CreateSize(createdSize);

            // Assert
            var actualSize =
                persistentService
                    .GetEntitySet<DataAccess.Size>()
                    .Single(s => s.Name == NEW_SIZE_NAME);

            Assert.IsTrue(actualSize.Id > 0);
            Assert.AreEqual(NEW_SIZE_NAME, actualSize.Name);
            Assert.AreEqual(SubCategoryMockFactory.Boys_0_2.Id, actualSize.SubCategory.Id);
            Assert.AreEqual(SubCategoryMockFactory.Boys_0_2.Name, actualSize.SubCategory.Name);
            Assert.AreEqual(SubCategoryMockFactory.Boys_0_2.Active, actualSize.SubCategory.Active);
            Assert.AreEqual(BrandMockFactory.TheChildrensPlace.Id, actualSize.Brand.Id);
            Assert.AreEqual(BrandMockFactory.TheChildrensPlace.Name, actualSize.Brand.Name);
            Assert.AreEqual(BrandMockFactory.TheChildrensPlace.Active, actualSize.Brand.Active);
            Assert.AreEqual(NEW_SIZE_WEIGHT, actualSize.Weight);
            Assert.AreEqual(NEW_SIZE_HEIGHT, actualSize.Height);
            Assert.IsTrue(actualSize.Active);
            Assert.AreEqual(timeService.UtcNow, actualSize.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualSize.ChangeDate);
            Assert.AreEqual(UserMockFactory.Diana, actualSize.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualSize.ChangedBy);

            Assert.AreEqual(createdSize, container.Get<IDtoService>().CreateSize(actualSize));
        }
        
        [TestMethod]
        public void CreateSize_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var createdSize =
               new DTO.Size
               {
                   Name = "New Size",
                   Brand = container.Get<IDtoService>().CreateBrand(BrandMockFactory.TheChildrensPlace),
                   SubCategory = container.Get<IDtoService>().CreateSubCategory(SubCategoryMockFactory.Boys_0_2),
                   Weight = "New Weight",
                   Height = "New Height",
                   Active = true
               };

            var sizeService = container.Get<ISizeService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => sizeService.CreateSize(createdSize),
                "Only seller can create size.");
        }
        
        [TestMethod]
        public void CreateSize_Should_Throw_Exception_When_Size_With_The_Same_Name_Brand_SubCategory_Already_Exists()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var createdSize =
               new DTO.Size
               {
                   Name = SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months.Name,
                   Brand = container.Get<IDtoService>().CreateBrand(SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months.Brand),
                   SubCategory = container.Get<IDtoService>().CreateSubCategory(SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months.SubCategory),
                   Weight = "New Weight",
                   Height = "New Height",
                   Active = true
               };

            var sizeService = container.Get<ISizeService>();

            // Act
            // Assert
            ExceptionAssert.Throw<SizeServiceException>(
                () => sizeService.CreateSize(createdSize),
                "Размер с заданным названием уже существует для данной подкатегории и данного бренда.");
        }

        [TestMethod]
        public void CreateSize_Should_Create_Size_When_Size_With_The_Same_Name_But_In_Other_SubCategory_And_Brand_Already_Exists()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_SIZE_WEIGHT = "New Weight";
            const string NEW_SIZE_HEIGHT = "New Height";

            var createdSize =
               new DTO.Size
               {
                   Name = SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months.Name,
                   SubCategory = container.Get<IDtoService>().CreateSubCategory(SubCategoryMockFactory.Boys_2_5),
                   Brand = container.Get<IDtoService>().CreateBrand(BrandMockFactory.Carters),
                   Weight = NEW_SIZE_WEIGHT,
                   Height = NEW_SIZE_HEIGHT,
                   Active = true
               };

            var sizeService = container.Get<ISizeService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            sizeService.CreateSize(createdSize);

            // Assert
            var actualSize =
                persistentService
                    .GetEntitySet<DataAccess.Size>()
                    .Single(s => 
                        s.Name == SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months.Name &&
                        s.SubCategoryId == SubCategoryMockFactory.Boys_2_5.Id &&
                        s.BrandId == BrandMockFactory.Carters.Id);

            Assert.IsTrue(actualSize.Id > 0);
            Assert.AreEqual(SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months.Name, actualSize.Name);
            Assert.AreEqual(SubCategoryMockFactory.Boys_2_5.Id, actualSize.SubCategory.Id);
            Assert.AreEqual(SubCategoryMockFactory.Boys_2_5.Name, actualSize.SubCategory.Name);
            Assert.AreEqual(SubCategoryMockFactory.Boys_2_5.Active, actualSize.SubCategory.Active);
            Assert.AreEqual(BrandMockFactory.Carters.Id, actualSize.Brand.Id);
            Assert.AreEqual(BrandMockFactory.Carters.Name, actualSize.Brand.Name);
            Assert.AreEqual(BrandMockFactory.Carters.Active, actualSize.Brand.Active);
            Assert.AreEqual(NEW_SIZE_WEIGHT, actualSize.Weight);
            Assert.AreEqual(NEW_SIZE_HEIGHT, actualSize.Height);
            Assert.IsTrue(actualSize.Active);
            Assert.AreEqual(timeService.UtcNow, actualSize.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualSize.ChangeDate);
            Assert.AreEqual(UserMockFactory.Diana, actualSize.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualSize.ChangedBy);

            Assert.AreEqual(createdSize, container.Get<IDtoService>().CreateSize(actualSize));
        }

        [TestMethod]
        public void UpdateSize_Should_Update_Size()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_SIZE_NAME = "New Size";
            const string NEW_SIZE_WEIGHT = "New Weight";
            const string NEW_SIZE_HEIGHT = "New Height";
            var createDate = SizeMockFactory.Carters_Boys_0_2_3M.CreateDate;
            var createdBy = SizeMockFactory.Carters_Boys_0_2_3M.CreatedBy;

            var updatedSize =
                new DTO.Size
                {
                    Id = SizeMockFactory.Carters_Boys_0_2_3M.Id,
                    Name = NEW_SIZE_NAME,
                    SubCategory = container.Get<IDtoService>().CreateSubCategory(SubCategoryMockFactory.Girls_0_2),
                    Brand = container.Get<IDtoService>().CreateBrand(BrandMockFactory.Crazy8),
                    Weight = NEW_SIZE_WEIGHT,
                    Height = NEW_SIZE_HEIGHT,
                    Active = true
                };

            var sizeService = container.Get<ISizeService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            sizeService.UpdateSize(updatedSize);

            // Assert
            var actualSize = persistentService.GetEntityById<DataAccess.Size>(SizeMockFactory.Carters_Boys_0_2_3M.Id);

            Assert.AreEqual(actualSize.Id, SizeMockFactory.Carters_Boys_0_2_3M.Id);
            Assert.AreEqual(NEW_SIZE_NAME, actualSize.Name);
            Assert.AreEqual(SubCategoryMockFactory.Girls_0_2.Id, actualSize.SubCategory.Id);
            Assert.AreEqual(SubCategoryMockFactory.Girls_0_2.Name, actualSize.SubCategory.Name);
            Assert.AreEqual(SubCategoryMockFactory.Girls_0_2.Active, actualSize.SubCategory.Active);
            Assert.AreEqual(BrandMockFactory.Crazy8.Id, actualSize.Brand.Id);
            Assert.AreEqual(BrandMockFactory.Crazy8.Name, actualSize.Brand.Name);
            Assert.AreEqual(BrandMockFactory.Crazy8.Active, actualSize.Brand.Active);
            Assert.AreEqual(NEW_SIZE_WEIGHT, actualSize.Weight);
            Assert.AreEqual(NEW_SIZE_HEIGHT, actualSize.Height);
            Assert.IsTrue(actualSize.Active);
            Assert.AreEqual(createDate, actualSize.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualSize.ChangeDate);
            Assert.AreEqual(createdBy, actualSize.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualSize.ChangedBy);

            Assert.AreEqual(updatedSize, container.Get<IDtoService>().CreateSize(actualSize));
        }
        
        [TestMethod]
        public void UpdateSize_Should_Update_Size_When_Name_SubCategory_Brand_Are_Not_Changed()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_SIZE_WEIGHT = "New Weight";
            const string NEW_SIZE_HEIGHT = "New Height";
            var createDate = SizeMockFactory.Carters_Boys_0_2_3M.CreateDate;
            var createdBy = SizeMockFactory.Carters_Boys_0_2_3M.CreatedBy;
            var name = SizeMockFactory.Carters_Boys_0_2_3M.Name;

            var updatedSize =
                new DTO.Size
                {
                    Id = SizeMockFactory.Carters_Boys_0_2_3M.Id,
                    Name = name,
                    SubCategory = container.Get<IDtoService>().CreateSubCategory(SizeMockFactory.Carters_Boys_0_2_3M.SubCategory),
                    Brand = container.Get<IDtoService>().CreateBrand(SizeMockFactory.Carters_Boys_0_2_3M.Brand),
                    Weight = NEW_SIZE_WEIGHT,
                    Height = NEW_SIZE_HEIGHT,
                    Active = false
                };

            var sizeService = container.Get<ISizeService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            sizeService.UpdateSize(updatedSize);

            // Assert
            var actualSize = persistentService.GetEntityById<DataAccess.Size>(SizeMockFactory.Carters_Boys_0_2_3M.Id);

            Assert.AreEqual(actualSize.Id, SizeMockFactory.Carters_Boys_0_2_3M.Id);
            Assert.AreEqual(name, actualSize.Name);
            Assert.AreEqual(SubCategoryMockFactory.Boys_0_2.Id, actualSize.SubCategory.Id);
            Assert.AreEqual(SubCategoryMockFactory.Boys_0_2.Name, actualSize.SubCategory.Name);
            Assert.AreEqual(SubCategoryMockFactory.Boys_0_2.Active, actualSize.SubCategory.Active);
            Assert.AreEqual(BrandMockFactory.Carters.Id, actualSize.Brand.Id);
            Assert.AreEqual(BrandMockFactory.Carters.Name, actualSize.Brand.Name);
            Assert.AreEqual(BrandMockFactory.Carters.Active, actualSize.Brand.Active);
            Assert.AreEqual(NEW_SIZE_WEIGHT, actualSize.Weight);
            Assert.AreEqual(NEW_SIZE_HEIGHT, actualSize.Height);
            Assert.IsFalse(actualSize.Active);
            Assert.AreEqual(createDate, actualSize.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualSize.ChangeDate);
            Assert.AreEqual(createdBy, actualSize.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualSize.ChangedBy);

            Assert.AreEqual(updatedSize, container.Get<IDtoService>().CreateSize(actualSize));
        }
        
        [TestMethod]
        public void UpdateSize_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var updatedSize =
                new DTO.Size
                {
                    Id = SizeMockFactory.Carters_Boys_0_2_3M.Id,
                    Name = "New Size",
                    SubCategory = container.Get<IDtoService>().CreateSubCategory(SubCategoryMockFactory.Girls_0_2),
                    Brand = container.Get<IDtoService>().CreateBrand(BrandMockFactory.Crazy8),
                    Weight = "New Weight",
                    Height = "New Height",
                    Active = true
                };

            var sizeService = container.Get<ISizeService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => sizeService.UpdateSize(updatedSize),
                "Only seller can change size.");
        }
        
        [TestMethod]
        public void UpdateSize_Should_Throw_Exception_When_Size_With_The_Same_Name_Brand_SubCategory_Already_Exists()
        {
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var updatedSize =
                new DTO.Size
                {
                    Id = SizeMockFactory.Carters_Boys_0_2_3M.Id,
                    Name = SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months.Name,
                    Brand = container.Get<IDtoService>().CreateBrand(SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months.Brand),
                    SubCategory = container.Get<IDtoService>().CreateSubCategory(SizeMockFactory.TheChildrensPlace_Boys_0_2_0_3_Months.SubCategory),
                    Weight = "New Weight",
                    Height = "New Height",
                    Active = true
                };

            var sizeService = container.Get<ISizeService>();

            // Act
            // Assert
            ExceptionAssert.Throw<SizeServiceException>(
                () => sizeService.UpdateSize(updatedSize),
                "Размер с заданным названием уже существует для данной подкатегории и данного бренда.");
        }

        [TestMethod]
        public void UpdateSize_Should_Update_Size_When_Size_With_The_Same_Name_But_In_Other_SubCategory_And_Brand_Already_Exists()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_SIZE_WEIGHT = "New Weight";
            const string NEW_SIZE_HEIGHT = "New Height";
            var createDate = SizeMockFactory.Carters_Boys_0_2_3M.CreateDate;
            var createdBy = SizeMockFactory.Carters_Boys_0_2_3M.CreatedBy;
            var name = SizeMockFactory.TheChildrensPlace_Girls_0_2_3_6_Months.Name;
            
            var updatedSize =
                new DTO.Size
                {
                    Id = SizeMockFactory.Carters_Boys_0_2_3M.Id,
                    Name = name,
                    SubCategory = container.Get<IDtoService>().CreateSubCategory(SizeMockFactory.Carters_Boys_0_2_3M.SubCategory),
                    Brand = container.Get<IDtoService>().CreateBrand(SizeMockFactory.Carters_Boys_0_2_3M.Brand),
                    Weight = NEW_SIZE_WEIGHT,
                    Height = NEW_SIZE_HEIGHT,
                    Active = true
                };

            var sizeService = container.Get<ISizeService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            sizeService.UpdateSize(updatedSize);

            // Assert
            var actualSize = persistentService.GetEntityById<DataAccess.Size>(SizeMockFactory.Carters_Boys_0_2_3M.Id);

            Assert.AreEqual(actualSize.Id, SizeMockFactory.Carters_Boys_0_2_3M.Id);
            Assert.AreEqual(name, actualSize.Name);
            Assert.AreEqual(SubCategoryMockFactory.Boys_0_2.Id, actualSize.SubCategory.Id);
            Assert.AreEqual(SubCategoryMockFactory.Boys_0_2.Name, actualSize.SubCategory.Name);
            Assert.AreEqual(SubCategoryMockFactory.Boys_0_2.Active, actualSize.SubCategory.Active);
            Assert.AreEqual(BrandMockFactory.Carters.Id, actualSize.Brand.Id);
            Assert.AreEqual(BrandMockFactory.Carters.Name, actualSize.Brand.Name);
            Assert.AreEqual(BrandMockFactory.Carters.Active, actualSize.Brand.Active);
            Assert.AreEqual(NEW_SIZE_WEIGHT, actualSize.Weight);
            Assert.AreEqual(NEW_SIZE_HEIGHT, actualSize.Height);
            Assert.IsTrue(actualSize.Active);
            Assert.AreEqual(createDate, actualSize.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualSize.ChangeDate);
            Assert.AreEqual(createdBy, actualSize.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualSize.ChangedBy);

            Assert.AreEqual(updatedSize, container.Get<IDtoService>().CreateSize(actualSize));
        }
    }
}
