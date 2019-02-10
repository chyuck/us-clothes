using System;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Services.Validate.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public abstract class ValidateAttribute : Attribute
    {
        protected ValidateAttribute(string message)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(message, "message");

            Message = message;
        }

        public string Message { get; private set; }

        public string Key { get; set; }

        public abstract bool IsValid(object value);
    }
}
