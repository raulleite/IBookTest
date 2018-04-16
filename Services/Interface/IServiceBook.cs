using DomainBook.Entity;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IServiceBook
    {
        Book GetBook(int id);
        List<Book> GetBooks();
        void PutBook(Book book);
        void DelBook(int id);
        void DelBook(Book book);
    }
}
