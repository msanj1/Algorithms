using System;

namespace MoneyChange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var money = int.Parse(Console.ReadLine());
            var count = 0;
            while(money > 0)
            {
                if(money >= 10)
                {
                    money -= 10;
                    count++;
                }else if (money >= 5)
                {
                    money -= 5;
                    count++;
                }
                else if (money >= 1)
                {
                    money -= 1;
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
