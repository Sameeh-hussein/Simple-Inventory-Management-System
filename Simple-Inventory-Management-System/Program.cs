using SimpleInventoryManagementSystem;
using System.Diagnostics;
using System.Linq;

internal class Program
{
    static Inventory inventory = new Inventory();

    private static void Main(string[] args)
    {
        // Add a product
        AddProduct();

        // View All The Products
        ViewAllProduct();

        // Edit A Product
        //Console.Write("Enter the product name: ");
        //EditProduct(Console.ReadLine());

        //Delete A Product
        //Console.Write("Enter the product name: ");
        //deleteProduct(Console.ReadLine());

        Console.Write("Enter the product name: ");
        Search(Console.ReadLine());
    }

    static void AddProduct()
    {
        Console.Write("Enter the product name: ");
        string name = Console.ReadLine();

        if (!inventory.Exist(name))
        {
            Console.Write("Enter the product price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the product quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            try
            {
                inventory.save(new Product(name, price, quantity));
                Console.WriteLine("The product added successfully, thanks");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
        else
        {
            Console.WriteLine("This product name already exist, try again !");
        }
    }

    static void ViewAllProduct()
    {
        Console.WriteLine("===========All Product Table===========");
        foreach (var it in inventory) Console.WriteLine(it);
    }

    static void EditProduct(string name)
    {
        if (inventory.Exist(name))
        {
            Product temp = inventory.findProduct(name);
            char yORn;
            Console.Write("would you want to change the name? [y/n]: ");
            yORn = Convert.ToChar(Console.ReadLine());

            if (yORn == 'y')
            {
                Console.Write("Enter the new name: ");
                temp.name = Console.ReadLine();
            }

            Console.Write("would you want to change the price? [y/n]: ");
            yORn = Convert.ToChar(Console.ReadLine());

            if (yORn == 'y')
            {
                Console.Write("Enter the new price: ");
                temp.price = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("would you want to change the quantity? [y/n]: ");
            yORn = Convert.ToChar(Console.ReadLine());

            if (yORn == 'y')
            {
                Console.Write("Enter the new quantity: ");
                temp.price = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("All changes saved. Thanks");
        }
        else
        {
            Console.WriteLine($"Product '{name}' not found in the inventory.");
        }
    }

    static void deleteProduct(string name)
    {
        if (inventory.Exist(name))
        {
            Product temp = inventory.findProduct(name);
            try
            {
                inventory.DeleteProduct(temp);
                Console.WriteLine("The product deleted successfully, thanks");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine($"Product '{name}' not found in the inventory.");
        }
    }

    static void Search(string name)
    {
        if (inventory.Exist(name))
        {
            Console.WriteLine("Product Information: ");
            Console.WriteLine(inventory.findProduct(name));
        }
        else
        {
            Console.WriteLine($"Product '{name}' not found in the inventory.");
        }
    }
}