using System.Collections.Generic;

namespace DomainBook.Repository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> Get();
        void Put(T entity);
        void Del(int id);
        void Del(T entity);
    }
}
