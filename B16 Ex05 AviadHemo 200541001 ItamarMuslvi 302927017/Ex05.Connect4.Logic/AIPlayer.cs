using System;
using System.Text;

namespace Ex05.Connect4.Logic
{
    public class AIPlayer
    {
        private Random m_Random;
        private Player m_PcPlayer;

        public AIPlayer()
        {
            this.m_PcPlayer = new Player("Computer", ePlayerType.Computer, eColor.Red);
            m_Random = new Random();
        }

        public Player PcPlayer
        {
            get { return this.m_PcPlayer; }
        }

        public int RandomInsert(Player i_AIPlayer, Board i_Board)
        {
            int validColumn;

            validColumn = getRandomColumn(i_Board.NextColumnArray, i_Board);

            return validColumn;
        }

        private int getRandomColumn(int[] i_NextColumnArray, Board i_Board)
        {
            int randValue;
            int maxColumn = i_NextColumnArray.Length;
            bool goodInput = false;

            do
            {
                randValue = m_Random.Next(1, maxColumn + 1);
                goodInput = i_NextColumnArray[randValue - 1] >= 0 ? true : false;
            }while (!goodInput);

            return randValue;
        }
    }
}