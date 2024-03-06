using BookStore.Models;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().FirstOrDefault(x => x.Id == id);
        }
        public List<BookModel>  SearchBook(string title, string authorName)
        {
            return DataSource().Where(x=> x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1, Title = "MVC", Author = "Nitish"},
                new BookModel() { Id = 2, Title = "Combinatorics", Author = "Arslan"},
                new BookModel() { Id = 3, Title = "C#", Author = "Monika"},
                new BookModel() { Id = 4, Title = "Java", Author = "tester"},
                new BookModel() { Id = 5, Title = "php", Author = "MS"},
            };
        }
    }
}
