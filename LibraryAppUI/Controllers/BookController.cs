using Microsoft.AspNetCore.Mvc;
using LibraryAppUI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Net;

namespace LibraryAppUI.Controllers
{
    public class BookController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7100/api");
        private readonly HttpClient _client;

        public BookController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;  
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<BookViewModel>? bookList = new List<BookViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Book/GetAllBooks").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                bookList = JsonConvert.DeserializeObject<List<BookViewModel>>(data);
            }

            return View(bookList);
        }


        [HttpGet]
        public IActionResult Create()
        {         
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookViewModel? viewModel)
        {
            if (viewModel != null)
            {
                HttpResponseMessage response = _client.PostAsJsonAsync(_client.BaseAddress + "/Book/AddBook", viewModel).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            BookViewModel? viewModel = new BookViewModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Book/GetBook/" + Id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<BookViewModel>(data);
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int Id) 
        { 
            BookViewModel? viewModel = new BookViewModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Book/GetBook/" + Id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<BookViewModel>(data);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel? viewModel)
        {
            if (viewModel != null)
            {
                HttpResponseMessage response = _client.PutAsJsonAsync(_client.BaseAddress + "/Book/UpdateBook", viewModel).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    viewModel = JsonConvert.DeserializeObject<BookViewModel>(data);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            BookViewModel? viewModel = new BookViewModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Book/GetBook/" + Id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<BookViewModel>(data);
            }

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            List<BookViewModel>? bookList = new List<BookViewModel>();

            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Book/DeleteBook?id=" + Id).Result;            

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                bookList = JsonConvert.DeserializeObject<List<BookViewModel>>(data);
            }

            return RedirectToAction("Index", bookList);
        }
    }
}
