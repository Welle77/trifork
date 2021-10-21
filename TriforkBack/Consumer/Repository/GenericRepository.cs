using Consumer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Repository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected TimestampContext context;
        public GenericRepository(TimestampContext context)
        {
            this.context = context;
        }

        async Task IRepository<T>.Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        async Task<T> IRepository<T>.Get(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        Task IRepository<T>.Update(T entity)
        {
            context.Update(entity);
            return context.SaveChangesAsync();
        }

        Task IRepository<T>.Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChangesAsync();
        }

        async Task IRepository<T>.SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
