using DepIC;
using DepIC.Attributes;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.DictionaryAPI;
using USClothesWebSite.Win.Logic.Helpers;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Logic.Dictionary
{
    internal class DictionaryService : BaseService, IDictionaryService
    {
        [Inject]
        public DictionaryService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        private ISecurityService SecurityService
        {
            get { return Container.Get<ISecurityService>(); }
        }


        #region Brand
        
        public Brand[] GetBrands(string filter)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            return APIClientHelper<DictionaryAPIClient>.Call(c => c.GetBrands(filter));
        }

        public string CreateBrand(Brand brand)
        {
            CheckHelper.ArgumentNotNull(brand, "brand");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(brand);
            if (errors != null)
                return errors.ToErrorMessage();

            var createdBrand = (Brand)brand.Clone();

            var errorMessage = APIClientHelper<DictionaryAPIClient>.Call(c => c.CreateBrand(ref createdBrand));

            brand.Id = createdBrand.Id;

            return errorMessage;
        }

        public string UpdateBrand(Brand brand)
        {
            CheckHelper.ArgumentNotNull(brand, "brand");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(brand);
            if (errors != null)
                return errors.ToErrorMessage();

            return APIClientHelper<DictionaryAPIClient>.Call(c => c.UpdateBrand(brand));
        }
        
        #endregion


        #region Category
        
        public Category[] GetCategories(string filter)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            return APIClientHelper<DictionaryAPIClient>.Call(c => c.GetCategories(filter));
        }

        public SubCategory[] GetSubCategories(string filter, Category category)
        {
            CheckHelper.ArgumentNotNull(category, "category");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            return APIClientHelper<DictionaryAPIClient>.Call(c => c.GetSubCategoriesByCategory(category, filter));
        }

        public SubCategory[] GetSubCategories(string filter)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            return APIClientHelper<DictionaryAPIClient>.Call(c => c.GetSubCategories(filter));
        }

        public string CreateCategory(Category category)
        {
            CheckHelper.ArgumentNotNull(category, "category");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(category);
            if (errors != null)
                return errors.ToErrorMessage();

            var createdCategory = (Category)category.Clone();

            var errorMessage = APIClientHelper<DictionaryAPIClient>.Call(c => c.CreateCategory(ref createdCategory));

            category.Id = createdCategory.Id;

            return errorMessage;
        }

        public string UpdateCategory(Category category)
        {
            CheckHelper.ArgumentNotNull(category, "category");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(category);
            if (errors != null)
                return errors.ToErrorMessage();

            return APIClientHelper<DictionaryAPIClient>.Call(c => c.UpdateCategory(category));
        }

        public string CreateSubCategory(SubCategory subCategory)
        {
            CheckHelper.ArgumentNotNull(subCategory, "subCategory");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(subCategory);
            if (errors != null)
                return errors.ToErrorMessage();

            var createdSubCategory = (SubCategory)subCategory.Clone();

            var errorMessage = APIClientHelper<DictionaryAPIClient>.Call(c => c.CreateSubCategory(ref createdSubCategory));

            subCategory.Id = createdSubCategory.Id;

            return errorMessage;
        }

        public string UpdateSubCategory(SubCategory subCategory)
        {
            CheckHelper.ArgumentNotNull(subCategory, "subCategory");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(subCategory);
            if (errors != null)
                return errors.ToErrorMessage();

            return APIClientHelper<DictionaryAPIClient>.Call(c => c.UpdateSubCategory(subCategory));
        }

        #endregion


        #region Size

        public Size[] GetSizes(string filter, SubCategory subCategory, Brand brand)
        {
            CheckHelper.ArgumentNotNull(subCategory, "subCategory");
            CheckHelper.ArgumentNotNull(brand, "brand");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            return APIClientHelper<DictionaryAPIClient>.Call(c => c.GetSizesBySubCategoryAndBrand(subCategory, brand, filter));
        }

        public Size[] GetSizes(string filter)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            return APIClientHelper<DictionaryAPIClient>.Call(c => c.GetSizes(filter));
        }

        public string CreateSize(Size size)
        {
            CheckHelper.ArgumentNotNull(size, "size");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(size);
            if (errors != null)
                return errors.ToErrorMessage();

            var createdSize = (Size)size.Clone();

            var errorMessage = APIClientHelper<DictionaryAPIClient>.Call(c => c.CreateSize(ref createdSize));

            size.Id = createdSize.Id;

            return errorMessage;
        }

        public string UpdateSize(Size size)
        {
            CheckHelper.ArgumentNotNull(size, "size");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(size);
            if (errors != null)
                return errors.ToErrorMessage();

            return APIClientHelper<DictionaryAPIClient>.Call(c => c.UpdateSize(size));
        } 

        #endregion
    }
}
