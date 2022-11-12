using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sudoku_Solver
{
    internal class SolverHelper
    {
        private const int GRID_SIZE = 9;
        private List<string> list = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public bool solveSudoku(ref TextBox[,] textBoxes) {
            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int column = 0; column < GRID_SIZE; column++)
                {
                    if (!list.Contains(textBoxes[row,column].Text))
                    {
                        for (int number = 1; number <= GRID_SIZE; number++)
                        {
                            if (canBePlaced(ref textBoxes, number.ToString(), row, column))
                            {
                                textBoxes[row,column].Text = number.ToString();
                                if (solveSudoku(ref textBoxes))
                                {
                                    return true;
                                }
                                else
                                {
                                    textBoxes[row, column].Text = "";
                                }
                            }

                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool existsInRow(ref TextBox[,] textBoxes, string element, int row)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                if (textBoxes[row, i].Text.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }  
        private bool existsInColumn(ref TextBox[,] textBoxes, string element, int column)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                if (textBoxes[i,column].Text.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }
        private bool existsInSquare(ref TextBox[,] textBoxes, string element, int row, int column)
        {
            int currentSquareRow = row - row % 3;
            int currentSquareColumn = column - column % 3;

            for (int i = currentSquareRow; i < currentSquareRow + 3; i++)
            {
                for (int j = currentSquareColumn; j < currentSquareColumn + 3; j++)
                {
                    if (textBoxes[i,j].Text.Equals(element))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool canBePlaced(ref TextBox[,] textBoxes, string element, int row, int column)
        {
            return !existsInRow(ref textBoxes, element, row) && !existsInColumn(ref textBoxes, element, column) && !existsInSquare(ref textBoxes, element, row, column);
        }

        
    }
}
