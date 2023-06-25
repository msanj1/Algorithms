using System;

namespace EditDistance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var string1 = Console.ReadLine();
            var string2 = Console.ReadLine();

            var editDistances = new int[string1.Length + 1, string2.Length + 1]; //[i, j]

            for(int i=0; i< string1.Length + 1; i++)
            {
                editDistances[i , 0] = i;
            }

            for (int j = 0; j < string2.Length + 1; j++)
            {
                editDistances[0, j] = j;
            }

            for(int n=1; n <= string1.Length; n++) //n => string1, m => string2
            {
                for(int m=1;m <= string2.Length; m++)
                {
                    var i = n - 1;
                    var j = m - 1;
                    var deletion = editDistances[n-1, m] + 1;
                    var insertion = editDistances[n, m - 1] + 1;
                    var substituion = editDistances[n - 1, m - 1] + 1;
                    var match = editDistances[n - 1, m - 1];

                    if (string1[i] == string2[j])
                    {
                        editDistances[n, m] = Math.Min(Math.Min(deletion, insertion), match);
                    }
                    else
                    {
                        editDistances[n, m] = Math.Min(Math.Min(deletion, insertion), substituion);
                    }
                }
            }

            Console.WriteLine(editDistances[string1.Length, string2.Length]);
        }
    }
}
