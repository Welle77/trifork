using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Repository
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task<T> Get(Guid id);

        Task Update(T entity);
        Task Delete(T entity);

        Task SaveChanges();
    }
}
