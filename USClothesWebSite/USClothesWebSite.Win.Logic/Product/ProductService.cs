using System;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Helpers;
using USClothesWebSite.Win.Logic.ProductAPI;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Logic.Product
{
    internal class ProductService : BaseService, IProductService
    {
        [Inject]
        public ProductService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        private ISecurityService SecurityService
        {
            get { return Container.Get<ISecurityService>(); }
        }

        public DTO.Product[] GetProducts(DateTime startDate, DateTime endDate, string filter)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            return APIClientHelper<ProductAPIClient>.Call(c => c.GetProductsByDate(startDate, endDate, filter));
        }

        public ProductSize[] GetProductSizes(DTO.Product product, string filter)
        {
            CheckHelper.ArgumentNotNull(product, "product");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            return APIClientHelper<ProductAPIClient>.Call(c => c.GetProductSizesByProduct(product, filter));
        }

        public ProductSize[] GetProductSizes(string filter)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            return APIClientHelper<ProductAPIClient>.Call(c => c.GetProductSizes(filter));
        }

        public string CreateProduct(DTO.Product product)
        {
            CheckHelper.ArgumentNotNull(product, "product");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            var errors = IoC.Container.Get<IValidateService>().Validate(product);
            if (errors != null)
                return errors.ToErrorMessage();
            
            var createdProduct = (DTO.Product)product.Clone();

            var errorMessage = APIClientHelper<ProductAPIClient>.Call(c => c.CreateProduct(ref createdProduct));

            product.Id = createdProduct.Id;

            return errorMessage;
        }

        public string UpdateProduct(DTO.Product product)
        {
            CheckHelper.ArgumentNotNull(product, "product");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            var errors = IoC.Container.Get<IValidateService>().Validate(product);
            if (errors != null)
                return errors.ToErrorMessage();

            return APIClientHelper<ProductAPIClient>.Call(c => c.UpdateProduct(product));
        }

        public string CreateProductSize(ProductSize productSize)
        {
            CheckHelper.ArgumentNotNull(productSize, "productSize");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            var errors = IoC.Container.Get<IValidateService>().Validate(productSize);
            if (errors != null)
                return errors.ToErrorMessage();
            
            var createdProductSize = (ProductSize)productSize.Clone();

            var errorMessage = APIClientHelper<ProductAPIClient>.Call(c => c.CreateProductSize(ref createdProductSize));

            productSize.Id = createdProductSize.Id;

            return errorMessage;
        }

        public string UpdateProductSize(ProductSize productSize)
        {
            CheckHelper.ArgumentNotNull(productSize, "productSize");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            var errors = IoC.Container.Get<IValidateService>().Validate(productSize);
            if (errors != null)
                return errors.ToErrorMessage();

            return APIClientHelper<ProductAPIClient>.Call(c => c.UpdateProductSize(productSize));
        }
    }
}
