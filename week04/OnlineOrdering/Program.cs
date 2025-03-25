using System;
using System.Collections.Generic;
using OnlineOrdering;
class Program
{
    static void Main(string[] args)
    {
        // Create Addresses
        var address1 = new Address("#12", "Marlique","Haiti");
        var address2 = new Address("#45 St", "snto","RD");

        // Create Customers
        var customer1 = new Customer("Denelson", address1);
        var customer2 = new Customer("Clerville", address2);

        // Create Products
        var product = new Product("Inverter", 101, 260.99, 1);
        var product1 = new Product("Charge controller", 102, 100.50, 1);
        var product2 = new Product("Battery", 103, 700.9, 4);
        var product3 = new Product("DC breacker", 110, 29.99, 1);


        // Create Orders and add products
        var order1 = new Order(customer1);
        order1.AddProduct(product);
        order1.AddProduct(product1);

        var order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display Order Details for Order 1
        Console.Clear();
        Console.WriteLine("Order 1 Details:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine( "ID product    product     price ");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(  order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.CalculateTotal():0.00}");

        // Display Order Details for Order 2
        Console.WriteLine("\nOrder 2 Details:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(  "ID product    product     price ");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.CalculateTotal():0.00}");
    }
}
