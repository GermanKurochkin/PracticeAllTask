using System;

namespace Task11
{
    class Program11
    {
        const int size = 10;
        static char[,] matr = new char[size, size];
        static bool[,] matrKey = new bool[size, size];
        static string str = "Comparisons between countries also need to be treated cautiosly. Individualistic western country. A.";
        static char[] strMas = str.ToCharArray();
        static void WriteMatr(bool[,] matr)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    if (matr[i, j]) Console.Write("1 ");
                    else Console.Write("0 ");
                Console.WriteLine();
            }

        }
        static void WriteMatr(char[,] matr)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(matr[i, j] + " ");
                Console.WriteLine();
            }

        }
        static void TurnMatrKey()//вправо
        {
            bool[,] matrNew = new bool[size, size];
            Array.Copy(matrKey, matrNew, size * size);
            for (int i = 1; i <= size / 2; i++)
            {
                for (int j = 1; j <= size / 2; j++)
                {
                    bool temp = matrKey[i - 1, j - 1];
                    matrKey[i - 1, j - 1] = matrKey[size - j, i - 1];
                    matrKey[size - j, i - 1] = matrKey[size - i, size - j];
                    matrKey[size - i, size - j] = matrKey[j - 1, size - i];
                    matrKey[j - 1, size - i] = temp;


                }
            }
        }
        static void MakeKey()
        {
            Random rand = new Random();
            for (int i = 1; i <= size / 2; i++)
            {
                for (int j = 1; j <= size / 2; j++)
                {
                    switch (rand.Next(4))
                    {
                        case 0:
                            matrKey[i - 1, j - 1] = true;
                            break;
                        case 1:
                            matrKey[j - 1, size - i] = true;
                            break;
                        case 2:
                            matrKey[size - j, i - 1] = true;
                            break;
                        case 3:
                            matrKey[size - i, size - j] = true;
                            break;
                    }
                }
            }
        }
        static void Encrypt(char[] str)
        {
            int n = 0;
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        if (matrKey[i, j])
                        {
                            matr[i, j] = str[n];
                            n++;
                        }
                }
                TurnMatrKey();
            }
        }
        static void Decrypt()
        {
            string str = "";
            int n = 0;
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        if (matrKey[i, j])
                        {
                            str += matr[i, j];
                        }
                }
                TurnMatrKey();
            }
            Console.WriteLine(str);
        }
        static void Main(string[] args)
        {
            MakeKey();
            Console.WriteLine("Ключ:");
            WriteMatr(matrKey);
            Console.WriteLine();
            Console.WriteLine("Изначальная сообщение:");
            Console.WriteLine(str);
            Console.WriteLine();


            Encrypt(strMas);
            Console.WriteLine("Зашифрованное сообщение:");
            WriteMatr(matr);
            Console.WriteLine();

            Console.WriteLine("Расшифрованное сообщение:");
            Decrypt();

        }
    }
}
