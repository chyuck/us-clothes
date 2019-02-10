using System;

namespace USClothesWebSite.Common.Services.Validate.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IntegerValidateAttribute : ValidateAttribute
    {
        public IntegerValidateAttribute(string message)
            : base(message)
        {
            MinValue = int.MinValue;
            MaxValue = int.MaxValue;
        }

        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public override bool IsValid(object value)
        {
            var i = (int) value;

            return MinValue <= i && i <= MaxValue;
        }
    }
}
