using System;

class Program
{
    static void Main()
    {
        // First order - USA
        Address address1 = new Address("123 Apple St", "Salt Lake City", "UT", "USA");
        Customer customer1 = new Customer("Henry Osuagwu", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("USB-C Charger", "CH123", 19.99, 2));
        order1.AddProduct(new Product("Wireless Mouse", "WM234", 25.50, 1));

        // Second order - International
        Address address2 = new Address("456 King St", "London", "Greater London", "UK");
        Customer customer2 = new Customer("Jane Doe", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Bluetooth Speaker", "BS567", 39.95, 1));
        order2.AddProduct(new Product("HDMI Cable", "HD789", 8.99, 3));

        DisplayOrder(order1);
        Console.WriteLine();
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}");
    }
}
