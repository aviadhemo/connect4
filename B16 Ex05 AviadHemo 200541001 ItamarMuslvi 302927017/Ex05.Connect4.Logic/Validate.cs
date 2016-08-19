using System;
using System.Text;

namespace Ex05.Connect4.Logic
{
    public static class Validate
    {
        private const int k_MinRowsCols = 4;
        private const int k_MaxRowsCols = 8;

        public static bool RowsColsValidate(ref int io_RowsCols)
        {
            bool retValue = false;

            if (io_RowsCols >= k_MinRowsCols && io_RowsCols <= k_MaxRowsCols)
            {
                retValue = true;
            }

            return retValue;
        }
    }
}