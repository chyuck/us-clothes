namespace USClothesWebSite.Common.Services.Serialize
{
    public interface ISerializeService
    {
        string Serialize<T>(T obj) 
            where T : class;

        T Deserialize<T>(string data)
            where T : class;
    }
}
