using DomainBook.UnitOfWork;
using DomainBook.Repository;
using Infrastructure.Context;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWorkBook : IUnitOfWorkBook
    {
        BookContext bookContext;

        public IRepositoryBook RepositoryBook { get; }

        public UnitOfWorkBook(BookContext bookContext)
        {
            this.bookContext = bookContext;
            RepositoryBook = new RepositoryBook(bookContext);
        }

        public void Dispose()
        {
            bookContext.Dispose();
        }

        public int Save()
        {
            return bookContext.SaveChanges();
        }
    }
}