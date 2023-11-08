using LibraryBookService.Models;

namespace LibraryBookService.Repositories.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> AddBookToLibraryAsync(Book book);

        Task<Book> RemoveBookFromLibraryAsync(int id);

        Task<Book> UpdateBookFromLibraryAsync(int id, string name);

        Task<Book> GetBookFromLibraryById(int id);

        Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}
