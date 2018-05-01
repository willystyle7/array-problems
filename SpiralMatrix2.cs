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
        string direction = "right";
        int bottom = size - 1;
        int top = 1;
        int left = 0;
        int right = size - 1;

        matrix[0, 0] = 1;
        for (int count = 2; count <= size * size; count++)
        {
            switch (direction)
            {
                case "down":
                    row++;
                    matrix[row, col] = count;
                    if (row == bottom)
                    {
                        direction = "left";
                        bottom--;
                    }
                    break;

                case "right":
                    col++;
                    matrix[row, col] = count;
                    if (col == right)
                    {
                        direction = "down";
                        right--;
                    }
                    break;

                case "up":
                    row--;
                    matrix[row, col] = count;
                    if (row == top)
                    {
                        direction = "right";
                        top++;
                    }
                    break;

                case "left":
                    col--;
                    matrix[row, col] = count;
                    if (col == left)
                    {
                        direction = "up";
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