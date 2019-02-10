using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public class DbSetMock<TEntity> : IDbSet<TEntity>
        where TEntity : class, IEntity, new()
    {
        #region Fields

        private readonly HashSet<TEntity> _collection;

        #endregion


        #region Constructors

        public DbSetMock(IEnumerable<TEntity> collection)
        {
            CheckHelper.ArgumentNotNull(collection, "collection");

            _collection = new HashSet<TEntity>(collection);
        }

        #endregion


        #region IDbSet{T} Implementation

        public TEntity Add(TEntity entity)
        {
            CheckHelper.ArgumentNotNull(entity, "entity");

            _collection.Add(entity);

            return entity;
        }

        public TEntity Attach(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TDerivedEntity Create<TDerivedEntity>() 
            where TDerivedEntity : class, TEntity
        {
            throw new NotImplementedException();
        }

        public TEntity Create()
        {
            return new TEntity();
        }

        public TEntity Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<TEntity> Local
        {
            get { throw new NotImplementedException(); }
        }

        public TEntity Remove(TEntity entity)
        {
            CheckHelper.ArgumentNotNull(entity, "entity");

            _collection.Remove(entity);

            return entity;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        public Type ElementType
        {
            get { return _collection.AsQueryable().ElementType; }
        }

        public Expression Expression
        {
            get { return _collection.AsQueryable().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return _collection.AsQueryable().Provider; }
        }

        #endregion
    }
}
