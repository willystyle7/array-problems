using System;

namespace ReverseArray
{
    class Program
    {
        static void Main()
        {
            int[] array = { 2, 5, 0, 7, 8, 6, 1 };
            Console.WriteLine("Array : {0}", string.Join(", ", array));
            for (int i = 0; i < array.Length / 2; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }
            Console.WriteLine("Reversed Array : {0}", string.Join(", ", array));
        }
    }
}
