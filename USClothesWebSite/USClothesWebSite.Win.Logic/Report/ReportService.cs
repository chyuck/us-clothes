using DepIC;
using DepIC.Attributes;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Helpers;
using USClothesWebSite.Win.Logic.ReportAPI;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Logic.Report
{
    internal class ReportService : BaseService, IReportService
    {
        [Inject]
        public ReportService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        private ISecurityService SecurityService
        {
            get { return Container.Get<ISecurityService>(); }
        }

        public ParcelReportItem[] GenerateParcelsReport()
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            return APIClientHelper<ReportAPIClient>.Call(c => c.GenerateParcelsReport());
        }

        public DistributorReportItem[] GenerateDistributorsReport()
        {
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

            return APIClientHelper<ReportAPIClient>.Call(c => c.GenerateDistributorsReport());
        }
    }
}
