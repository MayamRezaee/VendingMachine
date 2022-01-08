using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineNS
{
    public class MoneyPool
    {
        public int MoneyInMachine { get; private set; }

        public static readonly int[] FixedDenominations = {
            1, 5, 10, 20, 50, 100, 500, 1000
        };


        public void Add(int amountToAdd)
        {
            // if (!FixedDenominations.Contains(amountToAdd)) {
            // throw new FixedDenominationOutOfRangeException();
            // } 
            if (!FixedDenominations.Contains(amountToAdd))
            {
                Console.WriteLine("You should insert 1, 5, 10, 20, 50, 100, 500 or 1000 SEK. Choose one of the options below ");
                return;
            }

            MoneyInMachine += amountToAdd;
        }

        public bool Has(int amountToAdd)
        {
            return MoneyInMachine >= amountToAdd;
        }

        public void Reduce(int amountToReduce)
        {
            MoneyInMachine -= amountToReduce;
        }

        public void Reset()
        {
            MoneyInMachine = 0;
        }

        public Dictionary<int, int> CalculateRemaining()
        {
            Dictionary<int, int> remaining = new Dictionary<int, int>();
            

            //1000,500,100,50,20,10,5,1
            //moneyInMachine = 50
            //den = 100
            foreach (int den in FixedDenominations.Reverse())
            {
                while (MoneyInMachine >= den)
                {
                    if (!remaining.ContainsKey(den))
                    {
                        remaining.Add(den, 0);
                    }

                    MoneyInMachine -= den;
                    remaining[den] += 1;
                }

            }


            return remaining;
        }

        // function to find place value
        /*static int placeValue(int N, int num)
        {
            int total = 1, value = 0, rem = 0;
            while (true)
            {
                rem = N % 10;
                N = N / 10;

                if (rem == num)
                {
                    value = total * rem;
                    break;
                }

                total = total * 10;
            }
            return value;
        }

        // Driver Code
        public static void Main()
        {

            // Digit, which we want
            // to find place value.
            int D = 5;

            // Number from where we
            // want to find place value.
            int N = 85932;

            Console.Write(placeValue(N, D));
        }*/
    }

}

