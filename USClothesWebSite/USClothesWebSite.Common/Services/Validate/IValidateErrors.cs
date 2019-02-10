namespace USClothesWebSite.Common.Services.Validate
{
    public interface IValidateErrors<out T> 
        where T : class
    {
        ValidationError[] Errors { get; }

        T Object { get; }
    }
}
