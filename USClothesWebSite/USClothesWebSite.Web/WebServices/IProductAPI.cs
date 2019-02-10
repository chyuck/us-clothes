using System;
using System.ServiceModel;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    [ServiceContract(Namespace = "http://usclothes.ru/webservice/productapi")]
    public interface IProductAPI
    {
        [Obsolete]
        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        Product[] GetProducts(string filter);

        [OperationContract(Name = "GetProductsByDate")]
        [FaultContract(typeof(ErrorData))]
        Product[] GetProducts(DateTime startDate, DateTime endDate, string filter);

        [OperationContract(Name = "GetProductSizesByProduct")]
        [FaultContract(typeof(ErrorData))]
        ProductSize[] GetProductSizes(Product product, string filter);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        ProductSize[] GetProductSizes(string filter);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string CreateProduct(ref Product product);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string UpdateProduct(Product product);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string CreateProductSize(ref ProductSize productSize);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string UpdateProductSize(ProductSize productSize);
    }
}
