using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex05.Connect4.Logic;

namespace Ex05.Connect4.UI
{
    public class GameOperation
    {
        private GameInitializer m_GameInitializer;
        private MainGameForm m_MainGameForm;

        public GameOperation(GameInitializer i_GameInitializer)
        {
            this.m_GameInitializer = i_GameInitializer;
            //this.m_MainGameForm = new MainGameForm(m_GameInitializer.Rows, m_GameInitializer.Cols);
        }

        private void runGame()
        {
            eGameState gameState = eGameState.None;
            bool isQuit = false;

            while (gameState == eGameState.None || gameState == eGameState.Rematch)
            {
               
                gameState = GameManager.CheckGameState(m_GameInitializer.Board, m_GameInitializer.Players, isQuit);
                switch (gameState)
                {
                    case eGameState.Win:
                       // gameState = GameActions.Rematch(m_GameInitializer.Board, m_GameInitializer.Players);
                        break;
                    case eGameState.Draw:
                        //gameState = GameActions.Rematch(m_GameInitializer.Board, m_GameInitializer.Players);
                        break;
                    case eGameState.Quit:
                        //gameState = GameActions.Rematch(m_GameInitializer.Board, m_GameInitializer.Players);
                        break;
                }
            }
        }





    }
}

