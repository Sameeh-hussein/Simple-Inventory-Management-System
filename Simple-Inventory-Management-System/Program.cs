using Simple_Inventory_Management_System;
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
        Console.Write("Enter the product name: ");
        EditProduct(Console.ReadLine());
    }

    static void AddProduct()
    {
        Console.Write("Enter the product name: ");
        string name = Console.ReadLine();
        
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

    static void ViewAllProduct()
    {
        Console.WriteLine("===========All Product Table===========");
        foreach (var it in inventory) Console.WriteLine(it);
    }

    static void EditProduct(string name)
    {
        if (Exist(name))
        {
            Product temp = inventory.GetProducts().First(it => it.name == name);
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

    static bool Exist(string name)
    {
        return inventory.GetProducts().Any(it => it.name == name);
    }
}