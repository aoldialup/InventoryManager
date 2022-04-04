using System.Linq;

namespace InventoryManager
{
    abstract class MediaProduct : Product
    {
        protected abstract string[] Platforms { get; }

        protected abstract string[] Genres { get; }

        public string Genre { get; }

        public string Platform { get; }

        public string ReleaseYear { get; }

        public override int Group => 1;

        protected MediaProduct(
            string type, string name,
            double cost, string barcode,
            string genre, string platform,
            string releaseYear)
            : base(type, name, cost, barcode)
        {
            Genre = genre;
            Platform = platform;
            ReleaseYear = releaseYear;
        }

        public override string DisplayFormat()
        {
            return $"{base.DisplayFormat()}\nGenre: {Genre}\nPlatform: {Platform}\nRelease Year: {ReleaseYear}";
        }

        public override bool IsValid()
        {
            return base.IsValid() &&
                Genres.Contains(Genre) &&
                Platforms.Contains(Platform);
        }

        public override string InventoryFormat()
        {
            return $"{base.InventoryFormat()},{Genre},{Platform},{ReleaseYear}";
        }
    }
}
