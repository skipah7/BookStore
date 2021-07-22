using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BookStoreServer {
    public class JsonBookRepository : IBookRepository
    {
        private readonly FileInfo _fileInfo;

        public JsonBookRepository(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public IEnumerable<Book> GetAll()
        {
            return JsonConvert.DeserializeObject<Book[]>(File.ReadAllText(_fileInfo.FullName));
        }

        public void Update(IEnumerable<Book> books)
        {
            File.WriteAllText(_fileInfo.FullName, JsonConvert.SerializeObject(books, Formatting.Indented));
        }
    }
}