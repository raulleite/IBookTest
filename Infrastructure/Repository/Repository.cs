using System.Collections.Generic;
using System.Linq;
using DomainBook.Repository;
using System.Data.Entity;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Get(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> Get()
        {
            return dbContext.Set<T>().ToList();
        }

        public void Put(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void Put(IEnumerable<T> listEntity)
        {
            dbContext.Set<T>().AddRange(listEntity);
        }

        public void Del(int id)
        {
            this.Del(this.Get(id));
        }

        public void Del(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }
    }
}