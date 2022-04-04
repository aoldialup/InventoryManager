namespace InventoryManager
{
    class Pants : ClothingProduct
    {
        private const int MIN_WAIST_SIZE = 20;
        private const int MAX_WAIST_SIZE = 50;

        private static readonly string[] materialOptions = { "Cotton", "Denim", "Canvas" };

        protected override string[] MaterialOptions => materialOptions;

        public int WaistSize { get; }

        public Pants(
            string name, double cost,
            string barcode, string material,
            int waistSize)
            : base("Pants", name, cost, barcode, material)
        {
            WaistSize = waistSize;
        }

        public override string DisplayFormat()
        {
            return $"{base.DisplayFormat()}\nWaist Size: {WaistSize}";
        }

        public override bool IsValid()
        {
            return base.IsValid() &&
                WaistSize >= MIN_WAIST_SIZE &&
                WaistSize <= MAX_WAIST_SIZE;
        }

        public override string InventoryFormat()
        {
            // Return the result
            return $"{base.InventoryFormat()},{WaistSize}";
        }
    }
}
