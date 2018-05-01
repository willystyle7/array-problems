using System;

namespace GoInMatrixDiagonals
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int number = 1;
            // po ednite diagonali
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < i + 1; j++)
            //    {
            //        matrix[n - j - 1, n - i + j - 1] = number++;
            //    }
            //}
            //for (int i = n - 2; i >= 0; i--)
            //{
            //    for (int j = i; j >= 0; j--)
            //    {
            //        matrix[j, i - j] = number++;
            //    }
            //}

            // po drugi diagonali
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    matrix[n - i + j - 1, j] = number++;
                }
            }
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    matrix[i - j, n - j - 1] = number++;
                }
            }

            // pechatane
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0, 3}", matrix[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}
