namespace USClothesWebSite.DataAccess
{
    public interface IActivatedEntity : IEntity
    {
        bool Active { get; set; }
    }
}
