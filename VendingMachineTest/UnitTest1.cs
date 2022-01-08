using System;
using Xunit;
using System.Linq;
using VendingMachineNS.ProductInfo;
using VendingMachineNS;

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
        public void ReduceShould()
        {
            int amountToReduce = 60;
            _sutVendingMachine.InsertMoney(500);
            int beforePurchasingProduct = _sutVendingMachine._moneyPool.MoneyInMachine;
            _sutVendingMachine._moneyPool.Reduce(amountToReduce);
            int actalValue = amountToReduce;


            //int afterPurchasingProduct = _sutVendingMachine._moneyPool.Reduce(productPrise);
            Assert.Equal(440, _sutVendingMachine._moneyPool.MoneyInMachine);
     


        }

        public 


    }
    /*[Fact]
    public void HasEnoughMoneyShould()
    {
        _sutVendingMachine.(4);
        bool result = _sutVendingMachine._moneyPool.Has(50);
        Assert.True(result);

    }*/
}




