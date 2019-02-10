using System;

namespace USClothesWebSite.Common.Services.Validate.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NullableDecimalValidateAttribute : DecimalValidateAttribute
    {
        public NullableDecimalValidateAttribute(string message) 
            : base(message)
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            return base.IsValid(value);
        }
    }
}
