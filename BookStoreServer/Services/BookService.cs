using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreServer {
    public class BookService : IBookService {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, ILogger<BookService> logger) {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public IEnumerable<Book> GetAll() {
            _logger.LogInformation("Book list was requested");
            return _bookRepository.GetAll();
        }

        public void Save(IEnumerable<Book> books) {
            //_logger.LogInformation(books.ToString());
            _bookRepository.Update(books);
            _logger.LogInformation("Book list was updated");
        }

        public void Dispose() {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}