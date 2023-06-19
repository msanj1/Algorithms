using System;

namespace RecursiveChange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var money = int.Parse(Console.ReadLine()) ;
            Console.WriteLine(RecursiveChange(money, 9, 6, 5, 1));
        }

        static int RecursiveChange(int money, params int[] coins)
        {
            if (money == 0)
            {
                return 0;
            }

            var minNumberOfCoins = int.MaxValue;
            for(int i=0; i < coins.Length; i++)
            {
                var coin = coins[i];
                if (money >= coin)
                {
                    var numberOfCoins = RecursiveChange(money - coin, coins);
                    if (numberOfCoins != int.MaxValue && numberOfCoins + 1 < minNumberOfCoins)
                    {
                        minNumberOfCoins = numberOfCoins + 1;
                    }
                }
            }

            return minNumberOfCoins;
        }
    }
}
