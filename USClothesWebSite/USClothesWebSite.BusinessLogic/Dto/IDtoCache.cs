using System;
using USClothesWebSite.DTO;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Dto
{
    internal interface IDtoCache
    {
        TDto Get<TDto, TEntity>(TEntity entity, Func<TEntity, TDto> create, Action<TDto, TEntity> initialize = null)
            where TDto : class, IDto
            where TEntity : class, IEntity;
    }
}
