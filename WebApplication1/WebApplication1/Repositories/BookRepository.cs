using Microsoft.EntityFrameworkCore;
using LibraryBookService.Data;
using LibraryBookService.Models;
using LibraryBookService.Repositories.Interface;

namespace LibraryBookService.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BooksDbContext _dbcontext;
        public BookRepository(BooksDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<Book>> AddBookToLibraryAsync(Book book)
        {
            if (!(_dbcontext.Book.Any(x => x.Id == book.Id)))
            {
                await _dbcontext.Book.AddAsync(book);
                await _dbcontext.SaveChangesAsync();
            }
            return _dbcontext.Book.ToList();
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var books = await _dbcontext.Book.ToListAsync();
            return books;
        }

        public async Task<Book> GetBookFromLibraryById(int id)
        {
            var book = await _dbcontext.Book.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            return book;
        }

        public async Task<Book> RemoveBookFromLibraryAsync(int id)
        {
            var book = await _dbcontext.Book.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _dbcontext.Book.Remove(book);
                await _dbcontext.SaveChangesAsync();
            }
            return book;
        }

        public async Task<Book> UpdateBookFromLibraryAsync(int id, string newName)
        {
            var book = await _dbcontext.Book.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (book == null)
            {
                throw new ArgumentNullException();
            }
            book.Name = newName;
            await _dbcontext.SaveChangesAsync();
            return book;
        }
    }
}
