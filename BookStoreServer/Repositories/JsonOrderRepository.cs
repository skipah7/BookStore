using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BookStoreServer {
    public class JsonOrderRepository : IOrderRepository
    {
        private readonly FileInfo _fileInfo;

        public JsonOrderRepository(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public IEnumerable<Order> GetAll()
        {
            return JsonConvert.DeserializeObject<Order[]>(File.ReadAllText(_fileInfo.FullName));
        }

        public void Update(Order order)
        {
            var jsonData = System.IO.File.ReadAllText(_fileInfo.FullName);      

            var ordersList = JsonConvert.DeserializeObject<List<Order>>(jsonData) 
                      ?? new List<Order>();
            ordersList.Add(order);

            jsonData = JsonConvert.SerializeObject(ordersList);
            System.IO.File.WriteAllText(_fileInfo.FullName, jsonData);
        }
    }
}