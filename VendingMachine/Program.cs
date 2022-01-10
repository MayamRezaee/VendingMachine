using System;

namespace VendingMachineNS.ProductInfo
{
    class Program
    {
        static IVending vendingMachine = new VendingMachine();
        static void Main(string[] args)
        {
            RequestUserAction();
        }

        // This method will get the user requests. 
        public static void RequestUserAction()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n Welcome to my Vending Machine" +
                 "\n Please choose one of the action below: " +
                 "\n 1: Show all the products" +
                 "\n 2: Insert Money" +
                 "\n 3: Purchase a product" +
                 "\n 4: Exit the program");
            Console.ResetColor();
            int userRequest = Int32.Parse(Console.ReadLine());

            switch (userRequest)
            {

                case 1:

                    Console.WriteLine("You can see all the products in my vending machine here:");

                    foreach (var product in vendingMachine.ShowAll())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" Product ID: {product.Id}");
                        Console.ResetColor();

                        if (product is Drink)
                        {
                            Console.WriteLine("\n" + (product as Drink).Info());
                        }
                        else if (product is Toy)
                        {
                            Console.WriteLine("\n" + (product as Toy).Info());
                        }
                        else
                        {
                            Console.WriteLine("\n" + (product as Snack).Info());
                        }
                    }

                    break;
                case 3:
                    BuyAProduct();
                    break;
                case 2:
                    InsertMoney();
                    break;
                case 4:
                    vendingMachine.EndTransaction();
                    return;

                default:
                    break;

            }
            RequestUserAction();
        }
        
        //This method will be used when user wants to insert money to the vending machine. 
        private static void InsertMoney()
        {
            string strFixedDenominations = "";
            for (int i = 0; i < MoneyPool.FixedDenominations.Length; i++)
            {
                strFixedDenominations += MoneyPool.FixedDenominations[i] + " , ";
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The money you insert to the vending machine should be from the list below:" +
                 "\n" + strFixedDenominations.Remove(strFixedDenominations.Length - 2));
            Console.ResetColor();
            int inputMoney = Int32.Parse(Console.ReadLine());
            vendingMachine.InsertMoney(inputMoney);

        }

        // This method will get called when user wants to buy a new product.
        private static void BuyAProduct()
        {

            Console.WriteLine("Please enter the ID of a product you want to buy. ");

            foreach (var product in vendingMachine.ShowAll())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" Product ID: {product.Id}");
                Console.ResetColor();

                //USer will get a message about how to use the product she/he have bought. 
                if (product is Drink)
                {
                    Console.WriteLine("\n" + (product as Drink).Info());
                }
                else if (product is Toy)
                {
                    Console.WriteLine("\n" + (product as Toy).Info());
                }
                else
                {
                    Console.WriteLine("\n" + (product as Snack).Info());
                }

            }
            int selectedProduct = Int32.Parse(Console.ReadLine());
            vendingMachine.Purchase(selectedProduct);
        }

    }
}

