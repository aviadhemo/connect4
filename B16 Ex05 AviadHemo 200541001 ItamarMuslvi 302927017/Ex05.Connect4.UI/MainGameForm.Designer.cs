using System.Windows.Forms;
using System.Drawing;
using System;

namespace Ex05.Connect4.UI
{
    partial class MainGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "4 In A Row!!";
        }

        private bool messageBoxAndResult(string i_GameStateTitle, string i_PlayerName)
        {
            bool yesOrNo = false;
            string caption = Environment.NewLine + "Another Round?";

            DialogResult result = MessageBox.Show(i_PlayerName + caption, i_GameStateTitle, MessageBoxButtons.YesNo);

            switch (result)
            {
                case DialogResult.Yes:
                    yesOrNo = true;
                    break;
                case DialogResult.No:
                    yesOrNo = false;
                    break;
            }

            return yesOrNo;
        }

        private void setFormProperties()
        {
            int height = r_ButtonsMatrix[m_GameInitializer.Rows - 1, m_GameInitializer.Cols - 1].Bottom + 105;
            int width = r_ColsButtons[r_ColsButtons.Length - 1].Right + 26;
            int midle = m_GameInitializer.Cols / 2;

            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(width, height);
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            r_Label1.Location = new Point(r_ButtonsMatrix[m_GameInitializer.Rows - 1, 0].Location.X, r_ButtonsMatrix[m_GameInitializer.Rows - 1, 0].Location.Y + 45);
            r_Label2.Location = new Point(r_ButtonsMatrix[m_GameInitializer.Rows - 1, midle].Left, r_Label1.Top);
            r_Label1.AutoSize = true;
            r_Label2.AutoSize = true;
            r_TurnLabel.Location = new Point(r_Label1.Location.X, r_Label1.Location.Y + r_Label1.Height);
            this.Controls.Add(r_Label1);
            this.Controls.Add(r_Label2);
            this.Controls.Add(r_TurnLabel);
            updateTurnLable();
        }

        private void updateTurnLable()
        {
            r_TurnLabel.Text = getNameByTurn() + " Turn";
        }
        #endregion
    }
}