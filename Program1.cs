using System;

namespace practicaAllTask
{
    class Program1
    {
        static long Summ(int d, int m, int y)//сумма дней от 00.00.0000
        {
            int a = (14 - m) / 12;
            y = y + 4800 - a;
            m = m + 12 * a - 3;
            return 365 * y + d + (153 * m + 2) / 5 + y / 4 - y / 100 + y / 400;//-32083
        }
        static void Main(string[] args)
        {

            string str = Console.ReadLine();
            string str2 = Console.ReadLine();
            string[] input1 = str.Split('.');
            string[] input2 = str2.Split('.');


            int[] time1 = new int[3];
            int[] time2 = new int[3];
            for (int i = 0; i < 3; i++)
                time1[i] = int.Parse(input1[i]);
            for (int i = 0; i < 3; i++)
                time2[i] = int.Parse(input2[i]);

            Console.WriteLine(Summ(time2[0], time2[1], time2[2]) - Summ(time1[0], time1[1], time1[2]) + 1);

        }
    }
}
