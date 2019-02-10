using System;
using System.Data.Entity;

namespace USClothesWebSite.DataAccess
{
    public interface IPersistentService : IDisposable
    {
        IDbSet<TEntity> GetEntitySet<TEntity>() 
            where TEntity : class, IEntity, new();
            
        int SaveChanges();
    }
}
