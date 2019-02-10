using System.ServiceModel;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    [ServiceContract(Namespace = "http://usclothes.ru/webservice/dictionaryapi")]
    public interface IDictionaryAPI
    {
        #region Brand
        
        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        Brand[] GetBrands(string filter);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string CreateBrand(ref Brand brand);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string UpdateBrand(Brand brand);
        
        #endregion


        #region Category

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        Category[] GetCategories(string filter);

        [OperationContract(Name = "GetSubCategoriesByCategory")]
        [FaultContract(typeof(ErrorData))]
        SubCategory[] GetSubCategories(Category category, string filter);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        SubCategory[] GetSubCategories(string filter);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string CreateCategory(ref Category category);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string UpdateCategory(Category category);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string CreateSubCategory(ref SubCategory subCategory);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string UpdateSubCategory(SubCategory subCategory);
        
        #endregion


        #region Size

        [OperationContract(Name = "GetSizesBySubCategoryAndBrand")]
        [FaultContract(typeof(ErrorData))]
        Size[] GetSizes(SubCategory subCategory, Brand brand, string filter);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        Size[] GetSizes(string filter);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string CreateSize(ref Size size);

        [OperationContract]
        [FaultContract(typeof(ErrorData))]
        string UpdateSize(Size size);

        #endregion
    }
}
