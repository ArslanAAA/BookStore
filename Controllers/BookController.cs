using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }
        public async Task<ViewResult> GetBook(int id) {
            var data =await _bookRepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
        public ViewResult AddNewBook( bool isSuccess = false ,int bookId = 0)
        {
            ViewBag.Language = new SelectList(GetLanguage(), "Text", "Text");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)//IActionResult is a parent to any type, so we can return any type
        {//await can only be used inside an async method
            if(ModelState.IsValid) {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)//if the book has been inserted, redirect to the preview AddNewBook Method
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            //ModelState.AddModelError("","mycustomError"); //Use this to add custom model errors
            return View();
        }
        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>
            {
                new LanguageModel(){ Id = 1, Text = "Hindi"},
                new LanguageModel(){ Id = 2, Text = "English"},
                new LanguageModel(){ Id = 3, Text = "Dutch"},

            };
        }
    }
}
