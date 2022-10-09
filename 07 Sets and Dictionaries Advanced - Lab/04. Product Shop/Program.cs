using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productShop = new Dictionary<string, Dictionary<string, double>>();

            string[] comand = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            while (comand[0] != "Revision")
            {
                string shop = comand[0];
                string nameProduct = comand[1];
                double price = double.Parse(comand[2]);

                AddShopProduct(productShop, shop, nameProduct, price);

                comand = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            Print(productShop);
        }

        static void AddShopProduct(Dictionary<string, Dictionary<string, double>> productShop, string shop, string nameProduct, double price)
        {
            if (!productShop.ContainsKey(shop))
            {
                productShop.Add(shop, new Dictionary<string, double>());
            }
            if (!productShop[shop].ContainsKey(nameProduct))
            {
                productShop[shop][nameProduct] = price;
            }

        }

        static void Print(Dictionary<string, Dictionary<string, double>> productShop)
        {
            //{shop}->
            //Product: { product}, Price: { price}

            foreach (var shop in productShop.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
                       
        }
    }
}
