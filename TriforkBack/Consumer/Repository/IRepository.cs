using System;
using System.Collections.Generic;

namespace Consumer.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T Get(Guid id);

        IEnumerable<T> GetAll();

        void Remove(T entity);

    }
}
