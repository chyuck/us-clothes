﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USClothesWebSite.Win.Logic.DocumentAPI {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://usclothes.ru/webservice/documentapi", ConfigurationName="DocumentAPI.IDocumentAPI")]
    public interface IDocumentAPI {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetParcels", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetParcelsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetParcelsErrorDataFault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.DTO.Parcel[] GetParcels(System.DateTime startDate, System.DateTime endDate, string filter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetParcels", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetParcelsResponse")]
        System.Threading.Tasks.Task<USClothesWebSite.DTO.Parcel[]> GetParcelsAsync(System.DateTime startDate, System.DateTime endDate, string filter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateParcel", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateParcelResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateParcelErrorDataFaul" +
            "t", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.Win.Logic.DocumentAPI.CreateParcelResponse CreateParcel(USClothesWebSite.Win.Logic.DocumentAPI.CreateParcelRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateParcel", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateParcelResponse")]
        System.Threading.Tasks.Task<USClothesWebSite.Win.Logic.DocumentAPI.CreateParcelResponse> CreateParcelAsync(USClothesWebSite.Win.Logic.DocumentAPI.CreateParcelRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateParcel", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateParcelResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateParcelErrorDataFaul" +
            "t", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        string UpdateParcel(USClothesWebSite.DTO.Parcel parcel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateParcel", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateParcelResponse")]
        System.Threading.Tasks.Task<string> UpdateParcelAsync(USClothesWebSite.DTO.Parcel parcel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrders", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrdersResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrdersErrorDataFault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.DTO.Order[] GetOrders(System.DateTime startDate, System.DateTime endDate, string filter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrders", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrdersResponse")]
        System.Threading.Tasks.Task<USClothesWebSite.DTO.Order[]> GetOrdersAsync(System.DateTime startDate, System.DateTime endDate, string filter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrdersByParcel", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrdersByParcelResponse" +
            "")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrdersByParcelErrorDat" +
            "aFault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.DTO.Order[] GetOrdersByParcel(USClothesWebSite.DTO.Parcel parcel, string filter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrdersByParcel", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrdersByParcelResponse" +
            "")]
        System.Threading.Tasks.Task<USClothesWebSite.DTO.Order[]> GetOrdersByParcelAsync(USClothesWebSite.DTO.Parcel parcel, string filter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateOrder", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateOrderResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateOrderErrorDataFault" +
            "", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderResponse CreateOrder(USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateOrder", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateOrderResponse")]
        System.Threading.Tasks.Task<USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderResponse> CreateOrderAsync(USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateOrder", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateOrderResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateOrderErrorDataFault" +
            "", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        string UpdateOrder(USClothesWebSite.DTO.Order order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateOrder", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateOrderResponse")]
        System.Threading.Tasks.Task<string> UpdateOrderAsync(USClothesWebSite.DTO.Order order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrderItems", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrderItemsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrderItemsErrorDataFau" +
            "lt", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.DTO.OrderItem[] GetOrderItems(USClothesWebSite.DTO.Order order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrderItems", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetOrderItemsResponse")]
        System.Threading.Tasks.Task<USClothesWebSite.DTO.OrderItem[]> GetOrderItemsAsync(USClothesWebSite.DTO.Order order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateOrderItem", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateOrderItemResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateOrderItemErrorDataF" +
            "ault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderItemResponse CreateOrderItem(USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderItemRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateOrderItem", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateOrderItemResponse")]
        System.Threading.Tasks.Task<USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderItemResponse> CreateOrderItemAsync(USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderItemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateOrderItem", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateOrderItemResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateOrderItemErrorDataF" +
            "ault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        string UpdateOrderItem(USClothesWebSite.DTO.OrderItem orderItem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateOrderItem", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateOrderItemResponse")]
        System.Threading.Tasks.Task<string> UpdateOrderItemAsync(USClothesWebSite.DTO.OrderItem orderItem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetDistributorTransfers", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetDistributorTransfersRe" +
            "sponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetDistributorTransfersEr" +
            "rorDataFault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.DTO.DistributorTransfer[] GetDistributorTransfers(USClothesWebSite.DTO.User distributor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetDistributorTransfers", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/GetDistributorTransfersRe" +
            "sponse")]
        System.Threading.Tasks.Task<USClothesWebSite.DTO.DistributorTransfer[]> GetDistributorTransfersAsync(USClothesWebSite.DTO.User distributor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateDistributorTransfer" +
            "", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateDistributorTransfer" +
            "Response")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateDistributorTransfer" +
            "ErrorDataFault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        USClothesWebSite.Win.Logic.DocumentAPI.CreateDistributorTransferResponse CreateDistributorTransfer(USClothesWebSite.Win.Logic.DocumentAPI.CreateDistributorTransferRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateDistributorTransfer" +
            "", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/CreateDistributorTransfer" +
            "Response")]
        System.Threading.Tasks.Task<USClothesWebSite.Win.Logic.DocumentAPI.CreateDistributorTransferResponse> CreateDistributorTransferAsync(USClothesWebSite.Win.Logic.DocumentAPI.CreateDistributorTransferRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateDistributorTransfer" +
            "", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateDistributorTransfer" +
            "Response")]
        [System.ServiceModel.FaultContractAttribute(typeof(USClothesWebSite.DTO.ErrorData), Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateDistributorTransfer" +
            "ErrorDataFault", Name="ErrorData", Namespace="http://usclothes.ru/dto/errordata")]
        string UpdateDistributorTransfer(USClothesWebSite.DTO.DistributorTransfer distributorTransfer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateDistributorTransfer" +
            "", ReplyAction="http://usclothes.ru/webservice/documentapi/IDocumentAPI/UpdateDistributorTransfer" +
            "Response")]
        System.Threading.Tasks.Task<string> UpdateDistributorTransferAsync(USClothesWebSite.DTO.DistributorTransfer distributorTransfer);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateParcel", WrapperNamespace="http://usclothes.ru/webservice/documentapi", IsWrapped=true)]
    public partial class CreateParcelRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/documentapi", Order=0)]
        public USClothesWebSite.DTO.Parcel parcel;
        
        public CreateParcelRequest() {
        }
        
        public CreateParcelRequest(USClothesWebSite.DTO.Parcel parcel) {
            this.parcel = parcel;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateParcelResponse", WrapperNamespace="http://usclothes.ru/webservice/documentapi", IsWrapped=true)]
    public partial class CreateParcelResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/documentapi", Order=0)]
        public string CreateParcelResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/documentapi", Order=1)]
        public USClothesWebSite.DTO.Parcel parcel;
        
        public CreateParcelResponse() {
        }
        
        public CreateParcelResponse(string CreateParcelResult, USClothesWebSite.DTO.Parcel parcel) {
            this.CreateParcelResult = CreateParcelResult;
            this.parcel = parcel;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateOrder", WrapperNamespace="http://usclothes.ru/webservice/documentapi", IsWrapped=true)]
    public partial class CreateOrderRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/documentapi", Order=0)]
        public USClothesWebSite.DTO.Order order;
        
        public CreateOrderRequest() {
        }
        
        public CreateOrderRequest(USClothesWebSite.DTO.Order order) {
            this.order = order;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateOrderResponse", WrapperNamespace="http://usclothes.ru/webservice/documentapi", IsWrapped=true)]
    public partial class CreateOrderResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/documentapi", Order=0)]
        public string CreateOrderResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/documentapi", Order=1)]
        public USClothesWebSite.DTO.Order order;
        
        public CreateOrderResponse() {
        }
        
        public CreateOrderResponse(string CreateOrderResult, USClothesWebSite.DTO.Order order) {
            this.CreateOrderResult = CreateOrderResult;
            this.order = order;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateOrderItem", WrapperNamespace="http://usclothes.ru/webservice/documentapi", IsWrapped=true)]
    public partial class CreateOrderItemRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/documentapi", Order=0)]
        public USClothesWebSite.DTO.OrderItem orderItem;
        
        public CreateOrderItemRequest() {
        }
        
        public CreateOrderItemRequest(USClothesWebSite.DTO.OrderItem orderItem) {
            this.orderItem = orderItem;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateOrderItemResponse", WrapperNamespace="http://usclothes.ru/webservice/documentapi", IsWrapped=true)]
    public partial class CreateOrderItemResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/documentapi", Order=0)]
        public string CreateOrderItemResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/documentapi", Order=1)]
        public USClothesWebSite.DTO.OrderItem orderItem;
        
        public CreateOrderItemResponse() {
        }
        
        public CreateOrderItemResponse(string CreateOrderItemResult, USClothesWebSite.DTO.OrderItem orderItem) {
            this.CreateOrderItemResult = CreateOrderItemResult;
            this.orderItem = orderItem;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateDistributorTransfer", WrapperNamespace="http://usclothes.ru/webservice/documentapi", IsWrapped=true)]
    public partial class CreateDistributorTransferRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/documentapi", Order=0)]
        public USClothesWebSite.DTO.DistributorTransfer distributorTransfer;
        
        public CreateDistributorTransferRequest() {
        }
        
        public CreateDistributorTransferRequest(USClothesWebSite.DTO.DistributorTransfer distributorTransfer) {
            this.distributorTransfer = distributorTransfer;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateDistributorTransferResponse", WrapperNamespace="http://usclothes.ru/webservice/documentapi", IsWrapped=true)]
    public partial class CreateDistributorTransferResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/documentapi", Order=0)]
        public string CreateDistributorTransferResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://usclothes.ru/webservice/documentapi", Order=1)]
        public USClothesWebSite.DTO.DistributorTransfer distributorTransfer;
        
        public CreateDistributorTransferResponse() {
        }
        
        public CreateDistributorTransferResponse(string CreateDistributorTransferResult, USClothesWebSite.DTO.DistributorTransfer distributorTransfer) {
            this.CreateDistributorTransferResult = CreateDistributorTransferResult;
            this.distributorTransfer = distributorTransfer;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDocumentAPIChannel : USClothesWebSite.Win.Logic.DocumentAPI.IDocumentAPI, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DocumentAPIClient : System.ServiceModel.ClientBase<USClothesWebSite.Win.Logic.DocumentAPI.IDocumentAPI>, USClothesWebSite.Win.Logic.DocumentAPI.IDocumentAPI {
        
        public DocumentAPIClient() {
        }
        
        public DocumentAPIClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DocumentAPIClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DocumentAPIClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DocumentAPIClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public USClothesWebSite.DTO.Parcel[] GetParcels(System.DateTime startDate, System.DateTime endDate, string filter) {
            return base.Channel.GetParcels(startDate, endDate, filter);
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.DTO.Parcel[]> GetParcelsAsync(System.DateTime startDate, System.DateTime endDate, string filter) {
            return base.Channel.GetParcelsAsync(startDate, endDate, filter);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        USClothesWebSite.Win.Logic.DocumentAPI.CreateParcelResponse USClothesWebSite.Win.Logic.DocumentAPI.IDocumentAPI.CreateParcel(USClothesWebSite.Win.Logic.DocumentAPI.CreateParcelRequest request) {
            return base.Channel.CreateParcel(request);
        }
        
        public string CreateParcel(ref USClothesWebSite.DTO.Parcel parcel) {
            USClothesWebSite.Win.Logic.DocumentAPI.CreateParcelRequest inValue = new USClothesWebSite.Win.Logic.DocumentAPI.CreateParcelRequest();
            inValue.parcel = parcel;
            USClothesWebSite.Win.Logic.DocumentAPI.CreateParcelResponse retVal = ((USClothesWebSite.Win.Logic.DocumentAPI.IDocumentAPI)(this)).CreateParcel(inValue);
            parcel = retVal.parcel;
            return retVal.CreateParcelResult;
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.Win.Logic.DocumentAPI.CreateParcelResponse> CreateParcelAsync(USClothesWebSite.Win.Logic.DocumentAPI.CreateParcelRequest request) {
            return base.Channel.CreateParcelAsync(request);
        }
        
        public string UpdateParcel(USClothesWebSite.DTO.Parcel parcel) {
            return base.Channel.UpdateParcel(parcel);
        }
        
        public System.Threading.Tasks.Task<string> UpdateParcelAsync(USClothesWebSite.DTO.Parcel parcel) {
            return base.Channel.UpdateParcelAsync(parcel);
        }
        
        public USClothesWebSite.DTO.Order[] GetOrders(System.DateTime startDate, System.DateTime endDate, string filter) {
            return base.Channel.GetOrders(startDate, endDate, filter);
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.DTO.Order[]> GetOrdersAsync(System.DateTime startDate, System.DateTime endDate, string filter) {
            return base.Channel.GetOrdersAsync(startDate, endDate, filter);
        }
        
        public USClothesWebSite.DTO.Order[] GetOrdersByParcel(USClothesWebSite.DTO.Parcel parcel, string filter) {
            return base.Channel.GetOrdersByParcel(parcel, filter);
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.DTO.Order[]> GetOrdersByParcelAsync(USClothesWebSite.DTO.Parcel parcel, string filter) {
            return base.Channel.GetOrdersByParcelAsync(parcel, filter);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderResponse USClothesWebSite.Win.Logic.DocumentAPI.IDocumentAPI.CreateOrder(USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderRequest request) {
            return base.Channel.CreateOrder(request);
        }
        
        public string CreateOrder(ref USClothesWebSite.DTO.Order order) {
            USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderRequest inValue = new USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderRequest();
            inValue.order = order;
            USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderResponse retVal = ((USClothesWebSite.Win.Logic.DocumentAPI.IDocumentAPI)(this)).CreateOrder(inValue);
            order = retVal.order;
            return retVal.CreateOrderResult;
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderResponse> CreateOrderAsync(USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderRequest request) {
            return base.Channel.CreateOrderAsync(request);
        }
        
        public string UpdateOrder(USClothesWebSite.DTO.Order order) {
            return base.Channel.UpdateOrder(order);
        }
        
        public System.Threading.Tasks.Task<string> UpdateOrderAsync(USClothesWebSite.DTO.Order order) {
            return base.Channel.UpdateOrderAsync(order);
        }
        
        public USClothesWebSite.DTO.OrderItem[] GetOrderItems(USClothesWebSite.DTO.Order order) {
            return base.Channel.GetOrderItems(order);
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.DTO.OrderItem[]> GetOrderItemsAsync(USClothesWebSite.DTO.Order order) {
            return base.Channel.GetOrderItemsAsync(order);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderItemResponse USClothesWebSite.Win.Logic.DocumentAPI.IDocumentAPI.CreateOrderItem(USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderItemRequest request) {
            return base.Channel.CreateOrderItem(request);
        }
        
        public string CreateOrderItem(ref USClothesWebSite.DTO.OrderItem orderItem) {
            USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderItemRequest inValue = new USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderItemRequest();
            inValue.orderItem = orderItem;
            USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderItemResponse retVal = ((USClothesWebSite.Win.Logic.DocumentAPI.IDocumentAPI)(this)).CreateOrderItem(inValue);
            orderItem = retVal.orderItem;
            return retVal.CreateOrderItemResult;
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderItemResponse> CreateOrderItemAsync(USClothesWebSite.Win.Logic.DocumentAPI.CreateOrderItemRequest request) {
            return base.Channel.CreateOrderItemAsync(request);
        }
        
        public string UpdateOrderItem(USClothesWebSite.DTO.OrderItem orderItem) {
            return base.Channel.UpdateOrderItem(orderItem);
        }
        
        public System.Threading.Tasks.Task<string> UpdateOrderItemAsync(USClothesWebSite.DTO.OrderItem orderItem) {
            return base.Channel.UpdateOrderItemAsync(orderItem);
        }
        
        public USClothesWebSite.DTO.DistributorTransfer[] GetDistributorTransfers(USClothesWebSite.DTO.User distributor) {
            return base.Channel.GetDistributorTransfers(distributor);
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.DTO.DistributorTransfer[]> GetDistributorTransfersAsync(USClothesWebSite.DTO.User distributor) {
            return base.Channel.GetDistributorTransfersAsync(distributor);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        USClothesWebSite.Win.Logic.DocumentAPI.CreateDistributorTransferResponse USClothesWebSite.Win.Logic.DocumentAPI.IDocumentAPI.CreateDistributorTransfer(USClothesWebSite.Win.Logic.DocumentAPI.CreateDistributorTransferRequest request) {
            return base.Channel.CreateDistributorTransfer(request);
        }
        
        public string CreateDistributorTransfer(ref USClothesWebSite.DTO.DistributorTransfer distributorTransfer) {
            USClothesWebSite.Win.Logic.DocumentAPI.CreateDistributorTransferRequest inValue = new USClothesWebSite.Win.Logic.DocumentAPI.CreateDistributorTransferRequest();
            inValue.distributorTransfer = distributorTransfer;
            USClothesWebSite.Win.Logic.DocumentAPI.CreateDistributorTransferResponse retVal = ((USClothesWebSite.Win.Logic.DocumentAPI.IDocumentAPI)(this)).CreateDistributorTransfer(inValue);
            distributorTransfer = retVal.distributorTransfer;
            return retVal.CreateDistributorTransferResult;
        }
        
        public System.Threading.Tasks.Task<USClothesWebSite.Win.Logic.DocumentAPI.CreateDistributorTransferResponse> CreateDistributorTransferAsync(USClothesWebSite.Win.Logic.DocumentAPI.CreateDistributorTransferRequest request) {
            return base.Channel.CreateDistributorTransferAsync(request);
        }
        
        public string UpdateDistributorTransfer(USClothesWebSite.DTO.DistributorTransfer distributorTransfer) {
            return base.Channel.UpdateDistributorTransfer(distributorTransfer);
        }
        
        public System.Threading.Tasks.Task<string> UpdateDistributorTransferAsync(USClothesWebSite.DTO.DistributorTransfer distributorTransfer) {
            return base.Channel.UpdateDistributorTransferAsync(distributorTransfer);
        }
    }
}
