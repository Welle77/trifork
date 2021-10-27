using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Consumer.Repository
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public GenericRepository(DbContext context)
        {
            Context = context;
        }

        public virtual void Add(TEntity entity)
        {
            Context.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            Context.Remove(entity);
        }

        public virtual TEntity Get(Guid id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
    }
}
