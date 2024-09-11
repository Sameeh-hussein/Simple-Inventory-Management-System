
using System.Xml.Linq;
using Simple_Inventory_Management_System.ProductManagement;

namespace Simple_Inventory_Management_System.Data
{
    public class ProductRepository
    {
        private const string dirictory = @"C:\Users\Sameeh\IdeaProjects\Simple-Inventory-Management-System\Simple-Inventory-Management-System\DAL\";
        private const string fileName = "products.txt";
        private const string path = $"{dirictory}{fileName}";

        private void CheckIfFileExist()
        {
            bool exist = File.Exists(path);
            if (!exist)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                using FileStream fs = File.Create(path);
            }
        }

        public List<Product> LoadProductsFromFile()
        {
            var products = new List<Product>();

            try
            {
                CheckIfFileExist();

                string[] productAsString = File.ReadAllLines(path);
                foreach (var line in productAsString)
                {
                    string[] productSplit = line.Split(';');

                    string name = productSplit[0];

                    if (!decimal.TryParse(productSplit[1], out decimal price))
                    {
                        price = 0;
                    }

                    if (!Enum.TryParse(productSplit[2], out Currency currency))
                    {
                        currency = Currency.Dollar;
                    }

                    if (!long.TryParse(productSplit[3], out long quantity))
                    {
                        quantity = 0;
                    }

                    products.Add(new Product(name, new Price(price, currency), quantity));
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong parsing the file, please check the data!");
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The file could not found !");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ResetColor();
            }
            return products;
        }

        public bool SaveProductInFile(Product product)
        {
            try
            {
                CheckIfFileExist();

                string stringProduct = product.ConvertToStringForSaving();

                File.AppendAllText(path, Environment.NewLine + stringProduct);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Product '{product.Name}' added successfully.");
                Console.ResetColor();
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to save the product to the file.");
                Console.WriteLine(ex.Message);
                Console.ResetColor();

                return false;
            }
        }

        public bool DeleteProductFromFile(string name)
        {
            try
            {
                var products = File.ReadAllLines(path).ToList();
                bool exist = false;
                for (int i = 0; i < products.Count; i++)
                {
                    string[] productSplit = products[i].Split(';');
                    if (productSplit[0].Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        products.RemoveAt(i);
                        exist = true;
                        break;
                    }
                }
                if (exist)
                {
                    File.WriteAllLines(path, products);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Product '{name}' deleted successfully.");
                    Console.ResetColor();
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Product '{products}' not found.");
                    Console.ResetColor();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to delete the product from the file.");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return false;
            }
        }

        public bool EditProductInFile(string orignalProduct, Product product)
        {
            try
            {
                CheckIfFileExist();

                var products = File.ReadAllLines(path).ToList();

                bool exist = false;

                for (int i = 0; i < products.Count; i++)
                {
                    var productSplit = products[i].Split(';');
                    string name = productSplit[0];

                    if (name.Equals(orignalProduct, StringComparison.OrdinalIgnoreCase))
                    {
                        string updatedProductData = product.ConvertToStringForSaving();

                        products[i] = updatedProductData;
                        exist = true;
                        break;
                    }
                }

                if (exist)
                {
                    File.WriteAllLines(path, products);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Product '{product.Name}' edited successfully.");
                    Console.ResetColor();
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Product '{product.Name}' not found.");
                    Console.ResetColor();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to edit the product in the file.");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return false;
            }
        }
    }
}
