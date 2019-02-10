using System.ServiceModel;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    [ServiceContract(Namespace = "http://usclothes.ru/webservice/reportapi")]
    public interface IReportAPI
    {
        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        ParcelReportItem[] GenerateParcelsReport();

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        DistributorReportItem[] GenerateDistributorsReport();
    }
}
