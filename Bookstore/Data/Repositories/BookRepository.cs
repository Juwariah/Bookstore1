using Bookstore.Models;
using static Bookstore.Data.Repositories.ICRUDRepository;

namespace Bookstore.Data.Repositories
{
    public interface BookRepository
    {
        public class BookRepository : ICrudRepository<BookItem, int>
        {
            private readonly BookContext _todoContext;
            public BookRepository(BookContext BookContext)
            {
                _todoContext = BookContext ?? throw new
                ArgumentNullException(nameof(BookContext));
            }
            public void Add(BookItem element)
            {
                _todoContext.BookItems.Add(element);
            }
            public void Delete(int id)
            {
                var item = Get(id);
                if (item is not null) _todoContext.BookItems.Remove(Get(id));
            }
            public bool Exists(int id)
            {
                return _todoContext.BookItems.Any(u => u.BookItemId == id);
            }
            public BookItem Get(int id)
            {
                return _todoContext.BookItems.FirstOrDefault(u => u.BookItemId == id);
            }
            public IEnumerable<BookItem> GetAll()
            {
                return _todoContext.BookItems.ToList();
            }
            public bool Save()
            {
                return _todoContext.SaveChanges() > 0;
            }
            public void Update(BookItem element)
            {
                _todoContext.Update(element);
            }
        }

    }
}
