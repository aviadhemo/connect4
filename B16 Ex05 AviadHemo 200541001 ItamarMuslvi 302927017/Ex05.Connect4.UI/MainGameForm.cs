using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.Connect4.Logic;

namespace Ex05.Connect4.UI
{
    public partial class MainGameForm : Form
    {
        private const int k_FirstIndex = 0;
        private const string k_Red = "X";
        private const string k_Blue = "O";
        private readonly Button[] r_ColsButtons;
        private readonly Button[,] r_ButtonsMatrix;
        private readonly Label r_Label1;
        private readonly Label r_Label2;
        private readonly Label r_TurnLabel;
        private GameInitializer m_GameInitializer;
        private string m_WinnerName = string.Empty;

        public MainGameForm(int i_Rows, int i_Cols, string i_FirstPlayerName, string i_SecondPlayerName, bool i_IsPlayer2Checked)
        {
            this.m_GameInitializer = new GameInitializer(i_Rows, i_Cols, i_FirstPlayerName, i_SecondPlayerName, i_IsPlayer2Checked);
            this.r_ButtonsMatrix = new Button[m_GameInitializer.Rows, m_GameInitializer.Cols];
            this.r_ColsButtons = new Button[m_GameInitializer.Cols];
            r_Label1 = new Label();
            r_Label2 = new Label();
            r_TurnLabel = new Label();
            createLineNumberButtons();
            createButtonsTable();
            updateScoresAndName();
            setFormProperties();
            ifAISetChoose();
        }

        private void createLineNumberButtons()
        {
            int top = 15;
            int left = 8;

            for (int i = 0; i < r_ColsButtons.Length; i++)
            {
                r_ColsButtons[i] = new Button();
                r_ColsButtons[i].Location = new Point(left, top);
                left += 40;
                r_ColsButtons[i].Size = new Size(35, 20);
                r_ColsButtons[i].Name = (i + 1).ToString();
                r_ColsButtons[i].Text = (i + 1).ToString();
                r_ColsButtons[i].Click += buttons_Click;
                if (this.m_GameInitializer.Players[1].PlayerType == ePlayerType.Computer)
                {
                    r_ColsButtons[i].Click += autoClick;
                }

                this.Controls.Add(r_ColsButtons[i]);
            }
        }

        private void createButtonsTable()
        {
            int top = r_ColsButtons[0].Top + 30;
            int left = r_ColsButtons[0].Left;

            m_GameInitializer.Board.CellChange += updateItemInMatrix;
            for (int i = 0; i < r_ButtonsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < r_ButtonsMatrix.GetLength(1); j++)
                {
                    r_ButtonsMatrix[i, j] = new Button();
                    r_ButtonsMatrix[i, j].Location = new Point(left, top);
                    r_ButtonsMatrix[i, j].Size = new Size(35, 35);
                    r_ButtonsMatrix[i, j].Text = string.Empty;
                    this.Controls.Add(r_ButtonsMatrix[i, j]);
                    left += 40;
                }

                top += 40;
                left = 8;
            }
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;           
            coinInsertion(int.Parse(button.Name));
            updateTurnLable();
            gameState();
        }

        private void coinInsertion(int i_Col)
        {
            ePlayerType currentPlayer = ePlayerType.None;

            if (isColAvialable(i_Col))
            {
                if (m_GameInitializer.Players[0].MyTurn)
                {
                    m_GameInitializer.Board.InsertCoin(i_Col, m_GameInitializer.Players[0].Color);
                    isColAvialable(i_Col);
                    currentPlayer = m_GameInitializer.Players[0].PlayerType;                  
                }
                else if (m_GameInitializer.Players[1].MyTurn)
                {
                    m_GameInitializer.Board.InsertCoin(i_Col, m_GameInitializer.Players[1].Color);
                    isColAvialable(i_Col);
                    currentPlayer = m_GameInitializer.Players[1].PlayerType;
                }

                GameManager.ChangePlayerTurn(m_GameInitializer.Players, currentPlayer);
            }
        }

        private eColor getColorByTurn()
        {
            eColor color = eColor.None;

            foreach (Player player in m_GameInitializer.Players)
            {
                if (player.MyTurn)
                {
                    color = player.Color;
                    break;
                }
            }

            return color;
        }

        private bool isColAvialable(int i_Col)
        {
            bool isAvailable = true;

            if (m_GameInitializer.Board.IsColumnAvailable(i_Col))
            {
                disbaleButtonByPosition(i_Col - 1);
                isAvailable = false;
            }

            return isAvailable;
        }

        private void updateItemInMatrix(int i_Row, int i_Cols, eColor i_Color)
        {
            switch (i_Color)
            {
                case eColor.Red:
                    changeButtonTextByIndices(i_Row, i_Cols, k_Red);
                    break;
                case eColor.Blue:
                    changeButtonTextByIndices(i_Row, i_Cols, k_Blue);
                    break;
            }
        }

        private void changeButtonTextByIndices(int i_Row, int i_Cols, string i_ButtonText)
        {
            this.r_ButtonsMatrix[i_Row, i_Cols].Text = i_ButtonText;
        }

        private void updateScoresAndName()
        {
            r_Label1.Text = this.m_GameInitializer.Players[k_FirstIndex].Name + " : " + this.m_GameInitializer.Players[k_FirstIndex].NumOfWins.ToString();
            r_Label2.Text = this.m_GameInitializer.Players[k_FirstIndex + 1].Name + " : " + this.m_GameInitializer.Players[k_FirstIndex + 1].NumOfWins.ToString();
        }

        private void disbaleButtonByPosition(int i_Col)
        {
            this.r_ColsButtons[i_Col].Enabled = false;
        }

        private void autoClick(object sender, EventArgs e)
        {
            int aIPlayerChosenCol;

            aIPlayerChosenCol = this.m_GameInitializer.AIPlayer.RandomInsert(m_GameInitializer.Players[1], m_GameInitializer.Board);
            if (this.r_ColsButtons[aIPlayerChosenCol - 1].Enabled)
            {
                this.coinInsertion(aIPlayerChosenCol);
                updateTurnLable();
                gameState();               
            }           
        }

        private string getNameByTurn()
        {
            string name = string.Empty;

            foreach (Player player in this.m_GameInitializer.Players)
            {
                if (player.MyTurn)
                {
                    name = player.Name;
                }
                else
                {
                    m_WinnerName = player.Name;                   
                }
            }

            return name;
        }

        private void gameState()
        {
            eGameState gameState = eGameState.None;
            bool rematch = false;
            bool quit = false;
            string win = "A Win!!";
            string draw = "Tie!!";            

            gameState = GameManager.CheckGameState(m_GameInitializer.Board, m_GameInitializer.Players, quit);
            switch (gameState)
            {
                case eGameState.Win:
                    rematch = messageBoxAndResult(win, m_WinnerName);
                    break;
                case eGameState.Draw:
                    rematch = messageBoxAndResult(draw, draw);
                    break;
            }

            if (gameState == eGameState.Win || gameState == eGameState.Draw)
            {
                updateScoresAndName();
                if (rematch)
                {
                    resetForm();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void ifAISetChoose()
        {
            if (m_GameInitializer.Start == ePlayerType.Computer)
            {
                int aIPlayerChosenCol = this.m_GameInitializer.AIPlayer.RandomInsert(m_GameInitializer.Players[1], m_GameInitializer.Board);

                this.coinInsertion(aIPlayerChosenCol);
                updateTurnLable();
            }
        }
        private void resetForm()
        {
            m_GameInitializer.Board.ResetMatrix();
            foreach (Button button in this.r_ColsButtons)
            {
                button.Enabled = true;
            }

            for (int i = 0; i < this.r_ButtonsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.r_ButtonsMatrix.GetLength(1); j++)
                {
                    this.r_ButtonsMatrix[i, j].Text = string.Empty;
                }
            }
        }
    }
}