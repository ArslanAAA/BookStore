using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context; 
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                Language = model.Language,
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;  
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Id = book.Id,
                        Author = book.Author,
                        CreatedOn = DateTime.UtcNow,
                        Description = book.Description,
                        Title = book.Title,
                        TotalPages = book.TotalPages,
                        UpdatedOn = DateTime.UtcNow,
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            var data = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return null;
            BookModel book = new BookModel()
            {
                Id = data.Id,
                Author = data.Author,
                CreatedOn = DateTime.UtcNow,
                Description = data.Description,
                Title = data.Title,
                TotalPages = data.TotalPages,
                UpdatedOn = DateTime.UtcNow,
            };
            return book;
        }
        public List<BookModel>  SearchBook(string title, string authorName)
        {
            return DataSource().Where(x=> x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1, Title = "MVC", Author = "Nitish" ,Description ="Description for MVC book" },
                new BookModel() { Id = 2, Title = "Combinatorics", Author = "Arslan",Description ="Description for Combinatorics book"},
                new BookModel() { Id = 3, Title = "C#", Author = "Monika",Description ="Description for C# book"},
                new BookModel() { Id = 4, Title = "Java", Author = "tester",Description ="Description for Java book"},
                new BookModel() { Id = 5, Title = "php", Author = "MS",Description ="Description for php book"},
                new BookModel() { Id = 6, Title = "Azure", Author = "Faraaz",Description ="Description for Azure book"},
                new BookModel() { Id = 7, Title = "Proofs", Author = "Faraaz",Description ="Description for Proofs book"}
            };
        }
    }
}
