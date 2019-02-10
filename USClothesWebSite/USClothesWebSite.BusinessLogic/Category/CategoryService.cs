using System.Linq;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Category
{
    internal class CategoryService : BaseService, ICategoryService
    {
        #region Constructors

        [Inject]
        public CategoryService(IReadOnlyContainer container)
            : base(container)
        {
        }

        #endregion


        #region Properties

        private ISecurityService SecurityService
        {
            get { return Container.Get<ISecurityService>(); }
        }

        #endregion


        #region ICategoryService

        public DTO.Category[] ActiveCategories 
        {
            get
            {
                if (!Container.Get<ISecurityService>().IsLoggedIn)
                    return new DTO.Category[] { };

                var dtoService = Container.Get<IDtoService>();

                var persistentService = Container.Get<IPersistentService>();
                 
                return
                    persistentService
                        .GetActiveEntities<DataAccess.Category>()
                        .OrderBy(c => c.Name)
                        .AsEnumerable()
                        .Select(c => dtoService.CreateCategory(c))
                        .ToArray();
            }
        }

        public DTO.Category[] GetCategories(string filter)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can get all categories.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.Category>()
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(c => c.Name.Contains(filter));

            var dtoService = Container.Get<IDtoService>();

            return
                query
                    .OrderBy(c => c.Id)
                    .ToArray()
                    .Select(c => dtoService.CreateCategory(c, false))
                    .ToArray();
        }

        public DTO.SubCategory[] GetSubCategories(DTO.Category category, string filter)
        {
            CheckHelper.ArgumentNotNull(category, "category");
            CheckHelper.ArgumentWithinCondition(!category.IsNew(), "!category.IsNew()");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can get all subcategories.");
            
            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<SubCategory>()
                    .Where(sc => sc.CategoryId == category.Id)
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(sc => sc.Name.Contains(filter));

            var dtoService = Container.Get<IDtoService>();

            return
                query
                    .OrderBy(sc => sc.Id)
                    .ToArray()
                    .Select(sc => dtoService.CreateSubCategory(sc, false))
                    .ToArray();
        }

        public DTO.SubCategory[] GetSubCategories(string filter)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can get all subcategories.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<SubCategory>()
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
                query = 
                    query
                        .Where(sc => 
                            sc.Name.Contains(filter) ||
                            sc.Category.Name.Contains(filter));

            var dtoService = Container.Get<IDtoService>();

            return
                query
                    .OrderBy(sc => sc.Id)
                    .ToArray()
                    .Select(sc => dtoService.CreateSubCategory(sc, false))
                    .ToArray();
        }

        public void CreateCategory(DTO.Category createdCategory)
        {
            CheckHelper.ArgumentNotNull(createdCategory, "createdCategory");
            CheckHelper.ArgumentWithinCondition(createdCategory.IsNew(), "Category is not new.");
            Container.Get<IValidateService>().CheckIsValid(createdCategory);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can create category.");

            var persistentService = Container.Get<IPersistentService>();

            var doesAnotherCategoryWithTheSameNameExist =
                    persistentService
                        .GetEntitySet<DataAccess.Category>()
                        .Any(c => c.Name == createdCategory.Name);

            if (doesAnotherCategoryWithTheSameNameExist)
                throw new CategoryServiceException("Категория с заданным названием уже существует.");

            var category =
                new DataAccess.Category
                {
                    Name = createdCategory.Name,
                    Active = createdCategory.Active
                };
            category.UpdateTrackFields(Container);
            persistentService.Add(category);

            persistentService.SaveChanges();

            createdCategory.Id = category.Id;
            createdCategory.CreateDate = category.CreateDate;
            createdCategory.CreateUser = category.CreatedBy.GetFullName();
            createdCategory.ChangeDate = category.ChangeDate;
            createdCategory.ChangeUser = category.ChangedBy.GetFullName();
        }

        public void CreateSubCategory(DTO.SubCategory createdSubCategory)
        {
            CheckHelper.ArgumentNotNull(createdSubCategory, "createdSubCategory");
            CheckHelper.ArgumentWithinCondition(createdSubCategory.IsNew(), "SubCategory is not new.");
            Container.Get<IValidateService>().CheckIsValid(createdSubCategory);
            CheckHelper.ArgumentWithinCondition(!createdSubCategory.Category.IsNew(), "Category of SubCategory is new.");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can create subcategory.");

            var persistentService = Container.Get<IPersistentService>();

            var doesAnotherSubCategoryWithTheSameNameWithinTheSameCategoryExist =
                    persistentService
                        .GetEntitySet<SubCategory>()
                        .Any(sc => 
                            sc.Name == createdSubCategory.Name && 
                            sc.CategoryId == createdSubCategory.Category.Id);

            if (doesAnotherSubCategoryWithTheSameNameWithinTheSameCategoryExist)
                throw new CategoryServiceException("Подкатегория с заданным названием уже существует в данной категории.");

            var category = persistentService.GetEntityById<DataAccess.Category>(createdSubCategory.Category.Id);
            CheckHelper.NotNull(category, "Category does not exist.");

            var subCategory =
                new SubCategory
                {
                    Name = createdSubCategory.Name,
                    CategoryId = category.Id,
                    Category = category,
                    Active = createdSubCategory.Active
                };
            subCategory.UpdateTrackFields(Container);
            persistentService.Add(subCategory);

            persistentService.SaveChanges();

            createdSubCategory.Id = subCategory.Id;
            createdSubCategory.CreateDate = subCategory.CreateDate;
            createdSubCategory.CreateUser = subCategory.CreatedBy.GetFullName();
            createdSubCategory.ChangeDate = subCategory.ChangeDate;
            createdSubCategory.ChangeUser = subCategory.ChangedBy.GetFullName();
        }

        public void UpdateCategory(DTO.Category updatedCategory)
        {
            CheckHelper.ArgumentNotNull(updatedCategory, "updatedCategory");
            CheckHelper.ArgumentWithinCondition(!updatedCategory.IsNew(), "Category is new.");
            Container.Get<IValidateService>().CheckIsValid(updatedCategory);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can change category.");

            var persistentService = Container.Get<IPersistentService>();
            var category = persistentService.GetEntityById<DataAccess.Category>(updatedCategory.Id);
            CheckHelper.NotNull(category, "Category does not exist.");

            if (category.Name != updatedCategory.Name)
            {
                var doesAnotherCategoryWithTheSameNameExist =
                    persistentService
                        .GetEntitySet<DataAccess.Category>()
                        .Any(c => c.Name == updatedCategory.Name);

                if (doesAnotherCategoryWithTheSameNameExist)
                    throw new CategoryServiceException("Категория с заданным названием уже существует.");
            }

            category.Name = updatedCategory.Name;
            category.Active = updatedCategory.Active;
            category.UpdateTrackFields(Container);

            persistentService.SaveChanges();
        }

        public void UpdateSubCategory(DTO.SubCategory updatedSubCategory)
        {
            CheckHelper.ArgumentNotNull(updatedSubCategory, "updatedSubCategory");
            CheckHelper.ArgumentWithinCondition(!updatedSubCategory.IsNew(), "SubCategory is new.");
            Container.Get<IValidateService>().CheckIsValid(updatedSubCategory);
            CheckHelper.ArgumentWithinCondition(!updatedSubCategory.Category.IsNew(), "Category of SubCategory is new.");
            
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can change subcategory.");

            var persistentService = Container.Get<IPersistentService>();
            var subCategory = persistentService.GetEntityById<SubCategory>(updatedSubCategory.Id);
            CheckHelper.NotNull(subCategory, "Category does not exist.");

            if (subCategory.Name != updatedSubCategory.Name || subCategory.CategoryId != updatedSubCategory.Category.Id)
            {
                var doesAnotherSubCategoryWithTheSameNameWithinTheSameCategoryExist =
                    persistentService
                        .GetEntitySet<SubCategory>()
                        .Any(sc => 
                            sc.Name == updatedSubCategory.Name && 
                            sc.CategoryId == updatedSubCategory.Category.Id);

                if (doesAnotherSubCategoryWithTheSameNameWithinTheSameCategoryExist)
                    throw new CategoryServiceException("Подкатегория с заданным названием уже существует в данной категории.");
            }

            var category = persistentService.GetEntityById<DataAccess.Category>(updatedSubCategory.Category.Id);
            CheckHelper.NotNull(category, "Category does not exist.");

            subCategory.Name = updatedSubCategory.Name;
            subCategory.Active = updatedSubCategory.Active;
            subCategory.CategoryId = category.Id;
            subCategory.Category = category;
            subCategory.UpdateTrackFields(Container);

            persistentService.SaveChanges();
        }

        #endregion
    }
}
