using MvvmAndUowBasedWpfApp.Models.DbContexts;
using MvvmAndUowBasedWpfApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MvvmAndUowBasedWpfApp.Models.Repositories
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : DbEntity
    {
        #region Fields
        protected readonly DatabaseContext DatabaseContext;
        #endregion
        #region Constructors
        protected GenericRepository(DatabaseContext databaseContext)
        {
            this.DatabaseContext = databaseContext;
        }
        #endregion
        #region Methods
        public virtual void Add(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Add(entity);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DatabaseContext.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual TEntity Get(int id)
        {
            return DatabaseContext.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.DatabaseContext.Set<TEntity>().ToList();
        }

        public virtual void Remove(TEntity entity)
        {
            this.DatabaseContext.Set<TEntity>().Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.DatabaseContext.Set<TEntity>().Update(entity);
        }
        #endregion
    }
}
