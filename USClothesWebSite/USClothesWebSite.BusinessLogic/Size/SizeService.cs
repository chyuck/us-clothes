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

namespace USClothesWebSite.BusinessLogic.Size
{
    internal class SizeService : BaseService, ISizeService
    {
        #region Constructors

        [Inject]
        public SizeService(IReadOnlyContainer container)
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


        #region ISizeService

        public DTO.Size[] GetActiveSizes(DTO.SubCategory subCategory, DTO.Brand brand)
        {
            CheckHelper.ArgumentNotNull(subCategory, "subCategory");
            CheckHelper.ArgumentWithinCondition(!subCategory.IsNew(), "!subCategory.IsNew()");

            CheckHelper.ArgumentNotNull(brand, "brand");
            CheckHelper.ArgumentWithinCondition(!brand.IsNew(), "!brand.IsNew()");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            var persistentService = Container.Get<IPersistentService>();
            var dtoService = Container.Get<IDtoService>();

            return
                persistentService
                    .GetActiveEntities<DataAccess.Size>()
                    .Where(s => s.SubCategoryId == subCategory.Id && s.BrandId == brand.Id)
                    .OrderBy(s => s.Name)
                    .AsEnumerable()
                    .Select(s => dtoService.CreateSize(s))
                    .ToArray();
        }

        public DTO.Size[] GetSizes(DTO.SubCategory subCategory, DTO.Brand brand, string filter)
        {
            CheckHelper.ArgumentNotNull(subCategory, "subCategory");
            CheckHelper.ArgumentWithinCondition(!subCategory.IsNew(), "!subCategory.IsNew()");
            CheckHelper.ArgumentNotNull(brand, "brand");
            CheckHelper.ArgumentWithinCondition(!brand.IsNew(), "!brand.IsNew()");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can get all sizes.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.Size>()
                    .Where(s => s.SubCategoryId == subCategory.Id && s.BrandId == brand.Id)
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
                query = 
                    query
                        .Where(s => 
                            s.Name.Contains(filter) ||
                            s.Height.Contains(filter) ||
                            s.Weight.Contains(filter));

            var dtoService = Container.Get<IDtoService>();

            return
                query
                    .OrderBy(s => s.Id)
                    .ToArray()
                    .Select(s => dtoService.CreateSize(s, false))
                    .ToArray();
        }

        public DTO.Size[] GetSizes(string filter)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can get all sizes.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.Size>()
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
                query =
                    query
                        .Where(s =>
                            s.Name.Contains(filter) ||
                            s.SubCategory.Name.Contains(filter) ||
                            s.Brand.Name.Contains(filter) ||
                            s.Height.Contains(filter) ||
                            s.Weight.Contains(filter));

            var dtoService = Container.Get<IDtoService>();

            return
                query
                    .OrderBy(s => s.Id)
                    .ToArray()
                    .Select(s => dtoService.CreateSize(s, false))
                    .ToArray();
        }

        public void CreateSize(DTO.Size createdSize)
        {
            CheckHelper.ArgumentNotNull(createdSize, "createdSize");
            CheckHelper.ArgumentWithinCondition(createdSize.IsNew(), "Size is not new.");
            Container.Get<IValidateService>().CheckIsValid(createdSize);
            CheckHelper.ArgumentWithinCondition(!createdSize.SubCategory.IsNew(), "SubCategory of Size is new.");
            CheckHelper.ArgumentWithinCondition(!createdSize.Brand.IsNew(), "Brand of Size is new.");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can create size.");

            var persistentService = Container.Get<IPersistentService>();

            var doesAnotherSizeWithTheSameNameSubCategoryBrandExist =
                    persistentService
                        .GetEntitySet<DataAccess.Size>()
                        .Any(s =>
                            s.Name == createdSize.Name &&
                            s.SubCategoryId == createdSize.SubCategory.Id &&
                            s.BrandId == createdSize.Brand.Id);

            if (doesAnotherSizeWithTheSameNameSubCategoryBrandExist)
                throw new SizeServiceException("Размер с заданным названием уже существует для данной подкатегории и данного бренда.");

            var subCategory = persistentService.GetEntityById<SubCategory>(createdSize.SubCategory.Id);
            CheckHelper.NotNull(subCategory, "SubCategory does not exist.");
            var brand = persistentService.GetEntityById<DataAccess.Brand>(createdSize.Brand.Id);
            CheckHelper.NotNull(brand, "Brand does not exist.");

            var size =
                new DataAccess.Size
                {
                    Name = createdSize.Name,
                    SubCategoryId = subCategory.Id,
                    SubCategory = subCategory,
                    BrandId = brand.Id,
                    Brand = brand,
                    Active = createdSize.Active,
                    Weight = createdSize.Weight,
                    Height = createdSize.Height
                };
            size.UpdateTrackFields(Container);
            persistentService.Add(size);

            persistentService.SaveChanges();

            createdSize.Id = size.Id;
            createdSize.CreateDate = size.CreateDate;
            createdSize.CreateUser = size.CreatedBy.GetFullName();
            createdSize.ChangeDate = size.ChangeDate;
            createdSize.ChangeUser = size.ChangedBy.GetFullName();
        }

        public void UpdateSize(DTO.Size updatedSize)
        {
            CheckHelper.ArgumentNotNull(updatedSize, "updatedSize");
            CheckHelper.ArgumentWithinCondition(!updatedSize.IsNew(), "Size is new.");
            Container.Get<IValidateService>().CheckIsValid(updatedSize);
            CheckHelper.ArgumentWithinCondition(!updatedSize.SubCategory.IsNew(), "SubCategory of Size is new.");
            CheckHelper.ArgumentWithinCondition(!updatedSize.Brand.IsNew(), "SubCategory of Brand is new.");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can change size.");

            var persistentService = Container.Get<IPersistentService>();
            var size = persistentService.GetEntityById<DataAccess.Size>(updatedSize.Id);
            CheckHelper.NotNull(size, "Size does not exist.");

            if (size.Name != updatedSize.Name || size.SubCategoryId != updatedSize.SubCategory.Id || size.BrandId != updatedSize.Brand.Id)
            {
                var doesAnotherSizeWithTheSameNameSubCategoryBrandExist =
                    persistentService
                        .GetEntitySet<DataAccess.Size>()
                        .Any(s =>
                            s.Name == updatedSize.Name &&
                            s.SubCategoryId == updatedSize.SubCategory.Id &&
                            s.BrandId == updatedSize.Brand.Id);

                if (doesAnotherSizeWithTheSameNameSubCategoryBrandExist)
                    throw new SizeServiceException("Размер с заданным названием уже существует для данной подкатегории и данного бренда.");
            }

            var subCategory = persistentService.GetEntityById<SubCategory>(updatedSize.SubCategory.Id);
            CheckHelper.NotNull(subCategory, "SubCategory does not exist.");
            var brand = persistentService.GetEntityById<DataAccess.Brand>(updatedSize.Brand.Id);
            CheckHelper.NotNull(brand, "Brand does not exist.");

            size.Name = updatedSize.Name;
            size.Active = updatedSize.Active;
            size.SubCategoryId = subCategory.Id;
            size.SubCategory = subCategory;
            size.BrandId = brand.Id;
            size.Brand = brand;
            size.Weight = updatedSize.Weight;
            size.Height = updatedSize.Height;
            size.UpdateTrackFields(Container);

            persistentService.SaveChanges();
        }

        #endregion
    }
}
