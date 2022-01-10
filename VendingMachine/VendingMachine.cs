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

            // What happen when user doesnt have enough money in the vending machine,
            // in order to but the product she/he wants.
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

            // Usage info of a product.
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

        // return to all the product in list products in repository.
        public List<Product> ShowAll()
        {
            return repository.products;
        }

        // Add the amount of money user adds to vending machine. 
        public void InsertMoney(int amount)
        {
            _moneyPool.Add(amount);
        }

        // If user want to exit from the system, a message will appear about the amunt of
        // money she/he have left in the machine and the amount of money she/he will get back in 
        // a apprepriate way. 
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
                    Console.WriteLine($" Get {item.Value},  {item.Key} SEK");
                }

                Console.ResetColor();
                _moneyPool.Reset();
                Console.ResetColor();
            }
        }





    }
}
