using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineNS.ProductInfo
{   
    class Snack : Product
    {
      
        public double Sugar { get; set; }
        public Snack(string name, int price, double sugar) : base (name, price)
        {
            this.Sugar = sugar;
        }
        public new string Info()
        {
            return base.Info() + $"\tSugar:{Sugar} gram";
        }
        public string Eat()
        {
            return "Now you can eat your snack";
        }
    }

}