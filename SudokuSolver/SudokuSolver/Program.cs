﻿using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] vals = {
                { 0, 5, 0, 3, 4, 7, 1, 9, 0 },
                { 0, 0, 7, 0, 0, 0, 0, 6, 0 },
                { 2, 9, 0, 0, 6, 0, 7, 5, 0 },
                { 4, 0 ,0, 0, 0, 6, 0, 3, 0 },
                { 0, 0, 0, 1, 9, 4, 0, 0, 0 },
                { 0, 6, 0, 2, 0, 0, 0, 0, 5 },
                { 0, 2, 5, 0, 1, 0, 0, 4, 9 },
                { 0, 1, 0, 0, 0, 0, 2, 0, 0 },
                { 0, 4, 9, 6, 3, 2, 0, 1, 0 }
            };

            SudokuBoard board = new SudokuBoard(vals);
            SudokuBoard copyBoard = new SudokuBoard(board);
            bool completed = false;

            while (!completed)
            {
                completed = copyBoard.Solve();
            }
        }
    }
}
