using Microsoft.EntityFrameworkCore;
using Bookstore.Models;


namespace Bookstore.Data
{
    public class CustomerContext: DbContext
    {
        
        
            public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
            {
            }
            public DbSet<Customer> Customer { get; set; }
        

    }
}
