using System.Linq;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Extensions
{
    internal static class PersistentServiceExtensions
    {
        public static TEntity GetEntityById<TEntity>(this IPersistentService persistentService, int id)
            where TEntity : class, IEntity, new()
        {
            CheckHelper.ArgumentNotNull(persistentService, "persistentService");
            CheckHelper.ArgumentWithinCondition(id > 0, "id > 0");

            return 
                persistentService
                    .GetEntitySet<TEntity>()
                    .SingleOrDefault(e => e.Id == id);
        }

        public static IQueryable<TActivatedEntity> GetActiveEntities<TActivatedEntity>(this IPersistentService persistentService)
            where TActivatedEntity : class, IEntity, IActivatedEntity, new()
        {
            CheckHelper.ArgumentNotNull(persistentService, "persistentService");

            return 
                persistentService
                    .GetEntitySet<TActivatedEntity>()
                    .Where(e => e.Active);
        }

        public static void Add<TEntity>(this IPersistentService persistentService, TEntity entity)
            where TEntity : class, IEntity, new()
        {
            CheckHelper.ArgumentNotNull(persistentService, "persistentService");
            CheckHelper.ArgumentNotNull(entity, "entity");

            persistentService
                .GetEntitySet<TEntity>()
                .Add(entity);
        }
    }
}
