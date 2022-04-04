namespace InventoryManager
{
    class Book : MediaProduct
    {
        private static readonly string[] genres = { "Adventure", "Fantasy", "Lit-RPG", "Crime", "Romance" };
        private static readonly string[] platforms = { "Hardcover", "Paperback", "Audiobook" };

        protected override string[] Genres => genres;
        protected override string[] Platforms => platforms;

        public string Author { get; }
        public string Publisher { get; }

        public Book(
            string name, double cost,
            string barcode, string genre,
            string platform, string releaseYear,
            string author, string publisher)
            : base("Book", name, cost, barcode, genre, platform, releaseYear)
        {
            Author = author;
            Publisher = publisher;
        }

        public override string DisplayFormat()
        {
            return $"{base.DisplayFormat()}\nAuthor: {Author}\nPublisher: {Publisher}";
        }

        public override string InventoryFormat()
        {
            return $"{base.InventoryFormat()},{Author},{Publisher}";
        }
    }
}
