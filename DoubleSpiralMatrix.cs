using System;

class DoubleSpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter the size of matrix: ");
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];
        FillLowerPartMatrix(matrix);
        FillUpperPartMatrix(matrix);
        PrintMatrix(matrix);
    }

    static void FillLowerPartMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        matrix[0, 0] = 1;
        string direction = "down-right";
        int row = 0;
        int col = 0;
        int bottom = size - 1;
        int top = 1;
        int left = 0;        
        for (int count = 2; count <= size * (size + 1) / 2; count++)
        {
            switch (direction)
            {
                case "down-right":
                    row++;
                    col++;
                    matrix[row, col] = count;
                    if (row == bottom)
                    {
                        direction = "left";
                        bottom--;
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
                case "up":
                    row--;
                    matrix[row, col] = count;
                    if (row == top)
                    {
                        direction = "down-right";
                        top += 2;
                    }
                    break;
            }
        }
    }

    static void FillUpperPartMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        matrix[size - 2, size - 1] = size * (size + 1) / 2 + 1;
        string direction = "up-left";
        int row = size - 2;
        int col = size - 1;
        int bottom = size - 3;
        int top = 0;        
        int right = size - 1;
        for (int count = size * (size + 1) / 2 + 2; count <= size * size; count++)
        {
            switch (direction)
            {
                case "up-left":
                    row--;
                    col--;
                    matrix[row, col] = count;
                    if (row == top)
                    {
                        direction = "right";
                        top++;
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
                case "down":
                    row++;
                    matrix[row, col] = count;
                    if (row == bottom)
                    {
                        direction = "up-left";
                        bottom--;
                    }
                    break;
            }
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int row = 0;
        int col = 0;
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
