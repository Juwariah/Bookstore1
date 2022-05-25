using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data
{
    public class BookContext : DbContext
    {
         
        
            public BookContext(DbContextOptions< BookContext> options) : base(options)
            {

            }
            public DbSet<BookItem> BookItems { get; set; }
        

    }
}
