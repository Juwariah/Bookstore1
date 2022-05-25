using Bookstore.Models;
using static Bookstore.Data.Repositories.ICRUDRepository;

namespace Bookstore.Data.Repositories
{
    public interface CustomerRepository
    {
        public class CustomerRepository : ICrudRepository<Customer, int>
        {
            private readonly CustomerContext _todoContext;
            public CustomerRepository(CustomerContext CustomerContext)
            {
                _todoContext = CustomerContext ?? throw new
                ArgumentNullException(nameof(CustomerContext));
            }
            public void Add(Customer element)
            {
                _todoContext.Customer.Add(element);
            }
            public void Delete(int id)
            {
                var item = Get(id);
                if (item is not null) _todoContext.Customer.Remove(Get(id));
            }
            public bool Exists(int id)
            {
                return _todoContext.Customer.Any(u => u.CustomerId == id);
            }
            public Customer Get(int id)
            {
                return _todoContext.Customer.FirstOrDefault(u => u.CustomerId == id);
            }
            public IEnumerable<Customer> GetAll()
            {
                return _todoContext.Customer.ToList();
            }
            public bool Save()
            {
                return _todoContext.SaveChanges() > 0;
            }
            public void Update(Customer element)
            {
                _todoContext.Update(element);
            }
        }

    }
}

