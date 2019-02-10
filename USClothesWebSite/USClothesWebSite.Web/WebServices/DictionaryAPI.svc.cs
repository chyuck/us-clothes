using USClothesWebSite.BusinessLogic.Brand;
using USClothesWebSite.BusinessLogic.Category;
using USClothesWebSite.BusinessLogic.Size;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    public class DictionaryAPI : BaseAPI, IDictionaryAPI
    {
        #region Brand

        public Brand[] GetBrands(string filter)
        {
            return Container.Get<IBrandService>().GetBrands(filter);
        }

        public string CreateBrand(ref Brand brand)
        {
            var b = brand;

            return
                RunAndCatchException<BrandServiceException>(
                    () => Container.Get<IBrandService>().CreateBrand(b));
        }

        public string UpdateBrand(Brand brand)
        {
            return
                RunAndCatchException<BrandServiceException>(
                    () => Container.Get<IBrandService>().UpdateBrand(brand));
        }
        
        #endregion


        #region Category

        public Category[] GetCategories(string filter)
        {
            return Container.Get<ICategoryService>().GetCategories(filter);
        }

        public SubCategory[] GetSubCategories(Category category, string filter)
        {
            return Container.Get<ICategoryService>().GetSubCategories(category, filter);
        }

        public SubCategory[] GetSubCategories(string filter)
        {
            return Container.Get<ICategoryService>().GetSubCategories(filter);
        }

        public string CreateCategory(ref Category category)
        {
            var c = category;

            return
                RunAndCatchException<CategoryServiceException>(
                    () => Container.Get<ICategoryService>().CreateCategory(c));
        }

        public string UpdateCategory(Category category)
        {
            return
                RunAndCatchException<CategoryServiceException>(
                    () => Container.Get<ICategoryService>().UpdateCategory(category));
        }

        public string CreateSubCategory(ref SubCategory subCategory)
        {
            var sc = subCategory;

            return
                RunAndCatchException<CategoryServiceException>(
                    () => Container.Get<ICategoryService>().CreateSubCategory(sc));
        }

        public string UpdateSubCategory(SubCategory subCategory)
        {
            return
                RunAndCatchException<CategoryServiceException>(
                    () => Container.Get<ICategoryService>().UpdateSubCategory(subCategory));
        }

        #endregion


        #region Size

        public Size[] GetSizes(SubCategory subCategory, Brand brand, string filter)
        {
            return Container.Get<ISizeService>().GetSizes(subCategory, brand, filter);
        }

        public Size[] GetSizes(string filter)
        {
            return Container.Get<ISizeService>().GetSizes(filter);
        }

        public string CreateSize(ref Size size)
        {
            var s = size;

            return
                RunAndCatchException<SizeServiceException>(
                    () => Container.Get<ISizeService>().CreateSize(s));
        }

        public string UpdateSize(Size size)
        {
            return
                RunAndCatchException<SizeServiceException>(
                    () => Container.Get<ISizeService>().UpdateSize(size));
        } 

        #endregion
    }
}
