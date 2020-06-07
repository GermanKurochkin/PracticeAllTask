using System;

namespace Task2
{
    class Program2
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int d, count = 0; ;
            for (int a = 1; a <= n / 4; a++)
            {
                for (int b = a; b <= n / 3; b++)
                {
                    for (int c = b; c <= n / 2; c++)
                    {
                        d = n - a - b - c;
                        if (d >= c) count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
