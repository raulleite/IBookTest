using System.Collections.Generic;
using System.Web.Http;
using DomainBook.Entity;
using System.Net;
using Services.Interface;
using Services.Container;

namespace WebApiBook.Controllers
{
    public class BookController : ApiController
    {
        protected IServiceBook ServiceBook
        {
            get
            {
                return ServiceContainersApp.Resolve<IServiceBook>();
            }
        }

        public IEnumerable<Book> GetAllBook()
        {
            return ServiceBook.GetBooks();
        }

        public Book GetBook(int id)
        {
            Book book = ServiceBook.GetBook(id);

            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return book;
        }

        [HttpPost]
        public void PutBook(Book book)
        {
            ServiceBook.PutBook(book);
        }

        [HttpDelete]
        public void DelBook(int id)
        {
            ServiceBook.DelBook(id);
        }
    }
}