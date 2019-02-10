using System.Data.Entity;

namespace USClothesWebSite.DataAccess
{
    internal partial class USClothesShopEntities : IPersistentService
    {
        public IDbSet<TEntity> GetEntitySet<TEntity>()
            where TEntity : class, IEntity, new()
        {
            return Set<TEntity>();
        }
    }
}
