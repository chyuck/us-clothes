using System;

namespace USClothesWebSite.Common.Helpers
{
    public static class CacheHelper
    {
        public static T Get<T>(ref T instance, Func<T> createInstance)
            where T : class
        {
            CheckHelper.ArgumentNotNull(createInstance, "createInstance");

            if (instance == null)
                instance = createInstance();

            return instance;
        }

        public static T Get<T>(ref T instance)
            where T : class, new()
        {
            return Get(ref instance, () => new T());
        }
    }
}
