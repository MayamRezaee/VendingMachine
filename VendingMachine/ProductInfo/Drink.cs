using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineNS.ProductInfo

{
    class Drink : Snack
    {      
        public int CanCapacity { get; set; }
        public Drink( string name, int price, double sugar, int cancapacity) : base(name, price, sugar)
        {
            this.CanCapacity = cancapacity;
        }
        public new string Info()
        {
            return base.Info() + $"\tCan capacity:{CanCapacity}";
        }
        public string Drinkit()
        {
            return "Now you can drink it";
        }

    }
}