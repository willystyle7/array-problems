using System;
class FillMatrixD
{
    static void Main()
    {
        Console.Write("Enter the size of matrix: ");
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];
        int row = 0;
        int col = 0;
        string direction = "down";
        int bottom = size - 1;
        int top = 0;
        int left = 1;
        int right = size - 1;

        matrix[0, 0] = size * size - 1;
        for (int count = size * size - 2; count > 0; count--)
        {
            switch (direction)
            {
                case "down":
                    row++;
                    matrix[row, col] = count;
                    if (row == bottom)
                    {
                        direction = "right";
                        bottom--;
                    }
                    break;

                case "right":
                    col++;
                    matrix[row, col] = count;
                    if (col == right)
                    {
                        direction = "up";
                        right--;
                    }
                    break;

                case "up":
                    row--;
                    matrix[row, col] = count;
                    if (row == top)
                    {
                        direction = "left";
                        top++;
                    }
                    break;

                case "left":
                    col--;
                    matrix[row, col] = count;
                    if (col == left)
                    {
                        direction = "down";
                        left++;
                    }
                    break;
            }
        }

        for (row = 0; row < size; row++)
        {
            for (col = 0; col < size; col++)
            {
                Console.Write("{0,4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}