using USClothesWebSite.Common.Services.Serialize;

namespace USClothesWebSite.Common.Helpers
{
    public static class SerializeHelper
    {
        public static string Serialize<T>(T obj)
            where T : class
        {
            CheckHelper.ArgumentNotNull(obj, "obj");

            var serializeService = new SerializeService();

            return serializeService.Serialize(obj);
        }

        public static T Deserialize<T>(string data)
            where T : class
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(data, "data");

            var serializeService = new SerializeService();

            return serializeService.Deserialize<T>(data);
        }
    }
}
