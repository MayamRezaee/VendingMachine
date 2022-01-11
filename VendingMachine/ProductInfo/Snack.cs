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

        // Which information vending machine show to user about each snack.
        public override string Info()
        {
            return base.Info() + $"\tSugar:{Sugar} gram";
        }

        // What should user do with a snack. 
        public string Eat()
        {
            return "Now you can eat your snack";
        }
    }

}