using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreServer {
    public class OrderService : IOrderService {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger) {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public IEnumerable<Order> GetAll() {
            _logger.LogInformation("Orders list was requested");
            return _orderRepository.GetAll();
        }

        public void Save(Order order) {
            //_logger.LogInformation(books.ToString());
            _orderRepository.Update(order);
            _logger.LogInformation("Orders list was updated");
        }

        public void PriceCalc(Order order)
        {
            double price = 0;
            foreach (OrderItem item in order.items)
            {
                price += item.price;
            }

            if (price > 1000)
            {
                price = price * 0.95;
                order.price = Math.Round(price);
            }

            order.price = price;
        }

        public int TotalBooks(Order order)
        {
            int totalBooks = 0;
            foreach (OrderItem item in order.items)
            {
                totalBooks += item.amount;
            }

            return totalBooks;
        }

        public void Dispose() {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
