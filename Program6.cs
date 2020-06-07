using System;

namespace Task6
{
    class Program6
    {
        static double e;
        static int n, count;
        static int i;
        static double InputNum(string output)
        {
            Console.WriteLine(output);
            double num;
            string input;
            bool ok;
            do
            {
                input = Console.ReadLine();
                ok = double.TryParse(input, out num);
                if (!ok) Console.WriteLine("Некорректный ввод");

            } while (!ok);

            return num;

        }
        static int InputInt(int maxNum)
        {
            int num;
            string input;
            bool ok;
            do
            {
                input = Console.ReadLine();
                ok = int.TryParse(input, out num);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (num < 1 || num > maxNum) Console.WriteLine($"Некорректный ввод. Введите число не больше {maxNum}");
            } while (!ok || num < 1 || num > maxNum);

            return num;

        }
        static void Sequence(double a1, double a2, double a3)
        {
            if (count == n)
            {
                return;
            }
            double aNext = a3 + 2 * a2 - 2 * a1;
            if (Math.Abs(aNext - a3) > e)
            {
                count++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{aNext} - {i} элемент");
                Console.ResetColor();
            }
            else Console.WriteLine($"{aNext} - {i} элемент");

            i++;
            Sequence(a2, a3, aNext);
        }
        static void Main(string[] args)
        {
            /*
            11.Ввести а1, а2, а3, N, E.Построить последовательность чисел ак = ак–1 + 2 * ак - 2 * ак–3.
            Найти первые ее N элементов, такие что | ак  – ак–1 | > E.
            Напечатать последовательность, выделить искомые элементы и их номера.
            */
            double a1 = InputNum("Введите a1");
            double a2 = InputNum("Введите a2");
            double a3 = InputNum("Введите a3");
            Console.WriteLine("Введите n");
            n = InputInt(100);
            e = InputNum("Введите e");
            Console.WriteLine($"{a1} - 1 элемент");
            if (Math.Abs(a2 - a1) > e && count < n)
            {
                count++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{a2} - 2 элемент");
                Console.ResetColor();
            }
            else Console.WriteLine($"{a2} - 2 элемент");

            if (Math.Abs(a3 - a2) > e && count < n)
            {
                count++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{a3} - 3 элемент");
                Console.ResetColor();
            }
            else Console.WriteLine($"{a3} - 3 элемент");

            i = 4;
            Sequence(a1, a2, a3);

        }
    }
}
