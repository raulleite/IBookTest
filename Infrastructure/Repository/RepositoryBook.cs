using System.Collections.Generic;
using System.Linq;
using DomainBook.Entity;
using DomainBook.Repository;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class RepositoryBook : Repository<Book>, IRepositoryBook
    {
        public RepositoryBook(BookContext bookContext)
        :base(bookContext)
        {

        }

        public BookContext bookContext
        {
            get
            {
                return (dbContext as BookContext);
            }
        }

        public Book Get(int id)
        {
            return bookContext.Books
                .Where(c => c.id == id)
                .SingleOrDefault();
        }

        public List<Book> Get()
        {
            return bookContext.Books.OrderBy(i => i.title).ToList();
        }

        public void Put(Book book)
        {
            Book item = bookContext.Books.Find(book.id);

            if (item == null)
            {
                bookContext.Books.Add(book);
            }
            else
            {
                bookContext.Entry(item).CurrentValues.SetValues(book);
            }
        }

        public void Del(int id)
        {
            bookContext.Books
                .Remove(bookContext.Books
                        .Where(i => i.id == id)
                               .SingleOrDefault());
        }

        public void Del(Book book)
        {
            Del(book.id);
        }
    }
}
