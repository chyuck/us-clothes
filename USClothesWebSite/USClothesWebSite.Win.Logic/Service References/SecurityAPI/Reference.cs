﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USClothesWebSite.Win.Logic.SecurityAPI {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://usclothes.ru/webservice/securityapi", ConfigurationName="SecurityAPI.ISecurityAPI")]
    public interface ISecurityAPI {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/LogIn", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/LogInResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/LogInErrorDataFault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        string LogIn(USClothesWebSite.DTO.SecurityData securityData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/LogIn", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/LogInResponse")]
        System.Threading.Tasks.Task<string> LogInAsync(USClothesWebSite.DTO.SecurityData securityData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetCurrentUser", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetCurrentUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetCurrentUserErrorDataFa" +
            "ult", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.DTO.User GetCurrentUser();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetCurrentUser", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetCurrentUserResponse")]
        System.Threading.Tasks.Task<USClothesWebSite.DTO.User> GetCurrentUserAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetAvailableRoles", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetAvailableRolesResponse" +
            "")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetAvailableRolesErrorDat" +
            "aFault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.DTO.Role[] GetAvailableRoles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetAvailableRoles", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetAvailableRolesResponse" +
            "")]
        System.Threading.Tasks.Task<USClothesWebSite.DTO.Role[]> GetAvailableRolesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/CreateUser", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/CreateUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/CreateUserErrorDataFault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.Win.Logic.SecurityAPI.CreateUserResponse CreateUser(USClothesWebSite.Win.Logic.SecurityAPI.CreateUserRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/CreateUser", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/CreateUserResponse")]
        System.Threading.Tasks.Task<USClothesWebSite.Win.Logic.SecurityAPI.CreateUserResponse> CreateUserAsync(USClothesWebSite.Win.Logic.SecurityAPI.CreateUserRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/UpdateUser", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/UpdateUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/UpdateUserErrorDataFault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        string UpdateUser(USClothesWebSite.DTO.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/UpdateUser", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/UpdateUserResponse")]
        System.Threading.Tasks.Task<string> UpdateUserAsync(USClothesWebSite.DTO.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/ResetPassword", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/ResetPasswordResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/ResetPasswordErrorDataFau" +
            "lt", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        string ResetPassword(USClothesWebSite.DTO.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/ResetPassword", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/ResetPasswordResponse")]
        System.Threading.Tasks.Task<string> ResetPasswordAsync(USClothesWebSite.DTO.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/ChangePassword", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/ChangePasswordResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/ChangePasswordErrorDataFa" +
            "ult", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        string ChangePassword(string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/ChangePassword", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/ChangePasswordResponse")]
        System.Threading.Tasks.Task<string> ChangePasswordAsync(string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetUsers", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetUsersResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetUsersErrorDataFault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.DTO.User[] GetUsers(string filter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetUsers", ReplyAction="http://usclothes.ru/webservice/securityapi/ISecurityAPI/GetUsersResponse")]
        System.Threading.Tasks.Task<USClothesWebSite.DTO.User[]> GetUsersAsync(string filter);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateUser", WrapperNamespace="http://usclothes.ru/webservice/securityapi", IsWrapped=true)]
    public partial class CreateUserRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/securityapi", Order=0)]
        public USClothesWebSite.DTO.User user;
        
        public CreateUserRequest() {
        }
        
        public CreateUserRequest(USClothesWebSite.DTO.User user) {
            this.user = user;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateUserResponse", WrapperNamespace="http://usclothes.ru/webservice/securityapi", IsWrapped=true)]
    public partial class CreateUserResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/securityapi", Order=0)]
        public string CreateUserResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/securityapi", Order=1)]
        public USClothesWebSite.DTO.User user;
        
        public CreateUserResponse() {
        }
        
        public CreateUserResponse(string CreateUserResult, USClothesWebSite.DTO.User user) {
            this.CreateUserResult = CreateUserResult;
            this.user = user;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISecurityAPIChannel : USClothesWebSite.Win.Logic.SecurityAPI.ISecurityAPI, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SecurityAPIClient : System.ServiceModel.ClientBase<USClothesWebSite.Win.Logic.SecurityAPI.ISecurityAPI>, USClothesWebSite.Win.Logic.SecurityAPI.ISecurityAPI {
        
        public SecurityAPIClient() {
        }
        
        public SecurityAPIClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SecurityAPIClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SecurityAPIClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SecurityAPIClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string LogIn(USClothesWebSite.DTO.SecurityData securityData) {
            return base.Channel.LogIn(securityData);
        }
        
        public System.Threading.Tasks.Task<string> LogInAsync(USClothesWebSite.DTO.SecurityData securityData) {
            return base.Channel.LogInAsync(securityData);
        }
        
        public USClothesWebSite.DTO.User GetCurrentUser() {
            return base.Channel.GetCurrentUser();
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.DTO.User> GetCurrentUserAsync() {
            return base.Channel.GetCurrentUserAsync();
        }
        
        public USClothesWebSite.DTO.Role[] GetAvailableRoles() {
            return base.Channel.GetAvailableRoles();
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.DTO.Role[]> GetAvailableRolesAsync() {
            return base.Channel.GetAvailableRolesAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        USClothesWebSite.Win.Logic.SecurityAPI.CreateUserResponse USClothesWebSite.Win.Logic.SecurityAPI.ISecurityAPI.CreateUser(USClothesWebSite.Win.Logic.SecurityAPI.CreateUserRequest request) {
            return base.Channel.CreateUser(request);
        }
        
        public string CreateUser(ref USClothesWebSite.DTO.User user) {
            USClothesWebSite.Win.Logic.SecurityAPI.CreateUserRequest inValue = new USClothesWebSite.Win.Logic.SecurityAPI.CreateUserRequest();
            inValue.user = user;
            USClothesWebSite.Win.Logic.SecurityAPI.CreateUserResponse retVal = ((USClothesWebSite.Win.Logic.SecurityAPI.ISecurityAPI)(this)).CreateUser(inValue);
            user = retVal.user;
            return retVal.CreateUserResult;
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.Win.Logic.SecurityAPI.CreateUserResponse> CreateUserAsync(USClothesWebSite.Win.Logic.SecurityAPI.CreateUserRequest request) {
            return base.Channel.CreateUserAsync(request);
        }
        
        public string UpdateUser(USClothesWebSite.DTO.User user) {
            return base.Channel.UpdateUser(user);
        }
        
        public System.Threading.Tasks.Task<string> UpdateUserAsync(USClothesWebSite.DTO.User user) {
            return base.Channel.UpdateUserAsync(user);
        }
        
        public string ResetPassword(USClothesWebSite.DTO.User user) {
            return base.Channel.ResetPassword(user);
        }
        
        public System.Threading.Tasks.Task<string> ResetPasswordAsync(USClothesWebSite.DTO.User user) {
            return base.Channel.ResetPasswordAsync(user);
        }
        
        public string ChangePassword(string newPassword) {
            return base.Channel.ChangePassword(newPassword);
        }
        
        public System.Threading.Tasks.Task<string> ChangePasswordAsync(string newPassword) {
            return base.Channel.ChangePasswordAsync(newPassword);
        }
        
        public USClothesWebSite.DTO.User[] GetUsers(string filter) {
            return base.Channel.GetUsers(filter);
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.DTO.User[]> GetUsersAsync(string filter) {
            return base.Channel.GetUsersAsync(filter);
        }
    }
}