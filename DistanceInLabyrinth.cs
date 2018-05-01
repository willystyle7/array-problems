using System;
using System.Collections.Generic;

namespace DistanceInLabyrinth
{
    class Program
    {
        static int initialRow, initialColumn, distance, n;
        static bool MakeMove = false;
        static string[,] labyrinth;

        static void Main()
        {
            // enter Labyrinth
            InputLabyrinth();

            FindStartingCell();           

            // First Move
            if (initialColumn - 1 >= 0) if (labyrinth[initialRow, initialColumn - 1] == "0") labyrinth[initialRow, initialColumn - 1] = "1";
            if (initialColumn + 1 < n) if (labyrinth[initialRow, initialColumn + 1] == "0") labyrinth[initialRow, initialColumn + 1] = "1";
            if (initialRow - 1 >= 0) if (labyrinth[initialRow - 1, initialColumn] == "0") labyrinth[initialRow - 1, initialColumn] = "1";
            if (initialRow + 1 < n) if (labyrinth[initialRow + 1, initialColumn] == "0") labyrinth[initialRow + 1, initialColumn] = "1";
            distance = 1;

            // Make moves until can
            do
            {
                MakeMove = false;
                for (int i = 0; i < labyrinth.GetLongLength(0); i++)
                {
                    for (int j = 0; j < labyrinth.GetLongLength(1); j++)
                    {                        
                        if (labyrinth[i, j] == distance.ToString())
                        {
                            if (j - 1 >= 0) { if (labyrinth[i, j - 1] == "0") { labyrinth[i, j - 1] = (distance + 1).ToString(); MakeMove = true; } }
                            if (j + 1 < n) { if (labyrinth[i, j + 1] == "0") { labyrinth[i, j + 1] = (distance + 1).ToString(); MakeMove = true; } }
                            if (i - 1 >= 0) { if (labyrinth[i - 1, j] == "0") { labyrinth[i - 1, j] = (distance + 1).ToString(); MakeMove = true; } }
                            if (i + 1 < n) { if (labyrinth[i + 1, j] == "0") { labyrinth[i + 1, j] = (distance + 1).ToString(); MakeMove = true; } }                            
                        }
                    }
                }
                if (MakeMove) distance++;
            } while (MakeMove == true);

            MarkInaccessibleCells();
            PrintLabyrinth();
        }

        static void InputLabyrinth()
        {
            n = int.Parse(Console.ReadLine());
            labyrinth = new string[n, n];
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    labyrinth[i, j] = row[j].ToString();
                }
            }
            Console.WriteLine();
        }

        static void FindStartingCell()
        {
            for (int i = 0; i < labyrinth.GetLongLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLongLength(1); j++)
                {
                    if (labyrinth[i, j] == "*")
                    {
                        initialRow = i;
                        initialColumn = j;
                    }
                }
            }
        }

        static void MarkInaccessibleCells()
        {
            for (int i = 0; i < labyrinth.GetLongLength(0); i++)
                for (int j = 0; j < labyrinth.GetLongLength(1); j++)
                    if (labyrinth[i, j] == "0") labyrinth[i, j] = "u";
        }

        static void PrintLabyrinth()
        {
            for (int i = 0; i < labyrinth.GetLongLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLongLength(1); j++)
                    Console.Write("{0}", labyrinth[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
