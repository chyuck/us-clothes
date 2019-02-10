using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Services.Validate
{
    public sealed class ValidateErrors<T> : IValidateErrors<T> 
        where T : class
    {
        public ValidateErrors(T obj, ValidationError[] errors)
        {
            CheckHelper.ArgumentNotNull(obj, "obj");
            CheckHelper.ArgumentNotNull(errors, "errors");
            CheckHelper.ArgumentWithinCondition(errors.Length > 0, "errors.Length > 0");

            Object = obj;
            Errors = errors;
        } 

        public T Object { get; private set; }

        public ValidationError[] Errors { get; private set; }
    }
}
