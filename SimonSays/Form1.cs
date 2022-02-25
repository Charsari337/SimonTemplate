using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        //TODO: create a List to store the pattern. Must be accessable on other screens
        public static List<int> pattern = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: Launch MenuScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MenuScreen ms = new MenuScreen();

            ms.Location = new Point((f.ClientSize.Width - ms.Width) / 2, (f.ClientSize.Height - ms.Height) / 2);

            f.Controls.Add(ms);
            ms.Focus();

            

        }
    }
}
