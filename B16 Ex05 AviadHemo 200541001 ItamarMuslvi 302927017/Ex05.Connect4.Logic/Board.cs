using System;
using System.Text;

namespace Ex05.Connect4.Logic
{
    public class Board
    {
        private readonly int r_Rows;
        private readonly int r_Cols;
        private int[] m_NextEmptyCell;
        private eColor[,] m_Matrix;

        public event Action<int, int, eColor> CellChange;

        public Board(int i_Row, int i_Cols)
        {
            r_Rows = i_Row;
            r_Cols = i_Cols;
            m_Matrix = new eColor[r_Rows, r_Cols];
            m_NextEmptyCell = new int[r_Cols];
        }

        public void InitializeMatrix()
        {
            for (int indexRows = 0; indexRows < m_Matrix.GetLength(0); indexRows++)
            {
                for (int indexCols = 0; indexCols < m_Matrix.GetLength(1); indexCols++)
                {
                    m_Matrix[indexRows, indexCols] = eColor.None;
                }
            }

            initNextColumnArray();
        }

        public bool IsFullMatrix()
        {
            bool fullMatrix = true;

            for (int indexRows = 0; indexRows < m_Matrix.GetLength(0); indexRows++)
            {
                for (int indexCols = 0; indexCols < m_Matrix.GetLength(1); indexCols++)
                {
                    if (m_Matrix[indexRows, indexCols] == eColor.None)
                    {
                        fullMatrix = false;
                        break;
                    }
                }

                if (fullMatrix == false)
                {
                    break;
                }
            }

            return fullMatrix;
        }

        public bool ColumnInRange(int i_Column)
        {
            bool columnInRange = false;

            columnInRange = (i_Column <= r_Cols && i_Column > 0) ? true : false;

            return columnInRange;
        }

        public bool IsColumnAvailable(int i_Column)
        {
            bool columnUnavailable = true;

            if (Matrix[0, i_Column - 1] == eColor.None)
            {
                columnUnavailable = false;
            }

            return columnUnavailable;
        }

        public void ResetMatrix()
        {
            for (int indexRows = 0; indexRows < m_Matrix.GetLength(0); indexRows++)
            {
                for (int indexCols = 0; indexCols < m_Matrix.GetLength(1); indexCols++)
                {
                    m_Matrix[indexRows, indexCols] = eColor.None;
                }
            }

            initNextColumnArray();
        }

        public void InsertCoin(int i_Column, eColor i_ECoin)
        {
            int emptyRowCell;

            if (ColumnInRange(i_Column))
            {
                if (!IsColumnAvailable(i_Column))
                {
                    emptyRowCell = m_NextEmptyCell[i_Column - 1];
                    m_Matrix[emptyRowCell, i_Column - 1] = i_ECoin;
                    m_NextEmptyCell[i_Column - 1]--;
                    onCellChange(emptyRowCell, i_Column - 1, i_ECoin);
                }
            }
        }

        private void initNextColumnArray()
        {
            for (int i = 0; i < m_NextEmptyCell.Length; i++)
            {
                m_NextEmptyCell[i] = r_Rows - 1;
            }
        }

        public eColor[,] Matrix
        {
            get
            {
                return m_Matrix;
            }
        }

        public int[] NextColumnArray
        {
            get
            {
                return m_NextEmptyCell;
            }
        }

        public int Column
        {
            get
            {
                return r_Cols;
            }
        }

        public int Rows
        {
            get
            {
                return r_Rows;
            }
        }

        private void onCellChange(int i_Row, int i_Col, eColor i_Color)
        {
            if (CellChange != null)
            {
                CellChange.Invoke(i_Row, i_Col, i_Color);
            }
        }
    }
}