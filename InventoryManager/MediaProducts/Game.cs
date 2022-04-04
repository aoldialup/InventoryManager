using System.Linq;

namespace InventoryManager
{
    class Game : MediaProduct
    {
        private const int METACRITIC_SCORE_MAX = 100;
        private const int METACRITIC_SCORE_MIN = 0;

        private static readonly string[] genreOptions = { "Adventure", "RPG", "FPS", "MOBA", "Fighting", "Puzzle" };
        private static readonly string[] platformOptions = { "Nintendo", "Microsoft", "Sony", "PC" };
        private static readonly string[] esrbRatings = { "E", "E-10+", "T", "M", "AO" };

        protected override string[] Genres => genreOptions;
        protected override string[] Platforms => platformOptions;

        public string EsrbRating { get; }
        public int MetacriticScore { get; }

        public Game(
            string name, double cost,
            string barcode, string genre,
            string platform, string releaseYear,
            string esrbRating, int metacriticScore)
            : base("Game", name, cost, barcode, genre, platform, releaseYear)
        {
            MetacriticScore = metacriticScore;
            EsrbRating = esrbRating;
        }

        public override bool IsValid()
        {
            return base.IsValid() &&
                MetacriticScore <= METACRITIC_SCORE_MAX &&
                MetacriticScore >= METACRITIC_SCORE_MIN &&
                esrbRatings.Contains(EsrbRating);
        }

        public override string DisplayFormat()
        {
            return $"{base.DisplayFormat()}\nRating: {EsrbRating}\nScore: {MetacriticScore}";
        }

        public override string InventoryFormat()
        {
            return $"{base.InventoryFormat()},{EsrbRating},{MetacriticScore}";
        }
    }
}
