using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace WebAppBook.Controllers
{
    public class BaseController : Controller
    {
        public const string BaseUri = "http://localhost:54769/";

        public HttpClient GetHttp()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseUri);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}