using System;
using USClothesWebSite.DTO;

namespace USClothesWebSite.BusinessLogic.Product
{
    public interface IProductService
    {
        DTO.Product[] GetActiveProductsBySubCategory(SubCategory subCategory);
        DTO.Product[] GetActiveProductsByBrand(DTO.Brand brand);

        [Obsolete]
        DTO.Product[] GetProducts(string filter);
        DTO.Product[] GetProducts(DateTime startDate, DateTime endDate, string filter);

        void CreateProduct(DTO.Product createdProduct);
        void UpdateProduct(DTO.Product updatedProduct);
    }
}
