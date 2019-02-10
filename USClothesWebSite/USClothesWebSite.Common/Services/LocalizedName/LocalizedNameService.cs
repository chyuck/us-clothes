using System;
using System.Linq;
using System.Reflection;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Services.LocalizedName
{
    internal class LocalizedNameService : ILocalizedNameService
    {
        private LocalizedNameAttribute GetAttribute(Type type)
        {
            CheckHelper.ArgumentNotNull(type, "type");

            return
                type
                    .GetCustomAttributes<LocalizedNameAttribute>(false)
                    .Single();
        }

        public string GetSingleLocalizedName<T>() where T : class
        {
            return GetSingleLocalizedName(typeof(T));
        }
        
        public string GetSingleLocalizedName(Type type)
        {
            return GetAttribute(type).Single;
        }
        
        public string GetPluralLocalizedName<T>() where T : class
        {
            return GetPluralLocalizedName(typeof(T));
        }

        public string GetPluralLocalizedName(Type type)
        {
            return GetAttribute(type).Plural;
        }
    }
}
