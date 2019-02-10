using USClothesWebSite.DTO;

namespace USClothesWebSite.BusinessLogic.Report
{
    public interface IReportService
    {
        ParcelReportItem[] GenerateParcelsReport();

        DistributorReportItem[] GenerateDistributorsReport();
    }
}
