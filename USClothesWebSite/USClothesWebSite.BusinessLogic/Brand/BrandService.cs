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

namespace USClothesWebSite.BusinessLogic.Brand
{
    internal class BrandService : BaseService, IBrandService
    {
        #region Constructors

        [Inject]
        public BrandService(IReadOnlyContainer container)
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


        #region IBrandService

        public DTO.Brand[] ActiveBrands
        {
            get
            {
                if (!SecurityService.IsLoggedIn)
                    return new DTO.Brand[] {};

                var dtoService = Container.Get<IDtoService>();

                return
                    Container
                        .Get<IPersistentService>()
                        .GetActiveEntities<DataAccess.Brand>()
                        .OrderBy(b => b.Name)
                        .AsEnumerable()
                        .Select(b => dtoService.CreateBrand(b))
                        .ToArray();
            }
        }
        
        public DTO.Brand[] GetBrands(string filter)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can get all brands.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.Brand>()
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(b => b.Name.Contains(filter));

            var dtoService = Container.Get<IDtoService>();

            return
                query
                    .OrderBy(b => b.Id)
                    .ToArray()
                    .Select(b => dtoService.CreateBrand(b, false))
                    .ToArray();
        }

        public void CreateBrand(DTO.Brand createdBrand)
        {
            CheckHelper.ArgumentNotNull(createdBrand, "createdBrand");
            CheckHelper.ArgumentWithinCondition(createdBrand.IsNew(), "Brand is not new.");
            Container.Get<IValidateService>().CheckIsValid(createdBrand);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can create brand.");

            var persistentService = Container.Get<IPersistentService>();

            var doesAnotherBrandWithTheSameNameExist =
                    persistentService
                        .GetEntitySet<DataAccess.Brand>()
                        .Any(b => b.Name == createdBrand.Name);

            if (doesAnotherBrandWithTheSameNameExist)
                throw new BrandServiceException("Бренд с заданным названием уже существует.");

            var brand =
                new DataAccess.Brand
                {
                    Name = createdBrand.Name,
                    Active = createdBrand.Active
                };
            brand.UpdateTrackFields(Container);
            persistentService.Add(brand);

            persistentService.SaveChanges();

            createdBrand.Id = brand.Id;
            createdBrand.CreateDate = brand.CreateDate;
            createdBrand.CreateUser = brand.CreatedBy.GetFullName();
            createdBrand.ChangeDate = brand.ChangeDate;
            createdBrand.ChangeUser = brand.ChangedBy.GetFullName();
        }

        public void UpdateBrand(DTO.Brand updatedBrand)
        {
            CheckHelper.ArgumentNotNull(updatedBrand, "updatedBrand");
            CheckHelper.ArgumentWithinCondition(!updatedBrand.IsNew(), "Brand is new.");
            Container.Get<IValidateService>().CheckIsValid(updatedBrand);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can change brand.");

            var persistentService = Container.Get<IPersistentService>();
            var brand = persistentService.GetEntityById<DataAccess.Brand>(updatedBrand.Id);
            CheckHelper.NotNull(brand, "Brand does not exist.");

            if (brand.Name != updatedBrand.Name)
            {
                var doesAnotherBrandWithTheSameNameExist =
                    persistentService
                        .GetEntitySet<DataAccess.Brand>()
                        .Any(b => b.Name == updatedBrand.Name);

                if (doesAnotherBrandWithTheSameNameExist)
                    throw new BrandServiceException("Бренд с заданным названием уже существует.");
            }

            brand.Name = updatedBrand.Name;
            brand.Active = updatedBrand.Active;
            brand.UpdateTrackFields(Container);

            persistentService.SaveChanges();
        }

        #endregion
    }
}
