using System.IO;
using System.Xml.Serialization;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Services.Serialize
{
    internal class SerializeService : ISerializeService
    {
        public string Serialize<T>(T obj) 
            where T : class
        {
            CheckHelper.ArgumentNotNull(obj, "obj");

            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, obj);

                return stringWriter.ToString();
            }
        }

        public T Deserialize<T>(string data) 
            where T : class
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(data, "data");

            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var stringReader = new StringReader(data))
            {
                return (T)xmlSerializer.Deserialize(stringReader);
            }
        }
    }
}
