using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using static Bookstore.Services.ICrudService;

namespace Bookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5066/todo
    public class BookController : ControllerBase
    {
        private readonly ICrudService<BookItem, int> _todoService;
        public BookController(ICrudService<BookItem, int> BookService)
        {
            _todoService = BookService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<BookItem>> GetAll() => _todoService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<BookItem> Get(int id)
        {
            var book = _todoService.Get(id);
            if (book is null) return NotFound();
            else return book;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(BookItem book)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _todoService.Add(book);
                return CreatedAtAction(nameof(Create), new { id = book.BookItemId }, book);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, BookItem book)
        {
            var existingBookItem = _todoService.Get(id);
            if (existingBookItem is null || existingBookItem.BookItemId != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _todoService.Update(existingBookItem, book);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _todoService.Get(id);
            if (book is null) return NotFound();
            _todoService.Delete(id);
            return NoContent();
        }
    }

}
