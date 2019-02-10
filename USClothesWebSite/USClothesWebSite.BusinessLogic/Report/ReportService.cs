using System.Linq;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.BusinessLogic.Helpers;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.DTO;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Report
{
    internal class ReportService : BaseService, IReportService
    {
        #region Constructors

        [Inject]
        public ReportService(IReadOnlyContainer container)
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


        #region IReportService

        public ParcelReportItem[] GenerateParcelsReport()
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserSeller ||
                SecurityService.IsCurrentUserPurchaser ||
                SecurityService.IsCurrentUserDistributor,
                "Only seller, purchaser and distributor can generate parcels report.");

            var persistenceService = Container.Get<IPersistentService>();

            var parcelQuery =
                persistenceService
                    .GetEntitySet<DataAccess.Parcel>()
                    .AsQueryable();

            parcelQuery = QueryHelper.FilterParcelsBySecurityPermissions(parcelQuery, Container);

            var parcelReportItemPrototypes = 
                parcelQuery
                    .SelectMany(p => p.Orders)
                    .SelectMany(o => o.OrderItems)
                    .Where(oi => oi.Active && oi.Order.Active && oi.Order.Parcel != null)
                    .Select(oi =>
                        new
                        {
                            ParcelId = oi.Order.ParcelId.Value,
                            DistributorName =  
                                oi.Order.Parcel.Distributor != null 
                                    ? oi.Order.Parcel.Distributor.LastName + " " + oi.Order.Parcel.Distributor.FirstName
                                    : string.Empty,
                            oi.Order.Parcel.SentDate,
                            oi.Order.Parcel.ReceivedDate,
                            oi.Order.Parcel.PurchaserSpentOnDelivery,
                            oi.OrderId,
                            DistributorSpentOnDelivery = oi.Order.DistributorSpentOnDelivery / oi.Order.RublesPerDollar,
                            CustomerPrepaid = oi.Order.CustomerPrepaid / oi.Order.RublesPerDollar,
                            CustomerPaid = oi.Order.CustomerPaid / oi.Order.RublesPerDollar,
                            oi.PurchaserPaid,
                            TotalPrice = oi.TotalPrice / oi.Order.RublesPerDollar
                        })
                    .ToArray();

            return
                parcelReportItemPrototypes
                    .GroupBy(pr => pr.ParcelId)
                    .OrderBy(gr => gr.Key)
                    .Select(grouping =>
                    {
                        var parcelReportItem =
                            new ParcelReportItem
                            {
                                Id = grouping.Key,

                                ParcelName = DTO.Parcel.GetParcelName(grouping.Key),
                                DistributorName = grouping.Select(i => i.DistributorName).Distinct().Single(),

                                SentDate = grouping.Select(i => i.SentDate).Distinct().Single(),
                                ReceivedDate = grouping.Select(i => i.ReceivedDate).Distinct().Single(),

                                PurchaserPaid = grouping.Sum(i => i.PurchaserPaid.ToMoney()),
                                PurchaserSpentOnDelivery = grouping.Select(i => i.PurchaserSpentOnDelivery).Distinct().Single().ToMoney(),
                                DistributorSpentOnDelivery = 
                                    grouping
                                        .GroupBy(i => i.OrderId)
                                        .Select(gr => gr.Select(i => i.DistributorSpentOnDelivery).Distinct().Single())
                                        .Sum(i => i.ToMoney()),
                                CustomersPrepaid =
                                    grouping
                                        .GroupBy(i => i.OrderId)
                                        .Select(gr => gr.Select(i => i.CustomerPrepaid).Distinct().Single())
                                        .Sum(i => i.ToMoney()),
                                CustomersPaid =
                                    grouping
                                        .GroupBy(i => i.OrderId)
                                        .Select(gr => gr.Select(i => i.CustomerPaid).Distinct().Single())
                                        .Sum(i => i.ToMoney()),
                                ExpectedTotalCustomerPaid = grouping.Sum(i => i.TotalPrice.ToMoney())
                            };

                        parcelReportItem.TotalPaid =
                            parcelReportItem.PurchaserPaid +
                            parcelReportItem.PurchaserSpentOnDelivery +
                            parcelReportItem.DistributorSpentOnDelivery;

                        parcelReportItem.TotalCustomersPaid =
                            parcelReportItem.CustomersPrepaid +
                            parcelReportItem.CustomersPaid;

                        parcelReportItem.TotalProfit =
                            parcelReportItem.TotalCustomersPaid - parcelReportItem.TotalPaid;

                        parcelReportItem.ExpectedTotalProfit =
                            parcelReportItem.ExpectedTotalCustomerPaid - parcelReportItem.TotalPaid;

                        return parcelReportItem;
                    })
                    .ToArray();
        }

        public DistributorReportItem[] GenerateDistributorsReport()
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(
                SecurityService.IsCurrentUserPurchaser ||
                SecurityService.IsCurrentUserDistributor,
                "Only purchaser and distributor can generate distributors report.");

            var persistenceService = Container.Get<IPersistentService>();

            var parcelQuery =
                persistenceService
                    .GetEntitySet<DataAccess.Parcel>()
                    .Where(p => p.Distributor != null);

            var distributorTransferQuery =
                persistenceService
                    .GetEntitySet<DataAccess.DistributorTransfer>()
                    .Where(dt => dt.Active);

            var currentUserId = SecurityService.CurrentUser.Id;

            if (!SecurityService.IsCurrentUserPurchaser)
            {
                CheckHelper.WithinCondition(
                    SecurityService.IsCurrentUserDistributor, 
                    "Only purchaser and distributor can generate distributors report.");

                parcelQuery = 
                    parcelQuery
                        .Where(p => p.DistributorId == currentUserId);

                distributorTransferQuery =
                    distributorTransferQuery
                        .Where(dt => dt.CreateUserId == currentUserId);
            }

            var distributorTransfers =
                distributorTransferQuery
                    .Select(dt =>
                        new
                        {
                            DistributorId = dt.CreateUserId,
                            TransferAmount = dt.Amount / dt.RublesPerDollar
                        })
                    .ToArray();


            var distributorReportItemPrototypes = 
                parcelQuery
                    .SelectMany(p => p.Orders)
                    .SelectMany(o => o.OrderItems)
                    .Where(oi => oi.Active && oi.Order.Active && oi.Order.Parcel != null)
                    .Select(oi =>
                        new
                        {
                            ParcelId = oi.Order.ParcelId.Value,
                            oi.OrderId,
                            
                            DistributorId = oi.Order.Parcel.DistributorId.Value,
                            DistributorName = oi.Order.Parcel.Distributor.LastName + " " + oi.Order.Parcel.Distributor.FirstName,
                            
                            oi.Order.Parcel.PurchaserSpentOnDelivery,
                            DistributorSpentOnDelivery = oi.Order.DistributorSpentOnDelivery / oi.Order.RublesPerDollar,
                            CustomerPrepaid = oi.Order.CustomerPrepaid / oi.Order.RublesPerDollar,
                            CustomerPaid = oi.Order.CustomerPaid / oi.Order.RublesPerDollar,
                            oi.PurchaserPaid,
                            TotalPrice = oi.TotalPrice / oi.Order.RublesPerDollar
                        })
                    .ToArray();

            return
                distributorReportItemPrototypes
                    .GroupBy(pr => pr.DistributorId)
                    .OrderBy(gr => gr.Key)
                    .Select(grouping =>
                    {
                        var distributorTransfersAmount =
                            distributorTransfers
                                .Where(dt => dt.DistributorId == grouping.Key)
                                .Sum(dt => dt.TransferAmount.ToMoney());

                        var userReportItem =
                            new DistributorReportItem
                            {
                                Id = grouping.Key,

                                DistributorName = grouping.Select(i => i.DistributorName).Distinct().Single(),
                                DistributorSpent =
                                    distributorTransfersAmount +
                                    grouping
                                        .GroupBy(i => i.OrderId)
                                        .Select(gr => gr.Select(i => i.DistributorSpentOnDelivery).Distinct().Single())
                                        .Sum(i => i.ToMoney()),
                                DistributorReceived =
                                    grouping
                                        .GroupBy(i => i.OrderId)
                                        .Select(gr => gr.Select(i => i.CustomerPrepaid).Distinct().Single())
                                        .Sum(i => i.ToMoney()) +
                                    grouping
                                        .GroupBy(i => i.OrderId)
                                        .Select(gr => gr.Select(i => i.CustomerPaid).Distinct().Single())
                                        .Sum(i => i.ToMoney()),

                                PurchaserSpent =
                                    grouping.Sum(i => i.PurchaserPaid.ToMoney()) +
                                    grouping
                                        .GroupBy(i => i.ParcelId)
                                        .Select(gr => gr.Select(i => i.PurchaserSpentOnDelivery).Distinct().Single())
                                        .Sum(i => i.ToMoney()),
                                PurchaserReceived = distributorTransfersAmount
                            };

                        userReportItem.DistributorBalance =
                            userReportItem.DistributorSpent - userReportItem.DistributorReceived;
                        userReportItem.PurchaserBalance =
                            userReportItem.PurchaserSpent - userReportItem.PurchaserReceived;
                        userReportItem.TotalBalance =
                            ((userReportItem.PurchaserBalance - userReportItem.DistributorBalance) / 2).ToMoney();
                        
                        return userReportItem;
                    })
                    .ToArray();
        }
 
        #endregion
    }
}
