using System;
using USClothesWebSite.BusinessLogic.Product;
using USClothesWebSite.BusinessLogic.ProductSize;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    public class ProductAPI : BaseAPI, IProductAPI
    {
        [Obsolete]
        public Product[] GetProducts(string filter)
        {
            return Container.Get<IProductService>().GetProducts(filter);
        }

        public Product[] GetProducts(DateTime startDate, DateTime endDate, string filter)
        {
            return Container.Get<IProductService>().GetProducts(startDate, endDate, filter);
        }

        public ProductSize[] GetProductSizes(Product product, string filter)
        {
            return Container.Get<IProductSizeService>().GetProductSizes(product, filter);
        }

        public ProductSize[] GetProductSizes(string filter)
        {
            return Container.Get<IProductSizeService>().GetProductSizes(filter);
        }

        public string CreateProduct(ref Product product)
        {
            var p = product;

            return
                RunAndCatchException<ProductServiceException>(
                    () => Container.Get<IProductService>().CreateProduct(p));
        }

        public string UpdateProduct(Product product)
        {
            return
                RunAndCatchException<ProductServiceException>(
                    () => Container.Get<IProductService>().UpdateProduct(product));
        }

        public string CreateProductSize(ref ProductSize productSize)
        {
            var ps = productSize;

            return
                RunAndCatchException<ProductSizeServiceException>(
                    () => Container.Get<IProductSizeService>().CreateProductSize(ps));
        }

        public string UpdateProductSize(ProductSize productSize)
        {
            return
                RunAndCatchException<ProductSizeServiceException>(
                    () => Container.Get<IProductSizeService>().UpdateProductSize(productSize));
        }
    }
}
