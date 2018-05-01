using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixMaxClusterBFS
{
    class MatrixMaxClusterBFS
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
                        TraverseBFS(matrix, i, j, ref cluster);
                        clusters.Add(cluster);
                    }
                }
            }
            clusters = clusters.OrderByDescending(c => c).ToList();
            Console.WriteLine("Maximum cluster in matrix: {0}", clusters.First());
        }

        private static void TraverseBFS(int[,] matrix, int startRow, int startCol, ref int cluster)
        {            
            int clusterElement = matrix[startRow, startCol];
            matrix[startRow, startCol] = 0;
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(Tuple.Create(startRow, startCol));
            while (queue.Count > 0)
            {
                var next = queue.Dequeue();
                int row = next.Item1;
                int col = next.Item2;
                cluster++;
                if ((row - 1 >= 0) && matrix[row - 1, col] == clusterElement)
                {
                    matrix[row - 1, col] = 0;
                    queue.Enqueue(Tuple.Create(row - 1, col));
                }
                if ((row + 1 < rows) && matrix[row + 1, col] == clusterElement)
                {
                    matrix[row + 1, col] = 0;
                    queue.Enqueue(Tuple.Create(row + 1, col));
                }
                if ((col - 1 >= 0) && matrix[row, col - 1] == clusterElement)
                {
                    matrix[row, col - 1] = 0;
                    queue.Enqueue(Tuple.Create(row, col - 1));
                }
                if ((col + 1 < columns) && matrix[row, col + 1] == clusterElement)
                {
                    matrix[row, col + 1] = 0;
                    queue.Enqueue(Tuple.Create(row, col + 1));
                }                
            }
        }
    }
}
