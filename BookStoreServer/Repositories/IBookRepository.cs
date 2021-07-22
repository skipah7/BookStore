using System.Collections.Generic;

namespace BookStoreServer {
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAll();

        public void Update(IEnumerable<Book> books);
    }
}