using System.Collections.Generic;
using VendingMachineNS;

namespace VendingMachineNS.ProductInfo
{
    public interface IVending
    {
        void Purchase(int id);
        public List<Product> ShowAll();
        void InsertMoney(int amount);
        void EndTransaction();
        /*string Eat();
        string Drink();
        string Play();*/


    }

}

