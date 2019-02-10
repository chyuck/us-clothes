namespace USClothesWebSite.Common.Services.Validate
{
    public interface IValidateService
    {
        IValidateErrors<T> Validate<T>(T obj) 
            where T : class;

        bool IsValid<T>(T obj)
            where T : class;

        void CheckIsValid<T>(T obj)
           where T : class;
    }
}
