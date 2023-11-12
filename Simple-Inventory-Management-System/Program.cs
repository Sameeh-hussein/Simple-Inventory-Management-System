using Simple_Inventory_Management_System;

internal class Program
{
    static Inventory inventory = new Inventory();

    private static void Main(string[] args)
    {
        // Add a product
        AddProduct();

        /*foreach (var item in inventory)
        {
            Console.WriteLine(item);
        }*/
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
            inventory.save(null);
            Console.WriteLine("The product added successfully, thanks");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}