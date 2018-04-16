using DomainBook.Entity;
using DomainBook.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace DomainBook.Service
{
    public class ServiceBook
    {
        protected IUnitOfWorkBook UnitOfWorkBook { get; private set; }

        public ServiceBook(IUnitOfWorkBook UnitOfWorkBook)
        {
            this.UnitOfWorkBook = UnitOfWorkBook;
        }

        public List<Book> Get()
        {
            return UnitOfWorkBook.RepositoryBook.Get().ToList();
        }

        public Book Get(int id)
        {
            return UnitOfWorkBook.RepositoryBook.Get(id);
        }

        public void Put(Book book)
        {
            UnitOfWorkBook.RepositoryBook.Put(book);
            UnitOfWorkBook.Save();
        }

        public void Del(int id)
        {
            UnitOfWorkBook.RepositoryBook.Del(id);
            UnitOfWorkBook.Save();
        }

        public void Del(Book book)
        {
            UnitOfWorkBook.RepositoryBook.Del(book);
            UnitOfWorkBook.Save();
        }
    }
}
