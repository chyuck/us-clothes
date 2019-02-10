namespace USClothesWebSite.BusinessLogic.ProductSize
{
    public interface IProductSizeService
    {
        DTO.ProductSize[] GetProductSizes(DTO.Product product, string filter);
        DTO.ProductSize[] GetProductSizes(string filter);

        void CreateProductSize(DTO.ProductSize createdProductSize);
        void UpdateProductSize(DTO.ProductSize updatedProductSize);
    }
}
