using DomainBook.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppBook.Models;

namespace WebAppBook.Controllers
{
    public class BookController : BaseController
    {
        // GET: Book
        public async Task<ActionResult> Index()
        {
            List<Book> listBook;
            List<BookViewModel> listBookModel = new List<BookViewModel>();

            HttpClient httpClient = this.GetHttp();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/Book/GetAllBook");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var EmpResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                listBook = JsonConvert.DeserializeObject<List<Book>>(EmpResponse);

                foreach (Book book in listBook)
                {
                    listBookModel.Add(new BookViewModel(book));
                }
            }

            return View(listBookModel);
        }

        public async Task<ActionResult> BookManager(int? id)
        {
            Book book;
            BookViewModel bookModel = new BookViewModel();

            if (id.HasValue)
            {
                HttpClient httpClient = this.GetHttp();
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(String.Format("api/Book/GetBook/{0}", id));

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var EmpResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                    book = JsonConvert.DeserializeObject<Book>(EmpResponse);

                    if (book != null)
                    {
                        bookModel.Load(book);
                    }
                }
            }

            return View(bookModel);
        }

        public async Task<ActionResult> DelBook(int id)
        {
            try
            {
                HttpClient httpClient = this.GetHttp();
                HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync(String.Format("api/Book/DelBook/{0}", id));

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = string.Empty }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = httpResponseMessage.RequestMessage}, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> PutBook(BookViewModel bookViewModelook)
        {
            try
            {
                Book book = bookViewModelook.Extract();

                var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

                HttpClient httpClient = this.GetHttp();
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("api/Book/PutBook", content);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = String.Empty, redirecturl = "/Book/Index" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = httpResponseMessage.RequestMessage }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}