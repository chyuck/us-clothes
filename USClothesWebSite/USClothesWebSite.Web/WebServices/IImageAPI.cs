using System.ServiceModel;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    [ServiceContract(Namespace = "http://usclothes.ru/webservice/imageapi")]
    public interface IImageAPI
    {
        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        Picture UploadPicture(byte[] picture);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        void DeletePicture(Picture picture);
    }
}
