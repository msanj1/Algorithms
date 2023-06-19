using System;
using System.Collections.Generic;

namespace MoneyChange
{
    internal class Program
    {
        static Dictionary<int, int> memo = new Dictionary<int, int>();
        static void Main(string[] args)
        {
            var money = int.Parse(Console.ReadLine());
            Console.WriteLine(MoneyChange(money, new int[] {1, 3, 4}));
        }

        static int MoneyChange(int money, int[] coins)
        {
            int output;
            if(memo.TryGetValue(money,out output))
            {
                return output;
            }

            if (money == 0)
            {
                return 0;
            }

            var minChange = int.MaxValue;
            for(int i=0; i< coins.Length; i++)
            {
                var coin = coins[i];
                if (money >= coin)
                {
                    var change = MoneyChange(money - coin, coins);
                    memo[money - coin]=change;
                    if (change != int.MaxValue && change < minChange)
                    {
                        minChange = change + 1;
                    }
                }
            }

            return minChange;
        }
    }
}
