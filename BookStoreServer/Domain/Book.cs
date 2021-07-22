namespace BookStoreServer
{
    public class Book
    {
        public string name { get; set; }
        public string author { get; set; }
        public int releaseDate { get; set; }
        public string isbn { get; set; }
        public string coverPath { get; set; }
        public int availableAmount { get; set; }
        public int price { get; set; }
    }
}