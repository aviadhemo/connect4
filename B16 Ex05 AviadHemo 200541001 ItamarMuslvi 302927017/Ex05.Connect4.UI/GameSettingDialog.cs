using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex05.Connect4.Logic;

namespace Ex05.Connect4.UI
{
    public partial class GameSettingDialog : Form
    {
        private const string k_Player1 = "Player1";
        private const string k_Player2 = "Player2";
        private const string k_ComputerName = "[Computer]";
        private bool m_IsPlayer2Checked = true;

        public int Rows
        {
            get { return Convert.ToInt32(numericUpDownRows.Value); }
        }

        public int Cols
        {
            get { return Convert.ToInt32(numericUpDownCols.Value); }
        }

        public string Player1Name
        {
            get { return textBoxPlayer1.Text; }
        }

        public string Player2Name
        {
            get { return textBoxPlayer2.Text; }
        }

        public bool IsPlayer2Checked
        {
            get { return m_IsPlayer2Checked; }
        }

        public GameSettingDialog()
        {
            InitializeComponent();
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as CheckBox).Checked)
            {
                textBoxPlayer2.Enabled = false;
                m_IsPlayer2Checked = false;
                textBoxPlayer2.Text = k_ComputerName;
            }
            else
            {
                textBoxPlayer2.Enabled = true;
                textBoxPlayer2.Text = string.Empty;
                m_IsPlayer2Checked = true;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (string.IsNullOrEmpty(textBoxPlayer1.Text))
            {
                textBoxPlayer1.Text = k_Player1;
            }

            if (string.IsNullOrEmpty(textBoxPlayer2.Text) && textBoxPlayer2.Enabled)
            {
                textBoxPlayer2.Text = k_Player2;
            }

            this.Close();
        }
    }
}
