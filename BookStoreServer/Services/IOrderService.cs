using System;
using System.Collections.Generic;

namespace BookStoreServer 
{
    public interface IOrderService : IDisposable
    {
        IEnumerable<Order> GetAll();

        void Save(Order order);
    }
}