using Bookstore.Models;
using static Bookstore.Data.Repositories.ICRUDRepository;
using static Bookstore.Services.ICrudService;

namespace Bookstore.Services
{
    public interface IBookService
    {
        public class IBookService : ICrudService<BookItem, int>
        {
            private readonly ICrudRepository<BookItem, int> _todoRepository;
            public IBookService(ICrudRepository<BookItem, int> BookRepository)
            {
                _todoRepository = BookRepository;
            }
            public void Add(BookItem element)
            {
                _todoRepository.Add(element);
                _todoRepository.Save();
            }
            public void Delete(int id)
            {
                _todoRepository.Delete(id);
                _todoRepository.Save();
            }
            public BookItem Get(int id)
            {
                return _todoRepository.Get(id);
            }
            public IEnumerable<BookItem> GetAll()
            {
                return _todoRepository.GetAll();
            }
            public void Update(BookItem old, BookItem newT)
            {
                old.Description = newT.Description;
              
                _todoRepository.Update(old);
                _todoRepository.Save();
            }
        }

    }
}
