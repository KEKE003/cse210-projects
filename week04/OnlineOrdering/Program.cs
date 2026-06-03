using System;

namespace OnlineOrdering
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the OnlineOrdering Program");

            Address address1 = new Address("123 Linux Way", "Rexburg", "ID", "USA");
            Customer customer1 = new Customer("John Reading", address1);
            Order order1 = new Order(customer1);

            Product prod1 = new Product("Ergonomic Keyboard", "KBD-102", 45.99, 1);
            Product prod2 = new Product("Wireless Mouse", "MS-405", 19.50, 2);
            Product prod3 = new Product("USB-CHub", "HUB-77", 29.99, 1);

            order1.AddProduct(prod1);
            order1.AddProduct(prod2);
            order1.AddProduct(prod3);

            Address address2 = new Address("466 Kameeldoring Str", "Bethlehem", "FS", "South Africa");
            Customer customer2 = new Customer("Kekeletso Nhlapo", address2);
            Order order2 = new Order(customer2);

            Product prod4 = new Product("4K Monitor", "MON-4K", 299.99, 1);
            Product prod5 = new Product("HDMI Cable 6ft", "CBL-HD6", 8.50, 3);

            order2.AddProduct(prod4);
            order2.AddProduct(prod5);

            Console.WriteLine("==============================");
            Console.WriteLine("PROCESSING ORDER 1");
            Console.WriteLine("===============================");
            Console.WriteLine($"{order1.GetPackingLabel()}");
            Console.WriteLine($"{order1.GetShippingLabel()}");
            Console.WriteLine($"Total Cost : ${order1.CalculateTotalOrderCost():F2}\n");

            Console.WriteLine("=================================");
            Console.WriteLine("PROCESSING ORDER 2");
            Console.WriteLine("==================================");
            Console.WriteLine($"{order2.GetPackingLabel()}");
            Console.WriteLine($"{order2.GetShippingLabel()}");
            Console.WriteLine($"Total Cost : ${order2.CalculateTotalOrderCost():F2}\n");
        }
    }
}
 