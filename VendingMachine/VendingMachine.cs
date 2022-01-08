using System;
using System.Collections.Generic;

namespace VendingMachineNS.ProductInfo
{
    public class VendingMachine : IVending
    {
        public ProductRepository repository;
        public MoneyPool _moneyPool;



        public VendingMachine()
        {
            repository = new ProductRepository();
            _moneyPool = new MoneyPool();

        }

        public void Purchase(int id)
        {
            var product = repository.GetProductById(id);


            if (!_moneyPool.Has(product.price))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You dont have enough money to buy {product.name}");
                Console.WriteLine($"You have, {_moneyPool.MoneyInMachine} SEK. Please insert more money to the vending machine in order to buy {product.name}");
                Console.ResetColor();
                return;
            }

            _moneyPool.Reduce(product.price);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You've bought {product.name} for {product.price} SEK. ");

            if (product is Drink)
            {
                Console.WriteLine((product as Drink).Drinkit());
            }
            else if (product is Toy)
            {
                Console.WriteLine((product as Toy).Play());
            }
            else
            {
                Console.WriteLine((product as Snack).Eat());
            }
            Console.Write($"You have ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(_moneyPool.MoneyInMachine + " SEK");
            Console.WriteLine(" left in the vending machine");
            Console.ResetColor();
        }

        public List<Product> ShowAll()
        {
            return repository.products;
        }

        internal void InsertMoney(int v, object amount)
        {
            throw new NotImplementedException();
        }

        public void InsertMoney(int amount)
        {
            _moneyPool.Add(amount);
        }

        public void EndTransaction()
        {
            if (_moneyPool.MoneyInMachine == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" Thank you for using my vending machine.  \n You have no money left in my wending machine");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" Thank you for using my vending machine.  \n You have ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(_moneyPool.MoneyInMachine + " SEK");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" left. get it!");

                foreach (KeyValuePair<int, int> item in _moneyPool.CalculateRemaining())
                {
                    Console.WriteLine($" Get {item.Value} of {item.Key} SEK");
                }

                Console.ResetColor();
                _moneyPool.Reset();
                Console.ResetColor();
            }
        }





    }
}
