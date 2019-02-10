namespace USClothesWebSite.BusinessLogic.Category
{
    public interface ICategoryService
    {
        DTO.Category[] ActiveCategories { get; }

        DTO.Category[] GetCategories(string filter);
        DTO.SubCategory[] GetSubCategories(DTO.Category category, string filter);
        DTO.SubCategory[] GetSubCategories(string filter);

        void CreateCategory(DTO.Category createdCategory);
        void UpdateCategory(DTO.Category updatedCategory);
        void CreateSubCategory(DTO.SubCategory createdSubCategory);
        void UpdateSubCategory(DTO.SubCategory updatedSubCategory);
    }
}
