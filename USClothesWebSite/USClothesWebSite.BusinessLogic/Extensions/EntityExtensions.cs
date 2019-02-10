using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Extensions
{
    public static class EntityExtensions
    {
        public static bool IsNew(this IEntity entity)
        {
            CheckHelper.ArgumentNotNull(entity, "entity");

            return entity.Id <= 0;
        }
    }
}
