using System;
using System.Text;

namespace Ex05.Connect4.Logic
{
    public static class GameRules
    {
        public static bool DiagonalScan(Board i_Board)
        {
            bool fourEquals = false;

            if (leftToRightDiagonalScan(i_Board) == true)
            {
                fourEquals = true;
            }
            else if (rightToLeftDiagonalScan(i_Board) == true)
            {
                fourEquals = true;
            }

            return fourEquals;
        }

        private static bool leftToRightDiagonalScan(Board i_Board)
        {
            int maxRowScan = i_Board.Matrix.GetLength(0);
            int maxColumnScan = i_Board.Matrix.GetLength(1);
            int colorCount = 1;
            int tempRow, tempColumn;
            bool fourEquals = false;

            for (int indexColumn = 0; indexColumn <= maxColumnScan / 2; indexColumn++)
            {
                for (int indexRow = maxRowScan - 1; indexRow >= maxRowScan / 2; indexRow--)
                {
                    tempRow = indexRow;
                    tempColumn = indexColumn;
                    while (tempRow > 0 && tempColumn < maxColumnScan - 1)
                    {
                        if (i_Board.Matrix[tempRow, tempColumn] == i_Board.Matrix[tempRow - 1, tempColumn + 1])
                        {
                            if (i_Board.Matrix[tempRow, tempColumn] != eColor.None && i_Board.Matrix[tempRow - 1, tempColumn + 1] != eColor.None)
                            {
                                colorCount++;
                            }
                            else
                            {
                                colorCount = 1;
                            }

                            if (colorCount == 4)
                            {
                                break;
                            }
                        }
                        else
                        {
                            colorCount = 1;
                        }

                        tempRow--;
                        tempColumn++;
                    }

                    if (colorCount == 4)
                    {
                        fourEquals = true;
                        break;
                    }

                    colorCount = 1;
                }

                if (fourEquals)
                {
                    break;
                }
            }

            return fourEquals;
        }

        private static bool rightToLeftDiagonalScan(Board i_Board)
        {
            int maxRowScan = i_Board.Matrix.GetLength(0);
            int maxColumnScan = i_Board.Matrix.GetLength(1);
            int colorCount = 1;
            int tempRow, tempColumn;
            bool fourEquals = false;

            for (int indexColumn = maxColumnScan; indexColumn >= maxColumnScan / 2; indexColumn--)
            {
                for (int indexRow = maxRowScan; indexRow >= maxRowScan / 2; indexRow--)
                {
                    tempRow = indexRow - 1;
                    tempColumn = indexColumn - 1;
                    while (tempRow > 0 && tempColumn > 0)
                    {
                        if (i_Board.Matrix[tempRow, tempColumn] == i_Board.Matrix[tempRow - 1, tempColumn - 1])
                        {
                            if (i_Board.Matrix[tempRow, tempColumn] != eColor.None && i_Board.Matrix[tempRow - 1, tempColumn - 1] != eColor.None)
                            {
                                colorCount++;
                            }
                            else
                            {
                                colorCount = 1;
                            }

                            if (colorCount == 4)
                            {
                                break;
                            }
                        }
                        else
                        {
                            colorCount = 1;
                        }

                        tempRow--;
                        tempColumn--;
                    }

                    if (colorCount == 4)
                    {
                        fourEquals = true;
                        break;
                    }

                    colorCount = 1;
                }

                if (fourEquals)
                {
                    break;
                }
            }

            return fourEquals;
        }

        public static bool LineScan(Board i_Board)
        {
            int maxRowScan = i_Board.Matrix.GetLength(0) - 1;
            int maxColumnScan = i_Board.Matrix.GetLength(1) - 1;
            int colorCount = 1;
            bool fourEquals = false;

            for (int indexRow = maxRowScan; indexRow > 0; indexRow--)
            {
                for (int indexColumn = 0; indexColumn < maxColumnScan; indexColumn++)
                {
                    if (i_Board.Matrix[indexRow, indexColumn] == i_Board.Matrix[indexRow, indexColumn + 1])
                    {
                        if (i_Board.Matrix[indexRow, indexColumn] != eColor.None && i_Board.Matrix[indexRow, indexColumn + 1] != eColor.None)
                        {
                            colorCount++;
                        }
                        else
                        {
                            colorCount = 1;
                        }

                        if (colorCount == 4)
                        {
                            fourEquals = true;
                            break;
                        }
                    }
                    else
                    {
                        colorCount = 1;
                    }
                }

                if (fourEquals)
                {
                    break;
                }

                colorCount = 1;
            }

            return fourEquals;
        }

        public static bool ColumnScan(Board i_Board)
        {
            int maxRowScan = i_Board.Matrix.GetLength(0) - 1;
            int maxColumnScan = i_Board.Matrix.GetLength(1) - 1;
            int colorCount = 1;
            bool fourEquals = false;

            for (int indexColumn = 0; indexColumn <= maxColumnScan; indexColumn++)
            {
                for (int indexRow = maxRowScan; indexRow > 0; indexRow--)
                {
                    if (i_Board.Matrix[indexRow, indexColumn] == i_Board.Matrix[indexRow - 1, indexColumn])
                    {
                        if (i_Board.Matrix[indexRow, indexColumn] != eColor.None && i_Board.Matrix[indexRow - 1, indexColumn] != eColor.None)
                        {
                            colorCount++;
                        }
                        else
                        {
                            colorCount = 1;
                        }

                        if (colorCount == 4)
                        {
                            fourEquals = true;
                            break;
                        }
                    }
                    else
                    {
                        colorCount = 1;
                    }
                }

                if (fourEquals)
                {
                    break;
                }

                colorCount = 1;
            }

            return fourEquals;
        }
    }
}
