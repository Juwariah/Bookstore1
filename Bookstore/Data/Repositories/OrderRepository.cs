using Bookstore.Models;
using static Bookstore.Data.Repositories.ICRUDRepository;

namespace Bookstore.Data.Repositories
{
    public interface OrderRepository
    {
        public class OrderRepository : ICrudRepository<Order, int>
        {
            private readonly OrderContext _todoContext;
            public OrderRepository(OrderContext OrderContext)
            {
                _todoContext = OrderContext ?? throw new
                ArgumentNullException(nameof(OrderContext));
            }
            public void Add(Order element)
            {
                _todoContext.Order.Add(element);
            }
            public void Delete(int id)
            {
                var item = Get(id);
                if (item is not null) _todoContext.Order.Remove(Get(id));
            }
            public bool Exists(int id)
            {
                return _todoContext.Order.Any(u => u.OrderId == id);
            }
            public Order Get(int id)
            {
                return _todoContext.Order.FirstOrDefault(u => u.OrderId == id);
            }
            public IEnumerable<Order> GetAll()
            {
                return _todoContext.Order.ToList();
            }
            public bool Save()
            {
                return _todoContext.SaveChanges() > 0;
            }
            public void Update(Order element)
            {
                _todoContext.Update(element);
            }
        }
    }
}
