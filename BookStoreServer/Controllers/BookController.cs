using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStoreServer {
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService) {
            _bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll() {
            return _bookService.GetAll();
        }
        
        [HttpPost]
        public void Save([FromBody] IEnumerable<Book> books) {
            _bookService.Save(books);
        }
    }
}