using System;
using System.Text;

namespace Ex05.Connect4.Logic
{
    public static class GameManager
    {
        public static ePlayerType RandomPlayer(params ePlayerType[] i_PlayersList)
        {
            int maxRange = 10;
            int randomIndex;
            ePlayerType ePlayer;
            Random random = new Random();

            randomIndex = random.Next(0, maxRange);
            randomIndex = (randomIndex % 2 == 0) ? 0 : 1;
            ePlayer = i_PlayersList[randomIndex];

            return ePlayer;
        }

        public static void SetStartingPlayer(Player[] i_PlayersInGame, ePlayerType i_EPlayerType)
        {
            for (int i = 0; i < i_PlayersInGame.Length; i++)
            {
                if (i_PlayersInGame[i].PlayerType == i_EPlayerType)
                {
                    i_PlayersInGame[i].MyTurn = true;
                }
            }
        }

        public static void ChangePlayerTurn(Player[] i_PlayersInGame, ePlayerType i_EStartingPlayer)
        {
            if (i_PlayersInGame[0].PlayerType == i_EStartingPlayer)
            {
                i_PlayersInGame[0].MyTurn = false;
                i_PlayersInGame[1].MyTurn = true;
            }
            else if (i_PlayersInGame[1].PlayerType == i_EStartingPlayer)
            {
                i_PlayersInGame[1].MyTurn = false;
                i_PlayersInGame[0].MyTurn = true;
            }
        }

        public static void RestartGame(Board i_Board, params ePlayerType[] i_PlayersList)
        {
            i_Board.ResetMatrix();
            RandomPlayer(i_PlayersList);
        }

        public static bool DrawMatch(Board io_Board)
        {
            bool isDraw = false;

            if (io_Board.IsFullMatrix())
            {
                isDraw = true;
            }

            return isDraw;
        }

        public static bool WinGame(Board i_Board)
        {
            bool isWin = false;

            if (GameRules.ColumnScan(i_Board))
            {
                isWin = true;
            }
            else if (GameRules.LineScan(i_Board))
            {
                isWin = true;
            }
            else if (GameRules.DiagonalScan(i_Board))
            {
                isWin = true;
            }

            return isWin;
        }

        private static void incrementWin(Player[] io_Players)
        {
            for (int i = 0; i < io_Players.Length; i++)
            {
                if (!io_Players[i].MyTurn)
                {
                    io_Players[i].NumOfWins++;
                }
            }
        }

        public static Player NowTurn(Player[] i_Players)
        {
            Player currentPlayer = new Player();

            for (int i = 0; i < i_Players.Length; i++)
            {
                if (i_Players[i].MyTurn)
                {
                    currentPlayer = i_Players[i];
                }
            }

            return currentPlayer;
        }

        public static eGameState CheckGameState(Board i_Board, Player[] i_Players, bool i_Quit)
        {
            bool win = false;
            bool draw = false;
            eGameState gameState = eGameState.None;
            Player currentPlayer = new Player();

            currentPlayer = NowTurn(i_Players);
            if (!i_Quit)
            {
                win = WinGame(i_Board);
                draw = DrawMatch(i_Board);
                if (win)
                {
                    incrementWin(i_Players);
                    gameState = eGameState.Win;
                }
                else if (draw)
                {
                    gameState = eGameState.Draw;
                }
            }
            else
            {
                gameState = eGameState.Quit;
            }

            return gameState;
        }
    }
}