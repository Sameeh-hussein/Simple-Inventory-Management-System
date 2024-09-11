using Simple_Inventory_Management_System.Domain;
using Simple_Inventory_Management_System.ProductManagement;
using System.Text;

internal class Program
{
    private static readonly Inventory inventory = new();

    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        bool ok = true;
        while (ok)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("============================ Main Menu ============================\n" +
                    "Select one ot the options: \n" +
                    "1. Show All Products.\n" +
                    "2. Add a product.\n" +
                    "3. Edit a product.\n" +
                    "4. Search for a product.\n" +
                    "5. Delete a product.\n" +
                    "6. Exit.\n"
            );
            Console.ResetColor();

            var option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    ViewAllProduct();
                    break;
                case 2:
                    AddProduct();
                    break;
                case 3:
                    Console.Write("Enter the product name: ");
                    EditProduct(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("Enter the product name: ");
                    Search(Console.ReadLine());
                    break;
                case 5:
                    Console.Write("Enter the product name: ");
                    DeleteProduct(Console.ReadLine());
                    break;
                case 6:
                    ok = false;
                    break;
                default:
                    Console.WriteLine("Unvalid option!");
                    break;
            }

            if (!ok)
            {
                break;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nPress 'Enter' to return to main menu");
            Console.ResetColor();
            Console.ReadLine();
        }
    }

    static void AddProduct()
    {
        Console.Write("Enter the product name: ");
        string name = Console.ReadLine();

        if (!inventory.Exist(name))
        {
            Console.Write("Enter the product price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter the currency number: 1.Dollar 2.Pound 3.Euro: ");
            var currencyInput = Convert.ToInt32(Console.ReadLine());

            var currency = currencyInput switch
            {
                1 => Currency.Dollar,
                2 => Currency.Pound,
                3 => Currency.Euro,
                _ => throw new ArgumentException("Invalid currency!")
            };

            Console.Write("Enter the product quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            try
            {
                inventory.Save(new Product(name, new Price(price, currency), quantity));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("This product name already exist, try again !");
            Console.ResetColor();
        }
    }

    static void ViewAllProduct()
    {
        Console.WriteLine("======================== All Product Table ========================");
        Console.WriteLine("{0,-10} | {1,-29} | {2,-10} | {3,-8}", "Product Id", "Name", "Price", "Quantity\n" +
                          "-------------------------------------------------------------------");

        foreach (Product it in inventory) 
            Console.WriteLine("{0,-10} | {1,-29} | {2,-10} | {3,-8}", it.Id, it.Name, it.Price, it.Quantity); ;
    }

    static void EditProduct(string name)
    {
        if (inventory.Exist(name))
        {
            var product = inventory.FindProduct(name);
            var temp = new Product(product);

            char yORn;
            Console.Write("would you want to change the name? [y/n]: ");
            yORn = Convert.ToChar(Console.ReadLine());

            if (yORn == 'y')
            {
                Console.Write("Enter the new name: ");
                temp.Name = Console.ReadLine();
            }

            Console.Write("would you want to change the price? [y/n]: ");
            yORn = Convert.ToChar(Console.ReadLine());

            if (yORn == 'y')
            {
                Console.Write("Enter the new price: ");
                temp.Price.Amount = Convert.ToDecimal(Console.ReadLine());
            }

            Console.Write("would you want to change the quantity? [y/n]: ");
            yORn = Convert.ToChar(Console.ReadLine());

            if (yORn == 'y')
            {
                Console.Write("Enter the new quantity: ");
                temp.Quantity = Convert.ToInt32(Console.ReadLine());
            }

            if(inventory.Edit(name, temp))
            {
                product.Name = temp.Name;
                product.Price.Amount = temp.Price.Amount;
                product.Quantity = temp.Quantity;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Product '{name}' not found in the inventory.");
            Console.ResetColor();
        }
    }

    static void DeleteProduct(string name)
    {
        if (inventory.Exist(name))
        {
            Product temp = inventory.FindProduct(name);
            try
            {
                inventory.DeleteProduct(temp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Product '{name}' not found in the inventory.");
            Console.ResetColor();
        }
    }

    static void Search(string name)
    {
        if (inventory.Exist(name))
        {
            Console.WriteLine("Product Information: ");
            Console.WriteLine(inventory.FindProduct(name));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Product '{name}' not found in the inventory.");
            Console.ResetColor();
        }
    }
}