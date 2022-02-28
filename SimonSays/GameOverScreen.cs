using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            //TODO: show the length of the pattern
            int patterLength = Form1.pattern.Count - 1;
            patternLabel.Text = $"Your Pattern Length was: {patterLength} ";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //TODO: close this screen and open the MenuScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MenuScreen ms = new MenuScreen();

            ms.Location = new Point((f.ClientSize.Width - ms.Width) / 2, (f.ClientSize.Height - ms.Height) / 2);

            f.Controls.Add(ms);
            ms.Focus();
        }
    }
}
