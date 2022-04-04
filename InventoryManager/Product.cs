namespace InventoryManager
{
    abstract class Product
    {
        private const int BARCODE_LENGTH = 12;

        public string Type { get; }

        public string Name { get; }

        public string Barcode { get; }

        public double Cost { get; set; }

        public abstract int Group { get; }

        protected Product(
            string type, string name,
            double cost, string barcode)
        {
            Type = type;
            Name = name;
            Barcode = barcode;
            Cost = cost;
        }

        public virtual string DisplayFormat()
        {
            return $"Type: {Type}\nName: {Name}\nCost: {Cost}\nBarcode: {Barcode}";
        }

        public virtual string InventoryFormat()
        {
            return $"{Type},{Name},{Cost},{Barcode}";
        }

        public virtual bool IsValid()
        {
            return Barcode.Length == BARCODE_LENGTH;
        }
    }
}