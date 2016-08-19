using System;
using System.Text;

namespace Ex05.Connect4.Logic
{
    public class Player
    {
        private string m_Name;
        private int m_NumOfWins;
        private ePlayerType m_EPlayerType;
        private eColor m_Ecolor;
        private bool m_MyTurn = false;

        public Player()
        {
            m_Name = string.Empty;
            m_EPlayerType = ePlayerType.None;
            m_Ecolor = eColor.None;
            m_NumOfWins = 0;
        }

        public Player(string i_Name, ePlayerType i_EPlayerType, eColor i_Ecolor)
        {
            m_Name = i_Name;
            m_EPlayerType = i_EPlayerType;
            m_Ecolor = i_Ecolor;
            m_NumOfWins = 0;
        }

        public eColor Color
        {
            get
            {
                return m_Ecolor;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        public int NumOfWins
        {
            get
            {
                return m_NumOfWins;
            }

            set
            {
                m_NumOfWins = value;
            }
        }

        public ePlayerType PlayerType
        {
            get
            {
                return m_EPlayerType;
            }
        }

        public bool MyTurn
        {
            get
            {
                return m_MyTurn;
            }

            set
            {
                m_MyTurn = value;
            }
        }
    }
}
