using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineNS
{
    public class MoneyPool
    {
        public int MoneyInMachine { get; private set; }

        // creating a list of the money user can put in the system. 
        public static readonly int[] FixedDenominations = {
            1, 5, 10, 20, 50, 100, 500, 1000
        };


        public void Add(int amountToAdd)
        {
          
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

        // Creating a Dictionary<int, int> which can return the left money in the machine to 
        // the user in a appropriate way. 
        public Dictionary<int, int> CalculateRemaining()
        {
            Dictionary<int, int> remaining = new Dictionary<int, int>();

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


    }

}

