using System;

namespace USClothesWebSite.Common.Services.Validate.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IdValidateAttribute : ValidateAttribute
    {
        public IdValidateAttribute() 
            : base("Id должно быть больше или ровно 0.")
        {
        }

        public override bool IsValid(object value)
        {
            var i = (int)value;

            return i >= 0;
        }
    }
}
