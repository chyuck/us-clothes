using System;
using System.ServiceModel;

namespace USClothesWebSite.Web.WebServices
{
    [ServiceContract(Namespace = "http://usclothes.ru/webservice/logapi")]
    public interface ILogAPI
    {
        [OperationContract]
        DTO.ActionLog[] GetActionLogs(DateTime startDate, DateTime endDate, string filter);
    }
}
