using System;
using System.Linq;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.BusinessLogic.Helpers;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Parcel
{
    internal class ParcelService : BaseService, IParcelService
    {
        #region Constructors

        [Inject]
        public ParcelService(IReadOnlyContainer container) 
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


        #region Private Methods

        private void UpdateDistributor(DataAccess.Parcel parcel, DTO.User distributor)
        {
            CheckHelper.ArgumentNotNull(parcel, "parcel");

            if (distributor != null)
            {
                var distributorId = distributor.Id;
                CheckHelper.WithinCondition(distributorId > 0, "Distributor is new.");

                var persistentService = Container.Get<IPersistentService>();

                var user = persistentService.GetEntityById<User>(distributorId);
                CheckHelper.NotNull(user, "Distributor user does not exist.");
                CheckHelper.WithinCondition(
                    user.UserRoles.Any(r => r.Role.Name == DTO.Role.DISTRIBUTOR_ROLE_NAME && r.Active),
                    "User is not distributor.");

                parcel.DistributorId = user.Id;
                parcel.Distributor = user;
            }
            else
            {
                parcel.DistributorId = null;
                parcel.Distributor = null;
            }
        }

        private bool IsCurrentUserDistributorForParcel(DataAccess.Parcel parcel)
        {
            CheckHelper.ArgumentNotNull(parcel, "parcel");

            return 
                SecurityService.IsCurrentUserDistributor && 
                parcel.DistributorId.HasValue &&
                parcel.DistributorId == SecurityService.CurrentUser.Id;
        }

        #endregion


        #region IParcelService

        public DTO.Parcel[] GetParcels(DateTime startDate, DateTime endDate, string filter)
        {
            CheckHelper.ArgumentWithinCondition(startDate <= endDate, "startDate <= endDate");

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserSeller ||
                SecurityService.IsCurrentUserPurchaser ||
                SecurityService.IsCurrentUserDistributor,
                "Only seller, purchaser and distributor can get all parcels.");

            var query =
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.Parcel>()
                    .Where(p => 
                        (startDate <= p.CreateDate && p.CreateDate <= endDate) ||
                        (startDate <= p.ChangeDate && p.ChangeDate <= endDate) ||
                        (p.SentDate != null && startDate <= p.SentDate && p.SentDate <= endDate) ||
                        (p.ReceivedDate != null && startDate <= p.ReceivedDate && p.ReceivedDate <= endDate));

            if (!string.IsNullOrWhiteSpace(filter))
                query =
                    query
                        .Where(p =>
                               (p.Comments != null && p.Comments.Contains(filter)) ||
                               (p.TrackingNumber != null && p.TrackingNumber.Contains(filter)));


            query = QueryHelper.FilterParcelsBySecurityPermissions(query, Container);

            var dtoService = Container.Get<IDtoService>();
            
            var predicate =
                SecurityService.IsCurrentUserSeller && !SecurityService.IsCurrentUserPurchaser && !SecurityService.IsCurrentUserDistributor
                    ? o => o.CreateUserId == SecurityService.CurrentUser.Id
                    : (Func<DataAccess.Order, bool>) null;

            return
                query
                    .OrderBy(p => p.Id)
                    .AsEnumerable()
                    .Select(p => dtoService.CreateParcel(p, false, predicate))
                    .ToArray();
        }

        public void CreateParcel(DTO.Parcel createdParcel)
        {
            CheckHelper.ArgumentNotNull(createdParcel, "createdParcel");
            CheckHelper.ArgumentWithinCondition(createdParcel.IsNew(), "Parcel is not new.");
            Container.Get<IValidateService>().CheckIsValid(createdParcel);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserPurchaser, "Only purchaser can create parcel.");

            var persistentService = Container.Get<IPersistentService>();

            var parcel =
                new DataAccess.Parcel
                {
                    RublesPerDollar = createdParcel.RublesPerDollar,
                    PurchaserSpentOnDelivery = createdParcel.PurchaserSpentOnDelivery,
                    TrackingNumber = createdParcel.TrackingNumber,
                    SentDate = createdParcel.SentDate,
                    Comments = createdParcel.Comments
                };
            parcel.UpdateTrackFields(Container);
            UpdateDistributor(parcel, createdParcel.Distributor);
            
            persistentService.Add(parcel);

            persistentService.SaveChanges();
            
            createdParcel.Id = parcel.Id;
            createdParcel.CreateDate = parcel.CreateDate;
            createdParcel.CreateUser = parcel.CreatedBy.GetFullName();
            createdParcel.ChangeDate = parcel.ChangeDate;
            createdParcel.ChangeUser = parcel.ChangedBy.GetFullName();

            createdParcel.ReceivedDate = null;
        }
        
        public void UpdateParcel(DTO.Parcel updatedParcel)
        {
            CheckHelper.ArgumentNotNull(updatedParcel, "updatedParcel");
            CheckHelper.ArgumentWithinCondition(!updatedParcel.IsNew(), "Parcel is new.");
            Container.Get<IValidateService>().CheckIsValid(updatedParcel);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserPurchaser ||
                SecurityService.IsCurrentUserDistributor, 
                "Only purchaser and distributor can change parcel.");

            var persistentService = Container.Get<IPersistentService>();

            var parcel = persistentService.GetEntityById<DataAccess.Parcel>(updatedParcel.Id);
            CheckHelper.NotNull(parcel, "Parcel does not exist.");
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserPurchaser || IsCurrentUserDistributorForParcel(parcel),
                "Only purchaser and distributor can change parcel.");

            if (IsCurrentUserDistributorForParcel(parcel))
            {
                parcel.ReceivedDate = updatedParcel.ReceivedDate;
            }
            else
            {
                updatedParcel.ReceivedDate = parcel.ReceivedDate;
            }
            
            if (SecurityService.IsCurrentUserPurchaser)
            {
                parcel.RublesPerDollar = updatedParcel.RublesPerDollar;
                parcel.PurchaserSpentOnDelivery = updatedParcel.PurchaserSpentOnDelivery;
                parcel.TrackingNumber = updatedParcel.TrackingNumber;
                parcel.SentDate = updatedParcel.SentDate;
                parcel.Comments = updatedParcel.Comments;
                UpdateDistributor(parcel, updatedParcel.Distributor);
            }
            else
            {
                updatedParcel.RublesPerDollar = parcel.RublesPerDollar;
                updatedParcel.PurchaserSpentOnDelivery = parcel.PurchaserSpentOnDelivery;
                updatedParcel.TrackingNumber = parcel.TrackingNumber;
                updatedParcel.SentDate = parcel.SentDate;
                updatedParcel.Comments = parcel.Comments;
                
                updatedParcel.Distributor =  
                    parcel.Distributor == null 
                        ? null
                        : Container.Get<IDtoService>().CreateUser(parcel.Distributor);
            }

            parcel.UpdateTrackFields(Container);

            persistentService.SaveChanges();
        }

        #endregion
    }
}
