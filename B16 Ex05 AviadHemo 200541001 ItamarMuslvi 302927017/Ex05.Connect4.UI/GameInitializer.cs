using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.Connect4.Logic;

namespace Ex05.Connect4.UI
{
    public class GameInitializer
    {
        private const int k_Length = 2;
        private const int k_FirstIndex = 0;
        private readonly Player[] r_Players;
        private readonly Board r_Board;
        private int m_Rows;
        private int m_Cols;
        private string m_FirstPlayerName = string.Empty;
        private string m_SecondPlayerName = string.Empty;
        private bool m_IsPlayer2Checked;
        private ePlayerType m_Participant = ePlayerType.None;
        private AIPlayer m_AIPlayer = new AIPlayer();
        private ePlayerType m_StartingPlayer = ePlayerType.None;

        public GameInitializer(int i_Rows, int i_Cols, string i_FirstPlayerName, string i_SecondPlayerName, bool i_IsPlayer2Checked)
        {
            this.r_Players = new Player[k_Length];
            this.m_Rows = i_Rows;
            this.m_Cols = i_Cols;
            this.m_FirstPlayerName = i_FirstPlayerName;
            this.m_SecondPlayerName = i_SecondPlayerName;
            this.m_IsPlayer2Checked = i_IsPlayer2Checked;
            this.m_Participant = chooseParticipant(this.m_IsPlayer2Checked);
            createPlayers(m_Participant);
            this.r_Board = new Board(this.m_Rows, this.m_Cols);
            initBoard();
            setStartingPlayer();
        }

        public int Rows
        {
            get { return this.m_Rows; }
        }

        public int Cols
        {
            get { return this.m_Cols; }
        }

        public Player[] Players
        {
            get
            {
                return this.r_Players;
            }
        }

        public Board Board
        {
            get { return this.r_Board; }
        }

        public AIPlayer AIPlayer
        {
            get { return this.m_AIPlayer; }
        }

        public ePlayerType Start
        {
            get { return m_StartingPlayer; }
            set { m_StartingPlayer = value; }
        }

        private void setStartingPlayer()
        {
            m_StartingPlayer = GameManager.RandomPlayer(r_Players[k_FirstIndex].PlayerType, r_Players[k_FirstIndex + 1].PlayerType);
            GameManager.SetStartingPlayer(this.r_Players, m_StartingPlayer);
        }

        private void initBoard()
        {
            this.r_Board.InitializeMatrix();
        }

        private ePlayerType chooseParticipant(bool i_IsPlayer2Checked)
        {
            ePlayerType player = ePlayerType.None;

            if (i_IsPlayer2Checked)
            {
                player = ePlayerType.Player2;
            }
            else
            {
                player = ePlayerType.Computer;
            }

            return player;
        }

        private void createPlayers(ePlayerType i_Eplayer)
        {
            ePlayerType firstPlayer = ePlayerType.Player1;

            this.r_Players[k_FirstIndex] = initPlayer(firstPlayer);
            this.r_Players[k_FirstIndex + 1] = initPlayer(i_Eplayer);
        }

        private Player initPlayer(ePlayerType i_Eplayer)
        {
            string playerName = string.Empty;
            Player choosePlayer = new Player();

            if (i_Eplayer == ePlayerType.Player1)
            {
                choosePlayer = new Player(m_FirstPlayerName, i_Eplayer, eColor.Blue);
            }
            else if (i_Eplayer == ePlayerType.Player2)
            {
                choosePlayer = new Player(m_SecondPlayerName, i_Eplayer, eColor.Red);
            }
            else if (i_Eplayer == ePlayerType.Computer)
            {
                choosePlayer = m_AIPlayer.PcPlayer;
            }

            return choosePlayer;
        }
    }   
}