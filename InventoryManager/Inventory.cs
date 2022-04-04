using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InventoryManager
{
    class Inventory
    {
        private const string ACTIONS_PATH = "actions_example.txt";
        private const string RESULT_PATH = "result_example.txt";
        private const string INVENTORY_PATH = "inventory_example.txt";

        private List<Product> products;
        private StreamWriter outFile;

        public Inventory()
        {
            products = new List<Product>();
        }

        public void DeleteExistingResultFile()
        {
            File.Delete(RESULT_PATH);
        }

        public void LoadProducts()
        {
            foreach (string line in File.ReadAllLines(INVENTORY_PATH))
            {
                Product product = CreateProduct(line.Split(','));

                if (CanProductBeAdded(product))
                {
                    products.Add(product);
                }
                else
                {
                    Console.WriteLine($"An invalid product exists in {INVENTORY_PATH}\n");
                }
            }
        }

        private bool CanProductBeAdded(Product p)
        {
            return p != null &&
                p.IsValid() &&
                IsBarcodeUnique(p.Barcode);
        }

        private bool IsBarcodeUnique(string barcode)
        {
            return !products.Exists(x => x.Barcode.Equals(barcode));
        }

        public void ExecuteActions()
        {
            string[] actionArgs;

            foreach (string action in File.ReadAllLines(ACTIONS_PATH))
            {
                actionArgs = action.Split(':', ',');

                if (actionArgs.Length < 1)
                {
                    continue;
                }

                switch (actionArgs[0])
                {
                    case "Add":
                    {
                        AddProduct(actionArgs.Skip(1).ToArray());
                    }
                    break;

                    case "Display2":
                    {
                        Display2(actionArgs[1]);
                    }
                    break;

                    case "FindBarcode":
                    {
                        FindBarcode(actionArgs);
                    }
                    break;

                    case "FindName":
                    {
                        FindName(actionArgs);
                    }
                    break;

                    case "SortByCost":
                    {
                        SortByCost();
                    }
                    break;

                    case "SortByName":
                    {
                        SortByName();
                    }
                    break;

                    default:
                    {
                        Output($"Action Command: {actionArgs[0]} not recognized");
                    }
                    break;
                }
            }
        }

        private bool IsIndexValid<T>(T[] array, int index)
        {
            return index >= 0 && index < array.Length;
        }

        private bool TryParse(string[] array, int index, out int result)
        {
            if (IsIndexValid(array, index))
            {
                return int.TryParse(array[index], out result);
            }

            result = 0;
            return false;
        }

        private bool TryParse(string[] array, int index, out double result)
        {
            if (IsIndexValid(array, index))
            {
                return double.TryParse(array[index], out result);
            }

            result = 0;
            return false;
        }

        private Product CreateProduct(string[] args)
        {
            if (!IsIndexValid(args, 3))
            {
                return null;
            }

            string type = args[0];
            string name = args[1];
            string barcode = args[3];

            // args[2]: cost
            if (double.TryParse(args[2], out double cost))
            {
                switch (type)
                {
                    case "Movie":
                    {
                        if (TryParse(args, 9, out int durationMinutes))
                        {
                            // args[4]: genre
                            // args[5]: platform
                            // args[6]: releaseYear
                            // args[7]: director
                            // args[8]: mpaaRating
                            // args[9]: durationMinutes
                            return new Movie(name, cost, barcode, args[4], args[5], args[6], args[7], args[8], durationMinutes);
                        }
                    }
                    break;

                    case "Game":
                    {
                        if (TryParse(args, 8, out int metacriticScore))
                        {
                            // args[4]: genre
                            // args[5]: platform
                            // args[6]: releaseYear
                            // args[7]: esrbRating
                            // args[8]: metacriticScore
                            return new Game(name, cost, barcode, args[4], args[5], args[6], args[7], metacriticScore);
                        }
                    }
                    break;

                    case "Pants":
                    {
                        if (TryParse(args, 5, out int waistSize))
                        {
                            // args[4]: material
                            return new Pants(name, cost, barcode, args[4], waistSize);
                        }
                    }
                    break;

                    case "Book":
                    {
                        if (IsIndexValid(args, 8))
                        {
                            // args[4]: genre
                            // args[5]: platform
                            // args[6]: releaseYear
                            // args[7]: author
                            // args[8]: publisher
                            return new Book(name, cost, barcode, args[4], args[5], args[6], args[7], args[8]);
                        }
                    }
                    break;

                    case "Top":
                    {
                        if (IsIndexValid(args, 6))
                        {
                            // Return an instance of Top
                            // args[4]: material
                            // args[5]: style
                            // args[6]: size
                            return new Top(name, cost, barcode, args[4], args[5], args[6]);
                        }
                    }
                    break;

                    case "Dress":
                    {
                        if (IsIndexValid(args, 6))
                        {
                            // args[4]: material
                            // args[5]: dressType
                            // args[6]: size
                            return new Dress(name, cost, barcode, args[4], args[5], args[6]);
                        }
                    }
                    break;
                }
            }

            return null;
        }

        private void DeleteProduct(int index)
        {
            products.RemoveAt(index);
            Save();
        }

        private void ModifyProductCost(int productIndex, double newCost)
        {
            products[productIndex].Cost = newCost;
            Save();
        }

        private void FindBarcode(string[] args)
        {
            if (IsIndexValid(args, 2))
            {
                string barcode = args[1];
                int productIndex = products.FindIndex(x => x.Barcode.Equals(barcode));
                string secondaryAction = args[2];

                bool successful = productIndex != -1;

                if (successful)
                {
                    switch (secondaryAction)
                    {
                        case "Display":
                        {
                            Output(products[productIndex].DisplayFormat());
                        }
                        break;

                        case "Modify":
                        {
                            // args[3]: cost
                            successful = TryParse(args, 3, out double newCost);

                            if (successful)
                            {
                                ModifyProductCost(productIndex, newCost);
                            }
                        }
                        break;

                        case "Delete":
                        {
                            DeleteProduct(productIndex);
                        }
                        break;

                        default:
                        {
                            successful = false;
                        }
                        break;
                    }
                }

                if (!successful)
                {
                    Output($"Item: {barcode} not found");
                }
            }
        }

        private void AddProduct(string[] args)
        {
            Product p = CreateProduct(args);

            if (p != null && p.IsValid())
            {
                products.Add(p);
                Save();
            }
            else
            {
                Console.WriteLine($"{args[1]} is not a valid product");
            }
        }

        private string GetFirst2(string type)
        {
            List<Product> output = products.Where(x => x.Type.Equals(type))
                .Take(2)
                .ToList();

            switch (output.Count)
            {
                case 2:
                {
                    return $"{output[0].DisplayFormat()}\n\n{output[1].DisplayFormat()}";
                }

                case 1:
                {
                    return $"{output[0].DisplayFormat()}";
                }

                default:
                {
                    return $"No products of type {type} found.";
                }
            }
        }

        private void Output(string text)
        {
            try
            {
                outFile = File.AppendText(RESULT_PATH);

                Console.WriteLine($"{text}\n");
                outFile.WriteLine($"{text}\n");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                outFile?.Close();
            }
        }

        private void Display2(string type)
        {
            Output(GetFirst2(type));
        }

        private List<int> GetIndexesWithName(string name)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name.Equals(name))
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        private void FindName(string[] args)
        {
            bool success = TryParse(args, 3, out int userIndex);

            if (success)
            {
                List<int> indexesWithName = GetIndexesWithName(args[1]);
                string secondaryAction = args[2];

                switch (secondaryAction)
                {
                    case "Delete":
                    {
                        DeleteProduct(indexesWithName[userIndex]);
                    }
                    break;

                    case "Modify":
                    {
                        if (TryParse(args, 4, out double newCost))
                        {
                            ModifyProductCost(indexesWithName[userIndex], newCost);
                        }
                    }
                    break;

                    case "Display":
                    {
                        Output(products[indexesWithName[userIndex]].DisplayFormat());
                    }
                    break;

                    default:
                    {
                        success = false;
                    }
                    break;
                }
            }

            if (!success)
            {
                // args[1]: name of product
                Output($"Item: {args[1]} not found");
            }
        }


        private void SortByCost()
        {
            products = products.OrderBy(x => x.Group)
                .ThenBy(x => x.Type)
                .ThenByDescending(x => x.Cost)
                .ToList();

            Save();
        }

        private void SortByName()
        {
            products = products.OrderBy(x => x.Group)
                .ThenBy(x => x.Group)
                .ThenBy(x => x.Type)
                .ThenBy(x => x.Name)
                .ToList();

            Save();
        }

        private void Save()
        {
            try
            {
                outFile = File.CreateText(INVENTORY_PATH);
                products.ForEach(p => outFile.WriteLine(p.InventoryFormat()));
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                outFile?.Close();
            }
        }
    }
}
