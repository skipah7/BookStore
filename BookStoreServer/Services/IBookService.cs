using System;
using System.Collections.Generic;

namespace BookStoreServer 
{
    public interface IBookService : IDisposable
    {
        IEnumerable<Book> GetAll();

        void Save(IEnumerable<Book> books);
    }
}