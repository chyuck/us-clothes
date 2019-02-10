using System;

namespace USClothesWebSite.Common.Services.Validate.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class EmailValidateAttribute : ValidateAttribute
    {
        public EmailValidateAttribute(string message)
            : base(message)
        {
            CanBeNull = false;
            CanBeEmpty = false;
        }

        public bool CanBeNull { get; set; }
        public bool CanBeEmpty { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
                return CanBeNull;

            var stringValue = (string) value;
            
            if (stringValue == string.Empty)
                return CanBeEmpty;

            return StringValidator.ValidateEmail(stringValue);
        }
    }
}
