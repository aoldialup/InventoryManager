using System;

namespace InventoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            try
            {
                inventory.DeleteExistingResultFile();
                inventory.LoadProducts();
                inventory.ExecuteActions();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"ERROR: {e.Message}");
                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}
