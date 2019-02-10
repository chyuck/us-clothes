using System;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Services.LocalizedName
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class LocalizedNameAttribute : Attribute
    {
        public LocalizedNameAttribute(string single, string plural)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(single, "single");
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(plural, "plural");

            Single = single;
            Plural = plural;
        }

        public string Single { get; private set; }
        public string Plural { get; private set; }
    }
}
