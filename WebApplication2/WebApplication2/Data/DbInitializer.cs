using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class DbInitializer
    {
        public static void Initialize(BooksDbContext bookContext)
        {
            bookContext.Database.EnsureCreated();
            //your seeding data here
            if (bookContext.Book.Any())
            {
                return;
            }
            bookContext.Book.AddRange(
                new Models.Book
                {
                    //Id = 1,
                    Name = "A Little Life",
                    //Author = "Author1",
                    //PublishDate = new DateTime(2015, 3, 10)
                },
                new Models.Book
                {
                   // Id = 2,
                    Name = "A Little Life 2",
                    //Author = "Author1",
                    //PublishDate = new DateTime(2015, 3, 10)
                }
            );
            bookContext.SaveChanges();


        }
    }
}
