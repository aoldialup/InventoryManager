using System.Linq;

namespace InventoryManager
{
    class Dress : ClothingProduct
    {
        private static readonly string[] materialOptions = { "Cotton", "Silk", "Satin", "Spandex" };
        private static readonly string[] dressTypeOptions = { "Sun Dress", "Halter Dress", "Formal Gown", "Babydoll Dress" };
        private static readonly string[] sizeOptions = { "S", "M", "L", "XL" };

        protected override string[] MaterialOptions => materialOptions;

        public string Size { get; }

        public string DressType { get; }

        public Dress(
            string name, double cost,
            string barcode, string material,
            string dressType, string size)
            : base("Dress", name, cost, barcode, material)
        {
            Size = size;
            DressType = dressType;
        }

        public override string DisplayFormat()
        {
            return $"{base.DisplayFormat()}\nDress Type: {DressType}\nSize: {Size}";
        }

        public override bool IsValid()
        {
            return base.IsValid() &&
                sizeOptions.Contains(Size) &&
                dressTypeOptions.Contains(DressType);
        }

        public override string InventoryFormat()
        {
            return $"{base.InventoryFormat()},{DressType},{Size}";
        }
    }
}
