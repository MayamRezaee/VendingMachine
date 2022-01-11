using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineNS.ProductInfo

{
    class Drink : Product
    {
        public int CanCapacity { get; set; }
        public Drink(string name, int price, int cancapacity) : base(name, price)
        {
            this.CanCapacity = cancapacity;
        }

        // This method will get the product price, name and sugar from the base classe
        // and add a new property for drinks which is, "can capacity"
        public override string Info()
        {
            return base.Info() + $"\tCan capacity:{CanCapacity}";
        }
        public string Drinkit()
        {
            return "Now you can drink it";
        }

    }
}