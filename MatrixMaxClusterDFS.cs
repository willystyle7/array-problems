using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixMaxClusterDFS
{
    class MatrixMaxClusterDFS
    {
        static void Main()
        {
            int[,] matrix =
            {
                {1, 3, 2, 2, 2, 4 },
                {3, 3, 3, 2, 4, 4 },
                {4, 3, 1, 2, 3, 3 },
                {4, 3, 1, 3, 3, 1 },
                {4, 3, 3, 3, 1, 1 }
            };
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            List<int> clusters = new List<int>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        int cluster = 0;
                        TraverseDFS(matrix, i, j, ref cluster);
                        clusters.Add(cluster);
                    }
                }
            }
            clusters = clusters.OrderByDescending(c => c).ToList();
            Console.WriteLine("Maximum cluster in matrix: {0}", clusters.First());
        }

        private static void TraverseDFS(int[,] matrix, int row, int col, ref int cluster)
        {
            cluster++;
            int clusterElement = matrix[row, col];
            matrix[row, col] = 0;
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            if ((row - 1 >= 0) && matrix[row - 1, col] == clusterElement) TraverseDFS(matrix, row - 1, col, ref cluster);
            if ((row + 1 < rows) && matrix[row + 1, col] == clusterElement) TraverseDFS(matrix, row + 1, col, ref cluster);
            if ((col - 1 >= 0) && matrix[row, col - 1] == clusterElement) TraverseDFS(matrix, row, col - 1, ref cluster);
            if ((col + 1 < columns) && matrix[row, col + 1] == clusterElement) TraverseDFS(matrix, row, col + 1, ref cluster);
            return;
        }
    }
}
