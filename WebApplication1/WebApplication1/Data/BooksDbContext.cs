using Microsoft.EntityFrameworkCore;
using LibraryBookService.Models;

namespace LibraryBookService.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Book { get; set; }

    }
}
