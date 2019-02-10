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

namespace USClothesWebSite.BusinessLogic.DistributorTransfer
{
    internal class DistributorTransferService : BaseService, IDistributorTransferService
    {
        #region Constructors

        [Inject]
        public DistributorTransferService(IReadOnlyContainer container) 
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


        #region IDistributorTransferService

        public DTO.DistributorTransfer[] GetDistributorTransfers(DTO.User distributor)
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserPurchaser ||
                SecurityService.IsCurrentUserDistributor,
                "Only purchaser and distributor can get all distributor transfers.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.DistributorTransfer>()
                    .AsQueryable();
            
            if (SecurityService.IsCurrentUserPurchaser)
            {
                if (distributor != null)
                {
                    CheckHelper.ArgumentWithinCondition(!distributor.IsNew(), "Distributor is new.");

                    query = query.Where(dt => dt.CreateUserId == distributor.Id);
                }
            }
            else
            {
                CheckHelper.WithinCondition(distributor == null, "Distributor can only get all transfers without any filter specified.");

                query = query.Where(dt => dt.CreateUserId == SecurityService.CurrentUser.Id);
            }

            var dtoService = Container.Get<IDtoService>();

            return
               query
                   .OrderBy(dt => dt.Date)
                   .AsEnumerable()
                   .Select(dt => dtoService.CreateDistributorTransfer(dt))
                   .ToArray();
        }

        public void CreateDistributorTransfer(DTO.DistributorTransfer createdDistributorTransfer)
        {
            CheckHelper.ArgumentNotNull(createdDistributorTransfer, "createdDistributorTransfer");
            CheckHelper.ArgumentWithinCondition(createdDistributorTransfer.IsNew(), "Distributor Transfer is not new.");
            Container.Get<IValidateService>().CheckIsValid(createdDistributorTransfer);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserDistributor, "Only distributor can create distributor transfer.");

            var persistentService = Container.Get<IPersistentService>();

            var distributorTransfer =
                new DataAccess.DistributorTransfer
                {
                    Date = createdDistributorTransfer.Date,
                    Amount = createdDistributorTransfer.Amount,
                    Active = createdDistributorTransfer.Active,
                    RublesPerDollar = createdDistributorTransfer.RublesPerDollar
                };
            distributorTransfer.UpdateTrackFields(Container);

            persistentService.Add(distributorTransfer);
            persistentService.SaveChanges();

            createdDistributorTransfer.Id = distributorTransfer.Id;
            createdDistributorTransfer.CreateDate = distributorTransfer.CreateDate;
            createdDistributorTransfer.CreateUser = distributorTransfer.CreatedBy.GetFullName();
            createdDistributorTransfer.ChangeDate = distributorTransfer.ChangeDate;
            createdDistributorTransfer.ChangeUser = distributorTransfer.ChangedBy.GetFullName();
        }

        public void UpdateDistributorTransfer(DTO.DistributorTransfer updatedDistributorTransfer)
        {
            CheckHelper.ArgumentNotNull(updatedDistributorTransfer, "updatedDistributorTransfer");
            CheckHelper.ArgumentWithinCondition(!updatedDistributorTransfer.IsNew(), "Distributor Transfer is new.");
            Container.Get<IValidateService>().CheckIsValid(updatedDistributorTransfer);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserDistributor, "Only distributor can change distributor transfer.");

            var persistentService = Container.Get<IPersistentService>();

            var distributorTransfer = persistentService.GetEntityById<DataAccess.DistributorTransfer>(updatedDistributorTransfer.Id);
            CheckHelper.NotNull(distributorTransfer, "Distributor Transfer does not exist.");
            CheckHelper.WithinCondition(
                distributorTransfer.CreateUserId == SecurityService.CurrentUser.Id,
                "Distributor can only change distributor transfer created by him.");

            distributorTransfer.Date = updatedDistributorTransfer.Date;
            distributorTransfer.Amount = updatedDistributorTransfer.Amount;
            distributorTransfer.Active = updatedDistributorTransfer.Active;
            distributorTransfer.RublesPerDollar = updatedDistributorTransfer.RublesPerDollar;
            distributorTransfer.UpdateTrackFields(Container);

            persistentService.SaveChanges();
        }
        
        #endregion
    }
}
