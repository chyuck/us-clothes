using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Report
{
    public interface IReportService
    {
        ParcelReportItem[] GenerateParcelsReport();

        DistributorReportItem[] GenerateDistributorsReport();
    }
}
