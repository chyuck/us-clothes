using System;
using System.Linq;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.BusinessLogic.Http;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Product
{
    internal class ProductService : BaseService, IProductService
    {
        #region Constructors

        [Inject]
        public ProductService(IReadOnlyContainer container)
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


        #region IProductService

        public DTO.Product[] GetActiveProductsBySubCategory(DTO.SubCategory subCategory)
        {
            CheckHelper.ArgumentNotNull(subCategory, "subCategory");
            CheckHelper.ArgumentWithinCondition(!subCategory.IsNew(), "!subCategory.IsNew()");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            var persistentService = Container.Get<IPersistentService>();
            var dtoService = Container.Get<IDtoService>();

            return
                persistentService
                    .GetActiveEntities<DataAccess.Product>()
                    .Where(p => p.SubCategoryId == subCategory.Id)
                    .OrderByDescending(p => p.ChangeDate)
                    .AsEnumerable()
                    .Select(p => dtoService.CreateProduct(p))
                    .ToArray();
        }

        public DTO.Product[] GetActiveProductsByBrand(DTO.Brand brand)
        {
            CheckHelper.ArgumentNotNull(brand, "brand");
            CheckHelper.ArgumentWithinCondition(!brand.IsNew(), "!brand.IsNew()");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            var persistentService = Container.Get<IPersistentService>();
            var dtoService = Container.Get<IDtoService>();

            return
                persistentService
                    .GetActiveEntities<DataAccess.Product>()
                    .Where(p => p.BrandId == brand.Id)
                    .OrderByDescending(p => p.ChangeDate)
                    .AsEnumerable()
                    .Select(p => dtoService.CreateProduct(p))
                    .ToArray();
        }

        [Obsolete]
        public DTO.Product[] GetProducts(string filter)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can get all products.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.Product>()
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
                query =
                    query
                        .Where(p =>
                            p.Name.Contains(filter) ||
                            (p.Description != null && p.Description.Contains(filter)) ||
                            (p.VendorShopURL != null && p.VendorShopURL.Contains(filter)) ||
                            p.SubCategory.Name.Contains(filter) ||
                            p.Brand.Name.Contains(filter));

            var dtoService = Container.Get<IDtoService>();

            return
                query
                    .OrderByDescending(p => p.ChangeDate)
                    .ToArray()
                    .Select(p => dtoService.CreateProduct(p, false))
                    .ToArray();
        }

        public DTO.Product[] GetProducts(DateTime startDate, DateTime endDate, string filter)
        {
            CheckHelper.ArgumentWithinCondition(startDate <= endDate, "startDate <= endDate");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can get all products.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.Product>()
                    .Where(p =>
                        (startDate <= p.CreateDate && p.CreateDate <= endDate) ||
                        (startDate <= p.ChangeDate && p.ChangeDate <= endDate));

            if (!string.IsNullOrWhiteSpace(filter))
                query =
                    query
                        .Where(p =>
                            p.Name.Contains(filter) ||
                            (p.Description != null && p.Description.Contains(filter)) ||
                            (p.VendorShopURL != null && p.VendorShopURL.Contains(filter)) ||
                            p.SubCategory.Name.Contains(filter) ||
                            p.Brand.Name.Contains(filter));

            var dtoService = Container.Get<IDtoService>();

            return
                query
                    .OrderByDescending(p => p.ChangeDate)
                    .ToArray()
                    .Select(p => dtoService.CreateProduct(p, false))
                    .ToArray();
        }

        public void CreateProduct(DTO.Product createdProduct)
        {
            CheckHelper.ArgumentNotNull(createdProduct, "createdProduct");
            CheckHelper.ArgumentWithinCondition(createdProduct.IsNew(), "Product is not new.");
            Container.Get<IValidateService>().CheckIsValid(createdProduct);
            CheckHelper.ArgumentWithinCondition(!createdProduct.SubCategory.IsNew(), "SubCategory of Product is new.");
            CheckHelper.ArgumentWithinCondition(!createdProduct.Brand.IsNew(), "Brand of Product is new.");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can create product.");

            var persistentService = Container.Get<IPersistentService>();

            var subCategory = persistentService.GetEntityById<SubCategory>(createdProduct.SubCategory.Id);
            CheckHelper.NotNull(subCategory, "SubCategory does not exist.");
            var brand = persistentService.GetEntityById<DataAccess.Brand>(createdProduct.Brand.Id);
            CheckHelper.NotNull(brand, "Brand does not exist.");

            var httpService = Container.Get<IHttpService>();

            var product =
                new DataAccess.Product
                {
                    Name = createdProduct.Name,
                    SubCategoryId = subCategory.Id,
                    SubCategory = subCategory,
                    BrandId = brand.Id,
                    Brand = brand,
                    Active = brand.Active,
                    Description = createdProduct.Description,
                    VendorShopURL = createdProduct.VendorShopURL,
                    FullPictureURL = httpService.GetRelativeURLFromAbsoluteURL(createdProduct.FullPictureURL),
                    PreviewPictureURL = httpService.GetRelativeURLFromAbsoluteURL(createdProduct.PreviewPictureURL)
                };
            product.UpdateTrackFields(Container);
            
            persistentService.Add(product);
            persistentService.SaveChanges();

            createdProduct.Id = product.Id;
            createdProduct.CreateDate = product.CreateDate;
            createdProduct.CreateUser = product.CreatedBy.GetFullName();
            createdProduct.ChangeDate = product.ChangeDate;
            createdProduct.ChangeUser = product.ChangedBy.GetFullName();
        }

        public void UpdateProduct(DTO.Product updatedProduct)
        {
            CheckHelper.ArgumentNotNull(updatedProduct, "updatedProduct");
            CheckHelper.ArgumentWithinCondition(!updatedProduct.IsNew(), "Product is new.");
            Container.Get<IValidateService>().CheckIsValid(updatedProduct);
            CheckHelper.ArgumentWithinCondition(!updatedProduct.SubCategory.IsNew(), "SubCategory of Product is new.");
            CheckHelper.ArgumentWithinCondition(!updatedProduct.Brand.IsNew(), "SubCategory of Product is new.");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can change product.");

            var persistentService = Container.Get<IPersistentService>();
            var product = persistentService.GetEntityById<DataAccess.Product>(updatedProduct.Id);
            CheckHelper.NotNull(product, "Product does not exist.");

            var subCategory = persistentService.GetEntityById<SubCategory>(updatedProduct.SubCategory.Id);
            CheckHelper.NotNull(subCategory, "SubCategory does not exist.");
            var brand = persistentService.GetEntityById<DataAccess.Brand>(updatedProduct.Brand.Id);
            CheckHelper.NotNull(brand, "Brand does not exist.");

            var httpService = Container.Get<IHttpService>();

            product.Name = updatedProduct.Name;
            product.Active = updatedProduct.Active;
            product.SubCategoryId = subCategory.Id;
            product.SubCategory = subCategory;
            product.BrandId = brand.Id;
            product.Brand = brand;
            product.Description = updatedProduct.Description;
            product.VendorShopURL = updatedProduct.VendorShopURL;
            product.FullPictureURL = httpService.GetRelativeURLFromAbsoluteURL(updatedProduct.FullPictureURL);
            product.PreviewPictureURL = httpService.GetRelativeURLFromAbsoluteURL(updatedProduct.PreviewPictureURL);

            product.UpdateTrackFields(Container);

            persistentService.SaveChanges();
        }

        #endregion
    }
}
