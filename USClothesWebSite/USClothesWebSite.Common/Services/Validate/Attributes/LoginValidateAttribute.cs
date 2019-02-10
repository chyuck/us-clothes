using System;

namespace USClothesWebSite.Common.Services.Validate.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LoginValidateAttribute : ValidateAttribute
    {
        public LoginValidateAttribute(string message)
            : base(message)
        {
        }

        public override bool IsValid(object value)
        {
            return StringValidator.ValidateLogin((string)value);
        }
    }
}
