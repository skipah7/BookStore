using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStoreServer {
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> GetAll() {
            return _orderService.GetAll();
        }
        
        [HttpPost]
        public void Save([FromBody] Order order) {
            _orderService.PriceCalc(order);
            _orderService.Save(order);
        }
    }
}
