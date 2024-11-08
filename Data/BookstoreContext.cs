using Bookstore2.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore2.Data
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }
    }
}
