using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreServer;

namespace BookStore.Tests
{
  internal class OrderRepositoryMock : IOrderRepository
  {
    private IEnumerable<Order> _orders = Array.Empty<Order>();

    public IEnumerable<Order> GetAll()
    {
      return _orders;
    }

    public void Update(Order order)
    {
      _orders = _orders.Append(order); 
    }
  }
}
