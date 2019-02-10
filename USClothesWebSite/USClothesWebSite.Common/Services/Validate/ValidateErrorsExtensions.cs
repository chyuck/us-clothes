using System.Linq;
using System.Text;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Services.Validate
{
    public static class ValidateErrorsExtensions
    {
        public static string ToExceptionMessage<T>(this IValidateErrors<T> validateErrors)
            where T : class
        {
            CheckHelper.ArgumentNotNull(validateErrors, "validateErrors");

            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Invalid object: ");
            stringBuilder.AppendLine(validateErrors.Object.ToString());
            stringBuilder.AppendLine("Errors: ");

            foreach (var error in validateErrors.Errors)
            {
                stringBuilder.Append("Key: ");
                stringBuilder.Append(error.Key);
                stringBuilder.Append(" Message: ");
                stringBuilder.AppendLine(error.Message);
            }

            return stringBuilder.ToString();
        }

        public static string ToErrorMessage<T>(this IValidateErrors<T> validateErrors)
            where T : class
        {
            CheckHelper.ArgumentNotNull(validateErrors, "validateErrors");

            if (!validateErrors.Errors.Any())
                return null;

            var stringBuilder = new StringBuilder();

            validateErrors.Errors.ForEach(e => stringBuilder.AppendLine(e.Message));

            return stringBuilder.ToString();
        }
    }
}
