﻿using Supermarket.Infrastructure;

namespace Supermarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProductsFactory productsFactory = new ProductsFactory();

            ClientFactory clientFactory = new ClientFactory();

            InventoryFactory inventoryFactory = new InventoryFactory(productsFactory);

            VendorFactory vendorFactory = new VendorFactory(inventoryFactory);

            var vendor = vendorFactory.Create();

            var clientsCount = 10;

            vendor.Enqueue(clientFactory.CreateQueue(vendor, clientsCount));

            while (vendor.ClientsToServe > 0) 
            {
                Console.Clear();

                vendor.PrintInfo();

                vendor.ServeNextClient();

                PrintContinueMessage();

                Console.ReadKey(true);
            }

            vendor.PrintInfo();
        }

        private static void PrintContinueMessage() 
        { 
            var defaultColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Нажмите любую клавишу, чтобы перейти к следующему клиету");

            Console.ForegroundColor = defaultColor;
        }
    }
}
