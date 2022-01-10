using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineNS.ProductInfo
{   
    class Toy : Product
    {
        public string MadeIn { get; set; }

        public Toy(string name, int price, string madeIn) : base (name, price)
        {
            this.MadeIn = madeIn;            
        }
        public new string Info()
        {
            return base.Info() + $"\tMade in: { MadeIn}";
        }
        public string Play()
        {
            return "Now you can play with it";
        }
    }
}
