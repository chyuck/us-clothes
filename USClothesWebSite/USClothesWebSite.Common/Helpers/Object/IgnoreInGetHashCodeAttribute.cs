using System;

namespace USClothesWebSite.Common.Helpers.Object
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class IgnoreInGetHashCodeAttribute : Attribute
    {
    }
}
