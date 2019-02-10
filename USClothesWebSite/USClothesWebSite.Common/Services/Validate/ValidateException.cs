using System;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Services.Validate
{
    public class ValidateException<T> : Exception
        where T : class
    {
        public ValidateException(IValidateErrors<T> errors)
            : base(errors.ToExceptionMessage())
        {
            CheckHelper.ArgumentNotNull(errors, "errors");

            Errors = errors;
        }

        public IValidateErrors<T> Errors { get; private set; }
    }
}
