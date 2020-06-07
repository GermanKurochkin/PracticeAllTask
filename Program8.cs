using System;

namespace Task8
{
    class Program8
    {
        static bool[,] matr = new bool[1, 1];
        static int count;

        static int InputNum(int maxNum)
        {
            int num;
            string input;
            bool ok;
            do
            {
                input = Console.ReadLine();
                ok = int.TryParse(input, out num);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (num < 4 || num > maxNum) Console.WriteLine($"Некорректный ввод. Введите число не больше {maxNum} и больше 4");
            } while (!ok || num < 4 || num > maxNum);

            return num;

        }
        static void GetCycle()
        {
            Random rand = new Random();
            int num, numOfLink, n, left, right;

            int size = matr.GetLength(0);
            for (int j = 1; j <= size; j++)
            {
                num = 0;
                for (int i = 1; i <= j; i++)
                {
                    if (matr[i - 1, j - 1]) num++;
                }
                if (j < size - 2) n = rand.Next(2) * 2;
                else n = 0;
                numOfLink = rand.Next((size - j) / 2) * 2 + n + num % 2;
                while (numOfLink != 0)
                {
                    left = 0;
                    right = 0;
                    while (numOfLink != 0)
                    {
                        if (rand.Next(2) == 0)
                        {
                            left++;
                            numOfLink--;
                            matr[j - 1 + left, j - 1] = true;
                            matr[j - 1, j - 1 + left] = true;
                        }
                        else
                        {
                            right++;
                            numOfLink--;
                            matr[size - right, j - 1] = true;
                            matr[j - 1, size - right] = true;
                        }

                    }
                }

            }

        }
        static void Write()
        {
            Console.WriteLine();
            int size = matr.GetLength(0);
            Console.WriteLine("Вершины: ");
            for (int i = 1; i <= size; i++)
            {
                Console.Write($" {i}");
            }
            Console.WriteLine();
            Console.WriteLine("Вектора: ");
            for (int i = 1; i <= size; i++)
            {
                for (int j = i + 1; j <= size; j++)
                {
                    if (matr[i - 1, j - 1]) Console.Write($"  {i} {j};");
                }
            }
            Console.WriteLine();
        }
        static void GetTest(int size)
        {
            bool ok = false;
            matr = new bool[size, size];
            ok = false;
            while (!ok)//пока пустой
            {
                GetCycle();
                for (int i = 0; i < size; i++)
                {
                    if (ok) break;
                    for (int j = 0; j < size; j++)
                    {
                        if (matr[i, j])
                        {
                            ok = true;
                            break;
                        }
                    }
                }
            }
            Write();


        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вершин");
            count = InputNum(20);
            GetTest(count);
        }
    }
}
