using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Dictionary
{
    public interface IDictionaryService
    {
        Brand[] GetBrands(string filter);
        string CreateBrand(Brand brand);
        string UpdateBrand(Brand brand);
        
        Category[] GetCategories(string filter);
        string CreateCategory(Category category);
        string UpdateCategory(Category category);

        SubCategory[] GetSubCategories(string filter, Category category);
        SubCategory[] GetSubCategories(string filter);
        string CreateSubCategory(SubCategory subCategory);
        string UpdateSubCategory(SubCategory subCategory);

        Size[] GetSizes(string filter, SubCategory subCategory, Brand brand);
        Size[] GetSizes(string filter);
        string CreateSize(Size size);
        string UpdateSize(Size size);
    }
}
