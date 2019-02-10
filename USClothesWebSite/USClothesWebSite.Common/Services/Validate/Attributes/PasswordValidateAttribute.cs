using System;

namespace USClothesWebSite.Common.Services.Validate.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PasswordValidateAttribute : ValidateAttribute
    {
        public PasswordValidateAttribute(string message) 
            : base(message)
        {
        }

        public override bool IsValid(object value)
        {
            return StringValidator.ValidatePassword((string)value);
        }
    }
}
