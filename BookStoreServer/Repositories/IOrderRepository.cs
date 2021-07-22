using System.Collections.Generic;

namespace BookStoreServer {
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetAll();

        public void Update(Order order);
    }
}