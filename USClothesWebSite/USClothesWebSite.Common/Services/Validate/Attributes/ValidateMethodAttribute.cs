using System;

namespace USClothesWebSite.Common.Services.Validate.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ValidateMethodAttribute : Attribute
    {
    }
}
