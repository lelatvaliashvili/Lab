using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryBookService.Data
{
    public class BooksDbContextSeed
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var bookContext = new BooksDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<BooksDbContext>>()))
            { 
                if (bookContext.Book.Any())
                {
                    return;
                }
                bookContext.Book.AddRange(
                    new Models.Book
                    {
                        Id = 1,
                        Name = "A Little Life",
                        Author = "Author1",
                        PublishDate = new DateTime(2015, 3, 10)
                    },
                    new Models.Book
                      {
                          Id = 2,
                          Name = "A Little Life 2",
                          Author = "Author1",
                         PublishDate = new DateTime(2015, 3, 10)
                    }
                );
                bookContext.SaveChanges();
            }
        }
    }
}
