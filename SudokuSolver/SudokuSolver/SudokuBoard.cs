using System;
using System.Collections.Generic;

namespace SudokuSolver
{

    public class SudokuBoard
    {
        private int[,] _vals = new int[9, 9];
        public List<int>[,] AllowableVals { get; } = new List<int>[9, 9];

        public SudokuBoard(int[,] vals)
        {
            //faster
            Array.Copy(vals, _vals, 81);

            PopulateAllowableVals();
        }

        public SudokuBoard(SudokuBoard board)
        {
            Array.Copy(board._vals, _vals, 81);
            PopulateAllowableVals();
        }

        public bool Solve()
        {
            int minCount = getMinCount(AllowableVals);
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (AllowableVals[row, col] != null && AllowableVals[row, col].Count == minCount)
                    {
                        //Iterate through all allowable values
                        for (int i = 0; i < AllowableVals[row, col].Count; i++)
                        {
                            //Try each value, if not winnable, break
                            SetValue(row, col, AllowableVals[row, col][i]);
                            if (Solve())
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the smallest count in the list of AllowableVals
        /// </summary>
        /// <returns>Returns an int representing the minimum count of allowable values.</returns>
        public int getMinCount(List<int>[,] AllowableVals)
        {
            int min = 9;

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (AllowableVals[row, col].Count < min)
                    {
                        min = AllowableVals[row, col].Count;
                    }
                }
            }

            return min;
        }

        /// <summary>
        /// Checks the board state for a win
        /// </summary>
        /// <returns>A boolean, true if won, false if lost.</returns>
        public bool checkWin()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (_vals[row, col] == 0)
                    {
                        Console.WriteLine("Still more to go!!!");
                        return false;
                    }
                }
            }
            Console.WriteLine("You won!!!");
            return true;
        }

        private void PopulateAllowableVals()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_vals[i, j] == 0)
                    {
                        AllowableVals[i, j] = ComputeAllowedVals(i, j);
                    }
                    else
                    {
                        AllowableVals[i, j] = null;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the value provided at a given position
        /// </summary>
        internal void SetValue(int row, int col, int v)
        {
            //update _vals
            _vals[row, col] = v;
            //call PopulateAllowableVals()
            PopulateAllowableVals();
        }

        /// <summary>
        /// Compute the allowed values at a given position.
        /// </summary>
        /// <returns>A list of numbers that could go at the current location.</returns>
        private List<int> ComputeAllowedVals(int row, int col)
        {

            List<int> allAllowed = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //check the row
            for (int x = 0; x < 9; x++)
            {
                if (_vals[row, x] != 0)
                {
                    //we found a value in the current row
                    //that means we can't use it again
                    //so now we need to make sure it isn't in the list
                    //of candidates

                    int allowedIndex = allAllowed.FindIndex(v => v == _vals[row, x]);

                    if (allowedIndex != -1)
                    {
                        //we found that the number is still available despite being in the row
                        //that means we need to remove it
                        allAllowed.RemoveAt(allowedIndex);
                    }

                }
            }

            //check the column
            for (int y = 0; y < 9; y++)
            {
                if (_vals[y, col] != 0)
                {
                    int allowedIndex = allAllowed.FindIndex(v => v == _vals[y, col]);
                    if (allowedIndex != -1)
                    {
                        allAllowed.RemoveAt(allowedIndex);
                    }
                }
            }

            //  [0,0]  [0,1] [0,2] | [0,3] [0,4]  [0,5] | [0,6]  [0,7] [0,8] 
            //  [1,0]  [1,1] [1,2] | [1,3] [1,4]  [1,5] | [1,6]  [1,7] [1,8] 
            //  [2,0]  [2,1] [2,2] | [2,3] [2,4]  [2,5] | [2,6]  [2,7] [2,8]
            //---------------------------------------------------------------
            //  [3,0]  [3,1] [3,2] | [3,3] [3,4]  [3,5] | [3,6]  [3,7] [3,8] 
            //  [4,0]  [4,1] [4,2] | [4,3] [4,4]  [4,5] | [4,6]  [4,7] [4,8] 
            //  [5,0]  [5,1] [5,2] | [5,3] [5,4]  [5,5] | [5,6]  [5,7] [5,8] 
            //---------------------------------------------------------------
            //  [6,0]  [6,1] [6,2] | [6,3] [6,4]  [6,5] | [6,6]  [6,7] [6,8] 
            //  [7,0]  [7,1] [7,2] | [7,3] [7,4]  [7,5] | [7,6]  [7,7] [7,8] 
            //  [8,0]  [8,1] [8,2] | [8,3] [8,4]  [8,5] | [8,6]  [8,7] [8,8]

            //say we're at 4,7
            //we want to get to 3,6
            //row = 4
            //col = 7

            //row - row % 3 = 3
            //col - col % 3 = 6


            //compute box upper left
            int upperLeftRow = row - row % 3;
            int upperLeftCol = col - col % 3;

            for (int y = upperLeftRow; y < upperLeftRow + 3; y++)
            {
                for (int x = upperLeftCol; x < upperLeftCol + 3; x++)
                {
                    if (_vals[y, x] != 0)
                    {
                        int allowedIndex = allAllowed.FindIndex(v => v == _vals[y, x]);
                        if (allowedIndex != -1)
                        {
                            allAllowed.RemoveAt(allowedIndex);
                        }
                    }
                }
            }

            return allAllowed;
        }
    }
}