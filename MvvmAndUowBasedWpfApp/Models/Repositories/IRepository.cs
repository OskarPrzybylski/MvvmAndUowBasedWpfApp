using MvvmAndUowBasedWpfApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvvmAndUowBasedWpfApp.Models.Repositories
{
    public interface IRepository<TEntity> where TEntity : DbEntity
    {
        #region Methods
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        #endregion
    }
}
