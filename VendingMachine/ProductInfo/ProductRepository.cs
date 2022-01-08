using System;
using System.Collections.Generic;

namespace VendingMachineNS.ProductInfo
{
    public class ProductRepository
    {
        public List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();

            Toy teddy = new Toy("Teddy", 500, "Iran");
            Toy doll = new Toy("Doll", 500, "Sweden");
            Drink cola = new Drink("Cola", 15, 200, 100);
            Drink fanta = new Drink("Fanta", 15, 30, 100);           
            Snack chips = new Snack("Chips", 50, 100);
            Snack nuts = new Snack("Nuts", 60, 50);
                      
            products.Add(teddy);
            products.Add(doll);
            products.Add(cola);
            products.Add(fanta);           
            products.Add(chips);
            products.Add(nuts);
        }

        public Product GetProductById(int id)
        {

            foreach (var productItem in products)
            {
                if (productItem.Id == id)
                {
                    return productItem;
                }
            }

            throw new ArgumentOutOfRangeException();
        }


        
    }
}