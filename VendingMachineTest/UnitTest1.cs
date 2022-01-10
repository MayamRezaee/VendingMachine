using System;
using Xunit;
using System.Linq;
using VendingMachineNS.ProductInfo;
using VendingMachineNS;
using System.Collections.Generic;

namespace VendingMachineTest
{
    public class VendingMachineTest
    {

        private readonly VendingMachine _sutVendingMachine;

        public VendingMachineTest()
        {
            _sutVendingMachine = new VendingMachine();
        }

        [Fact]
        public void TestInputValidity()
        {
            int val = 99;
            _sutVendingMachine.InsertMoney(val);

            if (MoneyPool.FixedDenominations.Contains(val))
            {
                Assert.Equal(val, _sutVendingMachine._moneyPool.MoneyInMachine);
            }
            else
            {
                Assert.Equal(0, _sutVendingMachine._moneyPool.MoneyInMachine);
            }

        }
        [Fact]
        public void PurchaseShould()
        {
            _sutVendingMachine.InsertMoney(1000);
            int beforePurchasingMoney = _sutVendingMachine._moneyPool.MoneyInMachine;
            var products = _sutVendingMachine.repository.products;

            Random random = new Random();
            var randomProduct = products[random.Next(0, products.Count)];
            _sutVendingMachine.Purchase(randomProduct.Id);

            Assert.Equal(_sutVendingMachine._moneyPool.MoneyInMachine, beforePurchasingMoney - randomProduct.price);
        }

       
       
        [Fact]
        public void CalculateRemainingShould()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertMoney(1000);
            vendingMachine.InsertMoney(500);
            vendingMachine.InsertMoney(100);
            vendingMachine.InsertMoney(50);
            vendingMachine.InsertMoney(10);
            vendingMachine.InsertMoney(1);
            Dictionary<int,int> actual =  vendingMachine._moneyPool.CalculateRemaining();

            int remainnig = 1661;
            int[] FixedDenominations = MoneyPool.FixedDenominations; //1,5,10,20, 100,500,1000
            if (remainnig > 0)
            {
                Dictionary<int, int> Dicremaining = new Dictionary<int, int> ();
                foreach (int item in FixedDenominations.Reverse())
                {
                    while (remainnig >= item)
                    {
                        if (!Dicremaining.ContainsKey(item))
                        {
                            Dicremaining.Add(item,0);
                        }

                        remainnig -= item;
                        Dicremaining[item]++;
                    }


                }

                Assert.Equal(Dicremaining,actual);          
            }

         
        }
        // Testing if the machine reduce correct amount of money according to product price
        [Fact]
        public void ReduceShould()
        {
            int amountToReduce = 60;
            _sutVendingMachine.InsertMoney(500);
            int beforePurchasingProduct = _sutVendingMachine._moneyPool.MoneyInMachine;
            _sutVendingMachine._moneyPool.Reduce(amountToReduce);
            int actalValue = amountToReduce;

            Assert.Equal(440, _sutVendingMachine._moneyPool.MoneyInMachine);

        }

    }
    
}




