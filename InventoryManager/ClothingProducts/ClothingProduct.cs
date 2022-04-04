using System.Linq;

namespace InventoryManager
{
    abstract class ClothingProduct : Product
    {
        public string Material { get; }

        protected abstract string[] MaterialOptions { get; }

        public override int Group => 0;

        protected ClothingProduct(
            string type, string name,
            double cost, string barcode,
            string material)
            : base(type, name, cost, barcode)
        {
            Material = material;
        }

        public override string DisplayFormat()
        {
            return $"{base.DisplayFormat()}\nMaterial: {Material}";
        }

        public override bool IsValid()
        {
            return base.IsValid() &&
                MaterialOptions.Contains(Material);
        }

        public override string InventoryFormat()
        {
            return $"{base.InventoryFormat()},{Material}";
        }
    }
}
