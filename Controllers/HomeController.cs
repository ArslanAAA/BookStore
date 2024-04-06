using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string CustomProperty {  get; set; }
        [ViewData]
        public string Title { get; set; }
        [ViewData]
        public BookModel Book { get; set; }
        public ViewResult Index()
        {
            Title = "Home Page from Controller";
            CustomProperty = "CustomValue";
            ViewData["property1"] = "Faraaz Ali";
            Book = new BookModel() { Id = 1, Author = "Faraaz" };
            return View();
        }
        public ViewResult AboutUs()
        {
            Title = "About Us from Controller";
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
