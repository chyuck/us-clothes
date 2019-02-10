using System;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Product
{
    public interface IProductService
    {
        DTO.Product[] GetProducts(DateTime startDate, DateTime endDate, string filter);
        
        ProductSize[] GetProductSizes(DTO.Product product, string filter);
        ProductSize[] GetProductSizes(string filter);

        string CreateProduct(DTO.Product product);
        string UpdateProduct(DTO.Product product);

        string CreateProductSize(ProductSize productSize);
        string UpdateProductSize(ProductSize productSize);
    }
}
