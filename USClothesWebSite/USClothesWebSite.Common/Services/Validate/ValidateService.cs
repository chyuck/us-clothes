using System.Reflection;
using System.Linq;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.Common.Services.Validate
{
    internal class ValidateService : IValidateService
    {
        public IValidateErrors<T> Validate<T>(T obj)
             where T : class
        {
            CheckHelper.ArgumentNotNull(obj, "obj");

            const BindingFlags BINDING_ATTR = 
                BindingFlags.Instance | 
                BindingFlags.Public | 
                BindingFlags.NonPublic |
                BindingFlags.Static;

            // Properties
            var propertiesValidationErrors =
                from property in typeof(T).GetProperties(BINDING_ATTR) 
                let attribute = 
                    property
                        .GetCustomAttributes<ValidateAttribute>(true)
                        .SingleOrDefault()
                where attribute != null 
                let value = property.GetValue(obj, null) 
                let isValid = attribute.IsValid(value) 
                where !isValid 
                select new ValidationError(attribute.Key ?? property.Name, attribute.Message);

            // Methods
            var methodsValidationErrors =
                from method in typeof(T).GetMethods(BINDING_ATTR)
                let attribute =
                    method
                        .GetCustomAttributes<ValidateMethodAttribute>(true)
                        .SingleOrDefault()
                where attribute != null
                      && !method.GetParameters().Any()
                      && method.ReturnType == typeof(ValidationError)
                let result = (ValidationError) method.Invoke(obj, null)
                where result != null
                select result;

            var validationErrors = 
                propertiesValidationErrors
                    .Concat(methodsValidationErrors)
                    .Distinct()
                    .ToArray();

            return validationErrors.Length > 0 ? new ValidateErrors<T>(obj, validationErrors) : null;
        }
        
        public bool IsValid<T>(T obj) 
            where T : class
        {
            CheckHelper.ArgumentNotNull(obj, "obj");

            var errors = Validate(obj);

            return errors == null;
        }
        
        public void CheckIsValid<T>(T obj) 
            where T : class
        {
            CheckHelper.ArgumentNotNull(obj, "obj");

            var errors = Validate(obj);

            if  (errors != null)
                throw new ValidateException<T>(errors);
        }
    }
}
