using System;

namespace SpiralMatrix
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            int[,] array = new int[n, n];
            int next = 0;
            // obhojdane v spirala
            for (int i = 0; i < n / 2; i++)
            {
                for (int x1 = i; x1 < n - i; x1++)
                {
                    array[x1, i] = ++next;
                }
                for (int y1 = i + 1; y1 < n - i; y1++)
                {
                    array[n - i - 1, y1] = ++next;
                }
                for (int x2 = n - i - 2; x2 >= i; x2--)
                {
                    array[x2, n - i - 1] = ++next;
                }
                for (int y2 = n - i - 2; y2 >= i + 1; y2--)
                {
                    array[i, y2] = ++next;
                }
            }
            // popylvane na centyra
            if (n % 2 == 1) array[n / 2, n / 2] = n * n;
            // otpechatvane na matricata
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
