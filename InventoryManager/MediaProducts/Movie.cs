using System.Linq;

namespace InventoryManager
{
    class Movie : MediaProduct
    {
        private static readonly string[] genreOptions = { "Action", "Adventure", "Horror", "Romance", "Comedy" };
        private static readonly string[] platformOptions = { "DVD", "Blu-Ray" };
        private static readonly string[] mpaaRatings = { "G", "PG", "PG-13", "R", "NC-17" };

        protected override string[] Platforms => platformOptions;
        protected override string[] Genres => genreOptions;

        public string Director { get; }

        public int DurationMinutes { get; }

        public string MpaaRating { get; }

        public Movie(
            string name, double cost,
            string barcode, string genre,
            string platform, string releaseYear,
            string director, string mpaaRating,
            int durationMinutes)
            : base("Movie", name, cost, barcode, genre, platform, releaseYear)
        {
            Director = director;
            MpaaRating = mpaaRating;
            DurationMinutes = durationMinutes;
        }

        public override bool IsValid()
        {
            return base.IsValid() &&
                mpaaRatings.Contains(MpaaRating);
        }

        public override string DisplayFormat()
        {
            return $"{base.DisplayFormat()}\nDirector: {Director}\nMPAA Rating: {MpaaRating}\nDuration: {DurationMinutes}";
        }

        public override string InventoryFormat()
        {
            return $"{base.InventoryFormat()},{Director},{MpaaRating},{DurationMinutes}";
        }
    }
}