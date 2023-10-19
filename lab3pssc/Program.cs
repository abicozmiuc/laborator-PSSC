using lab3pssc.Domain;
using System;
using System.Collections.Generic;
using static lab3pssc.Domain.ShoppingCartChoice;

namespace lab3pssc
{
     private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    class Program
    {

        static void Main(string[] args)
        {
            Client newClient = new()
            {
                name = "Alina",
                adress = "Calea Radnei, 31"
            };

            ShoppingCart newShoppingCart = new()
            {
                client = newClient,
                products = new List<Product>()
            };

        
            result.Match(
                );

        }

        private static List<UnvalidatedProduct> ReadListOfProducts()
        {
            List<UnvalidatedProduct> listOfProducts = new();

            string response;
            do
            {
                
            } while ();

            return listOfProducts;
        }

    }
}