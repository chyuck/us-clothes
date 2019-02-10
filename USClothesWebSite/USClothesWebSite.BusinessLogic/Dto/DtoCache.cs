using System;
using System.Collections.Generic;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Dto
{
    internal class DtoCache : IDtoCache
    {
        private readonly IDictionary<Type, IDictionary<int, IDto>> _dtoCache = 
            new Dictionary<Type, IDictionary<int, IDto>>();

        public TDto Get<TDto, TEntity>(TEntity entity, Func<TEntity, TDto> create, Action<TDto, TEntity> initialize = null)
            where TDto : class, IDto
            where TEntity : class, IEntity
        {
            CheckHelper.ArgumentNotNull(entity, "entity");
            CheckHelper.WithinCondition(!entity.IsNew(), "!entity.IsNew()");
            CheckHelper.ArgumentNotNull(create, "create");

            var dtoType = typeof (TDto);
            var id = entity.Id;

            IDictionary<int, IDto> dtoObjects;
            if (!_dtoCache.TryGetValue(dtoType, out dtoObjects))
            {
                dtoObjects = new Dictionary<int, IDto>();
                _dtoCache.Add(dtoType, dtoObjects);
            }

            IDto dtoObject;
            if (!dtoObjects.TryGetValue(id, out dtoObject))
            {
                dtoObject = create(entity);
                dtoObjects.Add(id, dtoObject);
                
                if (initialize != null)
                    initialize((TDto)dtoObject, entity);
            }

            return (TDto)dtoObject;
        }
    }
}
