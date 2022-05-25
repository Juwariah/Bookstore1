using Bookstore.Models;
using static Bookstore.Data.Repositories.ICRUDRepository;
using static Bookstore.Services.ICrudService;

namespace Bookstore.Services
{
    public interface CustomerService
    {
        public class CustomerService : ICrudService<Customer, int>
        {
            private readonly ICrudRepository<Customer, int> _todoRepository;
            public CustomerService(ICrudRepository<Customer, int> CustomerRepository)
            {
                _todoRepository = CustomerRepository;
            }
            public void Add(Customer element)
            {
                _todoRepository.Add(element);
                _todoRepository.Save();
            }
            public void Delete(int id)
            {
                _todoRepository.Delete(id);
                _todoRepository.Save();
            }
            public Customer Get(int id)
            {
                return _todoRepository.Get(id);
            }
            public IEnumerable<Customer> GetAll()
            {
                return _todoRepository.GetAll();
            }
            public void Update(Customer old, Customer newT)
            {
                old.FirstName = newT.FirstName;
                old.LastName = newT.LastName;
                old.Email = newT.Email;
               
                _todoRepository.Update(old);
                _todoRepository.Save();
            }
        }

    }
}

