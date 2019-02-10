using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.Category;
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
    public class CategoryServiceTest
    {
        [TestMethod]
        public void ActiveCategories_Should_Return_All_Active_Categories()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            container.Get<ISecurityService>().LogInGuest();

            var dtoService = container.Get<IDtoService>();
            var categoryService = container.Get<ICategoryService>();

            // Act
            var categories = categoryService.ActiveCategories;

            // Assert
            var expectedCategories = 
                new[]
                {
                    dtoService.CreateCategory(CategoryMockFactory.Children),
                    dtoService.CreateCategory(CategoryMockFactory.Women)
                };

            CollectionAssert.AreEqual(expectedCategories, categories);
        }

        [TestMethod]
        public void ActiveCategories_Should_Return_Empty_Collection_When_User_Is_Not_Logged_In()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var categoryService = container.Get<ICategoryService>();

            // Act
            var categories = categoryService.ActiveCategories;

            // Assert
            CollectionAssert.AreEqual(new DTO.Category[] { }, categories);
        }

        [TestMethod]
        public void GetCategories_Should_Return_All_Categories_When_Filter_Is_Empty()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var categoryService = container.Get<ICategoryService>();

            // Act
            var categories = categoryService.GetCategories(null);

            // Assert
            var expectedCategories =
                new[]
                {
                    dtoService.CreateCategory(CategoryMockFactory.Children),
                    dtoService.CreateCategory(CategoryMockFactory.Men),
                    dtoService.CreateCategory(CategoryMockFactory.Women)
                };

            CollectionAssert.AreEqual(expectedCategories, categories);
        }

        [TestMethod]
        public void GetCategories_Should_Return_Categories_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var categoryService = container.Get<ICategoryService>();

            // Act
            var categories = categoryService.GetCategories("ины");

            // Assert
            var expectedCategories =
                new[]
                {
                    dtoService.CreateCategory(CategoryMockFactory.Men),
                    dtoService.CreateCategory(CategoryMockFactory.Women)
                };

            CollectionAssert.AreEqual(expectedCategories, categories);
        }

        [TestMethod]
        public void GetCategories_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var categoryService = container.Get<ICategoryService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => categoryService.GetCategories(null),
                "Only seller can get all categories.");
        }
        
        [TestMethod]
        public void GetSubCategories_Should_Return_All_SubCategories_When_Filter_Is_Empty()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var categoryService = container.Get<ICategoryService>();

            // Act
            var subCategories = categoryService.GetSubCategories(null);

            // Assert
            var expectedSubCategories =
                new[]
                {
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Girls_0_2),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Girls_2_5),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Girls_5_12),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_0_2),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_2_5),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_5_12),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.ManAccessories),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.ManOuterwear),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.ManClothes),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.WomanAccessories),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.WomanOuterwear),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.WomanClothes)
                };

            CollectionAssert.AreEqual(expectedSubCategories, subCategories);
        }

        [TestMethod]
        public void GetSubCategories_Should_Return_SubCategories_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var categoryService = container.Get<ICategoryService>();

            // Act
            var subCategories = categoryService.GetSubCategories("очки");

            // Assert
            var expectedSubCategories =
                new[]
                {
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Girls_0_2),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Girls_2_5),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Girls_5_12)
                };

            CollectionAssert.AreEqual(expectedSubCategories, subCategories);
        }

        [TestMethod]
        public void GetSubCategories_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var categoryService = container.Get<ICategoryService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => categoryService.GetSubCategories(null),
                "Only seller can get all subcategories.");
        }

        [TestMethod]
        public void GetSubCategoriesByCategory_Should_Return_All_SubCategories_When_Filter_Is_Empty()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var categoryService = container.Get<ICategoryService>();

            var category = dtoService.CreateCategory(CategoryMockFactory.Children);

            // Act
            var subCategories = categoryService.GetSubCategories(category, null);

            // Assert
            var expectedSubCategories =
                new[]
                {
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Girls_0_2),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Girls_2_5),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Girls_5_12),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_0_2),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_2_5),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_5_12)
                };

            CollectionAssert.AreEqual(expectedSubCategories, subCategories);
        }

        [TestMethod]
        public void GetSubCategoriesByCategory_Should_Return_SubCategories_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var categoryService = container.Get<ICategoryService>();

            var category = dtoService.CreateCategory(CategoryMockFactory.Children);

            // Act
            var subCategories = categoryService.GetSubCategories(category, "0");

            // Assert
            var expectedSubCategories =
                new[]
                {
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Girls_0_2),
                    dtoService.CreateSubCategory(SubCategoryMockFactory.Boys_0_2)
                };

            CollectionAssert.AreEqual(expectedSubCategories, subCategories);
        }

        [TestMethod]
        public void GetSubCategoriesByCategory_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var categoryService = container.Get<ICategoryService>();

            var category = dtoService.CreateCategory(CategoryMockFactory.Children);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => categoryService.GetSubCategories(category, null),
                "Only seller can get all subcategories.");
        }
        
        [TestMethod]
        public void CreateCategory_Should_Create_Category()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_CATEGORY_NAME = "New Category";

            var createdCategory =
                new DTO.Category
                {
                    Name = NEW_CATEGORY_NAME,
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            categoryService.CreateCategory(createdCategory);

            // Assert
            var actualCategory =
                persistentService
                    .GetEntitySet<DataAccess.Category>()
                    .Single(c => c.Name == NEW_CATEGORY_NAME);

            Assert.IsTrue(actualCategory.Id > 0);
            Assert.AreEqual(NEW_CATEGORY_NAME, actualCategory.Name);
            Assert.IsTrue(actualCategory.Active);
            Assert.AreEqual(timeService.UtcNow, actualCategory.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualCategory.ChangeDate);
            Assert.AreEqual(UserMockFactory.Diana, actualCategory.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualCategory.ChangedBy);

            Assert.AreEqual(createdCategory, container.Get<IDtoService>().CreateCategory(actualCategory));
        }

        [TestMethod]
        public void CreateCategory_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var createdCategory =
                new DTO.Category
                {
                    Name = "New Category",
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => categoryService.CreateCategory(createdCategory),
                "Only seller can create category.");
        }

        [TestMethod]
        public void CreateCategory_Should_Throw_Exception_When_Category_With_The_Same_Name_Already_Exists()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var createdCategory =
                new DTO.Category
                {
                    Name = CategoryMockFactory.Women.Name,
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();

            // Act
            // Assert
            ExceptionAssert.Throw<CategoryServiceException>(
                () => categoryService.CreateCategory(createdCategory),
                "Категория с заданным названием уже существует.");
        }

        [TestMethod]
        public void CreateSubCategory_Should_Create_SubCategory()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_SUBCATEGORY_NAME = "New SubCategory";
            
            var createdSubCategory =
                new DTO.SubCategory
                {
                    Name = NEW_SUBCATEGORY_NAME,
                    Category = container.Get<IDtoService>().CreateCategory(CategoryMockFactory.Men),
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            categoryService.CreateSubCategory(createdSubCategory);

            // Assert
            var actualSubCategory =
                persistentService
                    .GetEntitySet<SubCategory>()
                    .Single(sc => sc.Name == NEW_SUBCATEGORY_NAME);

            Assert.IsTrue(actualSubCategory.Id > 0);
            Assert.AreEqual(NEW_SUBCATEGORY_NAME, actualSubCategory.Name);
            Assert.AreEqual(CategoryMockFactory.Men.Id, actualSubCategory.Category.Id);
            Assert.AreEqual(CategoryMockFactory.Men.Name, actualSubCategory.Category.Name);
            Assert.AreEqual(CategoryMockFactory.Men.Active, actualSubCategory.Category.Active);
            Assert.IsTrue(actualSubCategory.Active);
            Assert.AreEqual(timeService.UtcNow, actualSubCategory.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualSubCategory.ChangeDate);
            Assert.AreEqual(UserMockFactory.Diana, actualSubCategory.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualSubCategory.ChangedBy);

            Assert.AreEqual(createdSubCategory, container.Get<IDtoService>().CreateSubCategory(actualSubCategory));
        }

        [TestMethod]
        public void CreateSubCategory_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var createdSubCategory =
                new DTO.SubCategory
                {
                    Name = "New SubCategory",
                    Category = container.Get<IDtoService>().CreateCategory(CategoryMockFactory.Men),
                    Active = true

                };

            var categoryService = container.Get<ICategoryService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => categoryService.CreateSubCategory(createdSubCategory),
                "Only seller can create subcategory.");
        }

        [TestMethod]
        public void CreateSubCategory_Should_Throw_Exception_When_SubCategory_With_The_Same_Name_In_The_Same_Category_Already_Exists()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var createdSubCategory =
                new DTO.SubCategory
                {
                    Name = SubCategoryMockFactory.ManClothes.Name,
                    Category = container.Get<IDtoService>().CreateCategory(CategoryMockFactory.Men),
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();

            // Act
            // Assert
            ExceptionAssert.Throw<CategoryServiceException>(
                () => categoryService.CreateSubCategory(createdSubCategory),
                "Подкатегория с заданным названием уже существует в данной категории.");
        }

        [TestMethod]
        public void CreateSubCategory_Should_Create_SubCategory_When_SubCategory_With_The_Same_Name_In_Another_Category_Already_Exists()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var createdSubCategory =
                new DTO.SubCategory
                {
                    Name = SubCategoryMockFactory.Girls_5_12.Name,
                    Category = container.Get<IDtoService>().CreateCategory(CategoryMockFactory.Men),
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            categoryService.CreateSubCategory(createdSubCategory);

            // Assert
            var actualSubCategory =
                persistentService
                    .GetEntitySet<SubCategory>()
                    .Single(sc => 
                        sc.Name == SubCategoryMockFactory.Girls_5_12.Name && 
                        sc.CategoryId == CategoryMockFactory.Men.Id);

            Assert.IsTrue(actualSubCategory.Id > 0);
            Assert.AreEqual(SubCategoryMockFactory.Girls_5_12.Name, actualSubCategory.Name);
            Assert.AreEqual(CategoryMockFactory.Men.Id, actualSubCategory.Category.Id);
            Assert.AreEqual(CategoryMockFactory.Men.Name, actualSubCategory.Category.Name);
            Assert.AreEqual(CategoryMockFactory.Men.Active, actualSubCategory.Category.Active);
            Assert.IsTrue(actualSubCategory.Active);
            Assert.AreEqual(timeService.UtcNow, actualSubCategory.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualSubCategory.ChangeDate);
            Assert.AreEqual(UserMockFactory.Diana, actualSubCategory.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualSubCategory.ChangedBy);

            Assert.AreEqual(createdSubCategory, container.Get<IDtoService>().CreateSubCategory(actualSubCategory));
        }

        [TestMethod]
        public void UpdateCategory_Should_Update_Category()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_CATEGORY_NAME = "New Category";
            var createDate = CategoryMockFactory.Women.CreateDate;
            var createdBy = CategoryMockFactory.Women.CreatedBy;

            var updatedCategory =
                new DTO.Category
                {
                    Id = CategoryMockFactory.Women.Id,
                    Name = NEW_CATEGORY_NAME,
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            categoryService.UpdateCategory(updatedCategory);

            // Assert
            var actualCategory = persistentService.GetEntityById<DataAccess.Category>(CategoryMockFactory.Women.Id);

            Assert.AreEqual(NEW_CATEGORY_NAME, actualCategory.Name);
            Assert.IsTrue(actualCategory.Active);
            Assert.AreEqual(createDate, actualCategory.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualCategory.ChangeDate);
            Assert.AreEqual(createdBy, actualCategory.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualCategory.ChangedBy);

            Assert.AreEqual(updatedCategory, container.Get<IDtoService>().CreateCategory(actualCategory));
        }

        [TestMethod]
        public void UpdateCategory_Should_Update_Category_When_Name_Is_Not_Changed()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var name = CategoryMockFactory.Women.Name;
            var createDate = CategoryMockFactory.Women.CreateDate;
            var createdBy = CategoryMockFactory.Women.CreatedBy;
            
            var updatedCategory =
                new DTO.Category
                {
                    Id = CategoryMockFactory.Women.Id,
                    Name = CategoryMockFactory.Women.Name,
                    Active = false
                };

            var categoryService = container.Get<ICategoryService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            categoryService.UpdateCategory(updatedCategory);

            // Assert
            var actualCategory = persistentService.GetEntityById<DataAccess.Category>(CategoryMockFactory.Women.Id);

            Assert.AreEqual(name, actualCategory.Name);
            Assert.IsFalse(actualCategory.Active);
            Assert.AreEqual(createDate, actualCategory.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualCategory.ChangeDate);
            Assert.AreEqual(createdBy, actualCategory.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualCategory.ChangedBy);

            Assert.AreEqual(updatedCategory, container.Get<IDtoService>().CreateCategory(actualCategory));
        }

        [TestMethod]
        public void UpdateCategory_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var updatedCategory =
                new DTO.Category
                {
                    Id = BrandMockFactory.Crazy8.Id,
                    Name = "New Category",
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => categoryService.UpdateCategory(updatedCategory),
                "Only seller can change category.");
        }

        [TestMethod]
        public void UpdateCategory_Should_Throw_Exception_When_Category_With_The_Same_Name_Already_Exists()
        {
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var updatedCategory =
                new DTO.Category
                {
                    Id = CategoryMockFactory.Women.Id,
                    Name = CategoryMockFactory.Men.Name,
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();

            // Act
            // Assert
            ExceptionAssert.Throw<CategoryServiceException>(
                () => categoryService.UpdateCategory(updatedCategory),
                "Категория с заданным названием уже существует.");
        }

        [TestMethod]
        public void UpdateSubCategory_Should_Update_SubCategory()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            const string NEW_SUBCATEGORY_NAME = "New SubCategory";
            var createDate = SubCategoryMockFactory.Girls_5_12.CreateDate;
            var createdBy = SubCategoryMockFactory.Girls_5_12.CreatedBy;

            var updatedSubCategory =
                new DTO.SubCategory
                {
                    Id = SubCategoryMockFactory.Girls_5_12.Id,
                    Name = NEW_SUBCATEGORY_NAME,
                    Category = container.Get<IDtoService>().CreateCategory(CategoryMockFactory.Men),
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            categoryService.UpdateSubCategory(updatedSubCategory);

            // Assert
            var actualSubCategory = persistentService.GetEntityById<SubCategory>(SubCategoryMockFactory.Girls_5_12.Id);

            Assert.AreEqual(NEW_SUBCATEGORY_NAME, actualSubCategory.Name);
            Assert.AreEqual(CategoryMockFactory.Men.Id, actualSubCategory.Category.Id);
            Assert.AreEqual(CategoryMockFactory.Men.Name, actualSubCategory.Category.Name);
            Assert.AreEqual(CategoryMockFactory.Men.Active, actualSubCategory.Category.Active);
            Assert.IsTrue(actualSubCategory.Active);
            Assert.AreEqual(createDate, actualSubCategory.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualSubCategory.ChangeDate);
            Assert.AreEqual(createdBy, actualSubCategory.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualSubCategory.ChangedBy);

            Assert.AreEqual(updatedSubCategory, container.Get<IDtoService>().CreateSubCategory(actualSubCategory));
        }

        [TestMethod]
        public void UpdateSubCategory_Should_Update_SubCategory_When_Name_Is_Not_Changed()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var name = SubCategoryMockFactory.Girls_5_12.Name;
            var createDate = SubCategoryMockFactory.Girls_5_12.CreateDate;
            var createdBy = SubCategoryMockFactory.Girls_5_12.CreatedBy;

            var updatedSubCategory =
                new DTO.SubCategory
                {
                    Id = SubCategoryMockFactory.Girls_5_12.Id,
                    Name = SubCategoryMockFactory.Girls_5_12.Name,
                    Category = container.Get<IDtoService>().CreateCategory(CategoryMockFactory.Children),
                    Active = false
                };

            var categoryService = container.Get<ICategoryService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            categoryService.UpdateSubCategory(updatedSubCategory);

            // Assert
            var actualSubCategory = persistentService.GetEntityById<SubCategory>(SubCategoryMockFactory.Girls_5_12.Id);

            Assert.AreEqual(name, actualSubCategory.Name);
            Assert.AreEqual(CategoryMockFactory.Children.Id, actualSubCategory.Category.Id);
            Assert.AreEqual(CategoryMockFactory.Children.Name, actualSubCategory.Category.Name);
            Assert.AreEqual(CategoryMockFactory.Children.Active, actualSubCategory.Category.Active);
            Assert.IsFalse(actualSubCategory.Active);
            Assert.AreEqual(createDate, actualSubCategory.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualSubCategory.ChangeDate);
            Assert.AreEqual(createdBy, actualSubCategory.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualSubCategory.ChangedBy);

            Assert.AreEqual(updatedSubCategory, container.Get<IDtoService>().CreateSubCategory(actualSubCategory));
        }

        [TestMethod]
        public void UpdateSubCategory_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var updatedSubCategory =
                new DTO.SubCategory
                {
                    Id = SubCategoryMockFactory.Girls_5_12.Id,
                    Name = "New SubCategory",
                    Category = container.Get<IDtoService>().CreateCategory(CategoryMockFactory.Men),
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => categoryService.UpdateSubCategory(updatedSubCategory),
                "Only seller can change subcategory.");
        }

        [TestMethod]
        public void UpdateSubCategory_Should_Throw_Exception_When_SubCategory_With_The_Same_Name_In_The_Same_Category_Already_Exists()
        {
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var updatedSubCategory =
                new DTO.SubCategory
                {
                    Id = SubCategoryMockFactory.Girls_5_12.Id,
                    Name = SubCategoryMockFactory.Boys_2_5.Name,
                    Category = container.Get<IDtoService>().CreateCategory(CategoryMockFactory.Children),
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();

            // Act
            // Assert
            ExceptionAssert.Throw<CategoryServiceException>(
                () => categoryService.UpdateSubCategory(updatedSubCategory),
                "Подкатегория с заданным названием уже существует в данной категории.");
        }

        [TestMethod]
        public void UpdateSubCategory_Should_Create_SubCategory_When_SubCategory_With_The_Same_Name_In_Another_Category_Already_Exists()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var createDate = SubCategoryMockFactory.Girls_5_12.CreateDate;
            var createdBy = SubCategoryMockFactory.Girls_5_12.CreatedBy;

            var updatedSubCategory =
                new DTO.SubCategory
                {
                    Id = SubCategoryMockFactory.Girls_5_12.Id,
                    Name = SubCategoryMockFactory.ManAccessories.Name,
                    Category = container.Get<IDtoService>().CreateCategory(CategoryMockFactory.Children),
                    Active = true
                };

            var categoryService = container.Get<ICategoryService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            categoryService.UpdateSubCategory(updatedSubCategory);

            // Assert
            var actualSubCategory = persistentService.GetEntityById<SubCategory>(SubCategoryMockFactory.Girls_5_12.Id);

            Assert.AreEqual(SubCategoryMockFactory.ManAccessories.Name, actualSubCategory.Name);
            Assert.AreEqual(CategoryMockFactory.Children.Id, actualSubCategory.Category.Id);
            Assert.AreEqual(CategoryMockFactory.Children.Name, actualSubCategory.Category.Name);
            Assert.AreEqual(CategoryMockFactory.Children.Active, actualSubCategory.Category.Active);
            Assert.IsTrue(actualSubCategory.Active);
            Assert.AreEqual(createDate, actualSubCategory.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualSubCategory.ChangeDate);
            Assert.AreEqual(createdBy, actualSubCategory.CreatedBy);
            Assert.AreEqual(UserMockFactory.Diana, actualSubCategory.ChangedBy);

            Assert.AreEqual(updatedSubCategory, container.Get<IDtoService>().CreateSubCategory(actualSubCategory));
        }
    }
}
