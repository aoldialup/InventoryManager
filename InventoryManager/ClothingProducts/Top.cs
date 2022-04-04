using System.Linq;

namespace InventoryManager
{
    class Top : ClothingProduct
    {
        private static readonly string[] materialOptions = { "Cotton", "Silk", "Satin", "Wool", "Spandex" };
        private static readonly string[] styleOptions = { "T-Shirt", "Sweater", "Polo", "Blouse", "Tank Top", "Crop Top" };
        private static readonly string[] sizeOptions = { "S", "M", "L", "XL" };

        protected override string[] MaterialOptions => materialOptions;

        public string Size { get; }
        public string Style { get; }

        public Top(
            string name, double cost,
            string barcode, string material,
            string style, string size)
            : base("Top", name, cost, barcode, material)
        {
            Style = style;
            Size = size;
        }

        public override string DisplayFormat()
        {
            return $"{base.DisplayFormat()}\nTop Style: {Style}\nSize: {Size}";
        }

        public override string InventoryFormat()
        {
            return $"{base.InventoryFormat()},{Style},{Size}";
        }

        public override bool IsValid()
        {
            return base.IsValid() &&
                styleOptions.Contains(Style) &&
                sizeOptions.Contains(Size);
        }
    }
}
