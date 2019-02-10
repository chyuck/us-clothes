using System;

namespace USClothesWebSite.Common.Services.LocalizedName
{
    public interface ILocalizedNameService
    {
        string GetSingleLocalizedName<T>()
            where T : class;

        string GetSingleLocalizedName(Type type);

        string GetPluralLocalizedName<T>()
            where T : class;

        string GetPluralLocalizedName(Type type);
    }
}
