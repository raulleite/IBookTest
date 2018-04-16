using Services.Interface;
using System.Collections.Generic;
using DomainBook.Entity;
using DomainBook.Service;
using DomainBook.UnitOfWork;

namespace Services.Service
{
    public class ServiceForBook : IServiceBook
    {
        ServiceBook serviceBook;

        public ServiceForBook(IUnitOfWorkBook UnitOfWorkBook)
        {
            serviceBook = new ServiceBook(UnitOfWorkBook);
        }

        public void DelBook(int id)
        {
            serviceBook.Del(id);
        }

        public void DelBook(Book book)
        {
            serviceBook.Del(book);
        }

        public Book GetBook(int id)
        {
            return serviceBook.Get(id);
        }

        public List<Book> GetBooks()
        {
            return serviceBook.Get();
        }

        public void PutBook(Book book)
        {
            serviceBook.Put(book);
        }
    }
}
