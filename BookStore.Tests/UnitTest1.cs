using NUnit.Framework;
using System;
using System.Linq;
using BookStoreServer;

namespace BookStore.Tests
{
    public class Tests
    {
    private IOrderService _orderService;
    private IOrderRepository _orderRepository;

        [SetUp]
        public void Setup()
        {
            var logger = new LoggerMock<OrderService>();

            _orderRepository = new OrderRepositoryMock();
            _orderService = new OrderService(_orderRepository, logger);
        }

        [Test]
        public void Save_Order()
        {
            var orders = new Order[]
            {
              new Order() { buyerName = "test1" },
              new Order() { buyerName = "test2" }
            };

            var order = new Order() { buyerName = "test3" };
            _orderService.Save(order);
            _orderService.Save(order);

            var newOrder = _orderRepository
              .GetAll()
              .ToArray();

            Assert.AreEqual(newOrder.Length, orders.Length);
        }

        [Test]
        public void GetAll_Orders_ReturnsAllOrders()
        {
        var orders = new Order[]
        {
          new Order() { buyerName = "test1" },
          new Order() { buyerName = "test2" },
        };

         var order = new Order() { buyerName = "test3" };
         _orderRepository.Update(order);
         _orderRepository.Update(order);

         var newOrders = _orderService
            .GetAll()
            .ToArray();

         Assert.AreEqual(newOrders.Length, orders.Length);
        }

        [Test]
        public void Price_Calc()
        {
          var order = new Order
          {
            items = new OrderItem[]
            {
              new OrderItem() { price = 600 },
              new OrderItem() { price = 600 }
            }
          };

          _orderService.PriceCalc(order);

          Assert.AreEqual(order.price, 1140);
        }


        [Test]
        public void Book_Total_Calc()
        {
          var order = new Order
          {
            items = new OrderItem[]
            {
              new OrderItem() { amount = 6 },
              new OrderItem() { amount = 5 }
            }
          };

          int bookTotal = _orderService.TotalBooks(order);

          Assert.AreEqual(11,bookTotal);
        }
    }
}
