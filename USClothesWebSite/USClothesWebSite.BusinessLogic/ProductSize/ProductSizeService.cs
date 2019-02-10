using System.Linq;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.ProductSize
{
    internal class ProductSizeService : BaseService, IProductSizeService
    {
        #region Constructors

        [Inject]
        public ProductSizeService(IReadOnlyContainer container)
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

        public DTO.ProductSize[] GetProductSizes(DTO.Product product, string filter)
        {
            CheckHelper.ArgumentNotNull(product, "product");
            CheckHelper.ArgumentWithinCondition(!product.IsNew(), "!product.IsNew()");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can get all product sizes.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.ProductSize>()
                    .Where(ps => ps.ProductId == product.Id)
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(ps => ps.Size.Name.Contains(filter));

            var dtoService = Container.Get<IDtoService>();

            return
                query
                    .OrderBy(ps => ps.Size.Name)
                    .ToArray()
                    .Select(ps => dtoService.CreateProductSize(ps, false))
                    .ToArray();
        }

        public DTO.ProductSize[] GetProductSizes(string filter)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can get all product sizes.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.ProductSize>()
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
                query = 
                    query
                        .Where(ps => 
                            ps.Size.Name.Contains(filter) ||
                            ps.Product.Name.Contains(filter));

            var dtoService = Container.Get<IDtoService>();

            return
                query
                    .OrderBy(ps => ps.Product.Name)
                    .ThenBy(ps => ps.Size.Name)
                    .ToArray()
                    .Select(ps => dtoService.CreateProductSize(ps, false))
                    .ToArray();
        }

        public void CreateProductSize(DTO.ProductSize createdProductSize)
        {
            CheckHelper.ArgumentNotNull(createdProductSize, "createdProductSize");
            CheckHelper.ArgumentWithinCondition(createdProductSize.IsNew(), "ProductSize is not new.");
            Container.Get<IValidateService>().CheckIsValid(createdProductSize);
            CheckHelper.ArgumentWithinCondition(!createdProductSize.Product.IsNew(), "Product of ProductSize is new.");
            CheckHelper.ArgumentWithinCondition(!createdProductSize.Size.IsNew(), "Size of ProductSize is new.");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can create product size.");

            var persistentService = Container.Get<IPersistentService>();

            var doesAnotherProductSizeWithTheSameProductAndSizeExist =
                    persistentService
                        .GetEntitySet<DataAccess.ProductSize>()
                        .Any(ps =>
                            ps.ProductId == createdProductSize.Product.Id &&
                            ps.SizeId == createdProductSize.Size.Id);

            if (doesAnotherProductSizeWithTheSameProductAndSizeExist)
                throw new ProductSizeServiceException("Размер товара с заданным размером уже существует для данного товара.");

            var product = persistentService.GetEntityById<DataAccess.Product>(createdProductSize.Product.Id);
            CheckHelper.NotNull(product, "Product does not exist.");
            var size = persistentService.GetEntityById<DataAccess.Size>(createdProductSize.Size.Id);
            CheckHelper.NotNull(size, "Size does not exist.");

            CheckHelper.WithinCondition(product.SubCategoryId == size.SubCategoryId, "Товар и размер должны принадлежать одной подкатегории.");

            var productSize =
                new DataAccess.ProductSize
                {
                    Active = createdProductSize.Active,
                    Price = createdProductSize.Price,
                    Product = product,
                    ProductId = product.Id,
                    Size = size,
                    SizeId = size.Id
                };
            productSize.UpdateTrackFields(Container);
            persistentService.Add(productSize);

            persistentService.SaveChanges();

            createdProductSize.Id = productSize.Id;
            createdProductSize.CreateDate = productSize.CreateDate;
            createdProductSize.CreateUser = productSize.CreatedBy.GetFullName();
            createdProductSize.ChangeDate = productSize.ChangeDate;
            createdProductSize.ChangeUser = productSize.ChangedBy.GetFullName();
        }

        public void UpdateProductSize(DTO.ProductSize updatedProductSize)
        {
            CheckHelper.ArgumentNotNull(updatedProductSize, "updatedProductSize");
            CheckHelper.ArgumentWithinCondition(!updatedProductSize.IsNew(), "ProductSize is new.");
            Container.Get<IValidateService>().CheckIsValid(updatedProductSize);
            CheckHelper.ArgumentWithinCondition(!updatedProductSize.Product.IsNew(), "Product of ProductSize is new.");
            CheckHelper.ArgumentWithinCondition(!updatedProductSize.Size.IsNew(), "Size of ProductSize is new.");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can change product size.");

            var persistentService = Container.Get<IPersistentService>();
            var productSize = persistentService.GetEntityById<DataAccess.ProductSize>(updatedProductSize.Id);
            CheckHelper.NotNull(updatedProductSize, "ProductSize does not exist.");

            if (productSize.ProductId != updatedProductSize.Product.Id || productSize.SizeId != updatedProductSize.Size.Id)
            {
                var doesAnotherProductSizeWithTheSameProductAndSizeExist =
                    persistentService
                        .GetEntitySet<DataAccess.ProductSize>()
                        .Any(ps =>
                            ps.ProductId == updatedProductSize.Product.Id &&
                            ps.SizeId == updatedProductSize.Size.Id);

                if (doesAnotherProductSizeWithTheSameProductAndSizeExist)
                    throw new ProductSizeServiceException("Размер товара с заданным размером уже существует для данного товара.");
            }

            var product = persistentService.GetEntityById<DataAccess.Product>(updatedProductSize.Product.Id);
            CheckHelper.NotNull(product, "Product does not exist.");
            var size = persistentService.GetEntityById<DataAccess.Size>(updatedProductSize.Size.Id);
            CheckHelper.NotNull(size, "Size does not exist.");

            CheckHelper.WithinCondition(product.SubCategoryId == size.SubCategoryId, "Товар и размер должны принадлежать одной подкатегории.");

            productSize.Active = updatedProductSize.Active;
            productSize.ProductId = product.Id;
            productSize.Product = product;
            productSize.SizeId = size.Id;
            productSize.Size = size;
            productSize.Price = updatedProductSize.Price;
            productSize.UpdateTrackFields(Container);

            persistentService.SaveChanges();
        }

        #endregion
    }
}
