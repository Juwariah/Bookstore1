using Bookstore.Models;
using static Bookstore.Data.Repositories.ICRUDRepository;
using static Bookstore.Services.ICrudService;

namespace Bookstore.Services
{
    public interface OrderService
    {
    
            public class OrderService : ICrudService<Order, int>
            {
                private readonly ICrudRepository<Order, int> _todoRepository;
                public OrderService(ICrudRepository<Order, int> OrderRepository)
                {
                    _todoRepository = OrderRepository;
                }
                public void Add(Order element)
                {
                    _todoRepository.Add(element);
                    _todoRepository.Save();
                }
                public void Delete(int id)
                {
                    _todoRepository.Delete(id);
                    _todoRepository.Save();
                }
                public Order Get(int id)
                {
                    return _todoRepository.Get(id);
                }
                public IEnumerable<Order> GetAll()
                {
                    return _todoRepository.GetAll();
                }
                public void Update(Order old, Order newT)
                {
                    old.Price = newT.Price;
                    old.ShippingType = newT.ShippingType;
                
                    _todoRepository.Update(old);
                    _todoRepository.Save();
                }
            }

        
    }
}
