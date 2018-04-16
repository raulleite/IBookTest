using DomainBook.Entity;
using System.Collections.Generic;

namespace DomainBook.Repository
{
    public interface IRepositoryBook : IRepository<Book>
    {
        Book Get(int id);
        List<Book> Get();
        void Put(Book book);
        void Del(int id);
        void Del(Book book);
    }
}
