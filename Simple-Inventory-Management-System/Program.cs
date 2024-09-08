using Simple_Inventory_Management_System;

internal class Program
{
    static readonly Inventory inventory = new();

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

        Console.ReadLine();
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
            Product temp = inventory.FindProduct(name);
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

            Console.WriteLine("All changes saved. Thanks");
        }
        else
        {
            Console.WriteLine($"Product '{name}' not found in the inventory.");
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
            Console.WriteLine(inventory.FindProduct(name));
        }
        else
        {
            Console.WriteLine($"Product '{name}' not found in the inventory.");
        }
    }
}