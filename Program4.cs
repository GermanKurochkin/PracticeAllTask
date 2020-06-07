using System;

namespace Task4
{
    class Program4
    {
        static bool Square(int num)
        {
            return num > 0 && Math.Sqrt(num) - Math.Round(Math.Sqrt(num)) == 0;
        }
        static int InputNum()
        {
            int num;
            string input;
            bool ok;
            do
            {
                input = Console.ReadLine();
                ok = int.TryParse(input, out num);
                if (!ok) Console.WriteLine("Некорректный ввод");
            } while (!ok || num < 1);

            return num;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите n");
            int n = InputNum();
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= Math.Sqrt(i); j++)
                {
                    if (Square(i - j * j))
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
            }
        }
    }
}
