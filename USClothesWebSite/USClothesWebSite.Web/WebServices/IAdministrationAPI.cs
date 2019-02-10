using System.ServiceModel;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    [ServiceContract(Namespace = "http://usclothes.ru/webservice/administrationapi")]
    public interface IAdministrationAPI
    {
        [OperationContract]
        Settings GetSettings();

        [OperationContract]
        string UpdateSettings(Settings updatedSettings);
    }
}
