using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineNS.ProductInfo
{
   
    public abstract class Product
    {
        public string name;
        public int Id { get; set; }
        public int price;
        public static int idCounter = 0;

        public Product(string name, int price)
        {
            this.name = name;
            this.Id = GetId();
            this.price = price;
        }

        protected int GetId()
        {
            return ++idCounter;
        }

        public virtual string Info()
        {
            return $"   Name: {name}\tPrice: {price}";
        }

    }
        
}
