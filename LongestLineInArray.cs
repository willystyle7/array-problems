using System;

namespace LongestLineInArray
{
    class Program
    {
        static void Main()
        {
            int[] array = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1, 1, 1, 1, 4 };
            int start = 0;
            int lenght = 1;
            int bestStart = 0;
            int bestLenght = 1;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != array[i - 1])
                {
                    if (lenght > bestLenght) { bestStart = start; bestLenght = lenght; }
                    start = i;
                    lenght = 1;
                }
                else lenght++;
            }
            if (lenght > bestLenght)
            {
                bestLenght = lenght;
                bestStart = start;
            }
            Console.Write("Longest line in array is : ");
            for (int i = bestStart; i < (bestStart + bestLenght); i++)
            {
                Console.Write("{0,3}", array[i]);
            }
            Console.WriteLine();
        }
    }
}
