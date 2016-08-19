using System.Windows.Forms;

namespace Ex05.Connect4.UI
{
    public class Program
    {
        public static void Main()
        {
            StartGame();
        }

        public static void StartGame()
        {
            GameSettingDialog settingDialog = new GameSettingDialog();

            settingDialog.ShowDialog();
            if (settingDialog.DialogResult == DialogResult.OK)
            {
                MainGameForm mainGameForm = new MainGameForm(settingDialog.Rows, settingDialog.Cols, settingDialog.Player1Name, settingDialog.Player2Name, settingDialog.IsPlayer2Checked);
                mainGameForm.ShowDialog();
                //runGame(gameOperation);
            }
        }
    }
}
