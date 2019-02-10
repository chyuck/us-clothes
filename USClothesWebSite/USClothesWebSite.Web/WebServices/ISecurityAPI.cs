using System.ServiceModel;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    [ServiceContract(Namespace = "http://usclothes.ru/webservice/securityapi")]
    public interface ISecurityAPI
    {
        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string LogIn(SecurityData securityData);

        [OperationContract]
        [FaultContract(typeof (ErrorData))]
        User GetCurrentUser();

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        Role[] GetAvailableRoles();

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string CreateUser(ref User user);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string UpdateUser(User user);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string ResetPassword(User user);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string ChangePassword(string newPassword);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        User[] GetUsers(string filter);
    }
}
