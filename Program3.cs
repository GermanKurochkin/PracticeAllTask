using System;

namespace Task3
{
    class Program3
    {
        static double InputNum()
        {
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
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x");
            double x = InputNum();
            Console.WriteLine("Введите y");
            double y = InputNum();
            if ((x >= 0 && (x * x + y * y <= 1)) || (x <= 0 && y >= -0.5 * x - 1 && y <= 0.5 * x + 1))
            {
                Console.WriteLine("Принадлежит");
            }
            else Console.WriteLine("Не принадлежит");
        }
    }
}
