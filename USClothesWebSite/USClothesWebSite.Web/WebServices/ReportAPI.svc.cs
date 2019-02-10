using USClothesWebSite.BusinessLogic.Report;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    public class ReportAPI : BaseAPI, IReportAPI
    {
        public ParcelReportItem[] GenerateParcelsReport()
        {
            return Container.Get<IReportService>().GenerateParcelsReport();
        }

        public DistributorReportItem[] GenerateDistributorsReport()
        {
            return Container.Get<IReportService>().GenerateDistributorsReport();
        }
    }
}
