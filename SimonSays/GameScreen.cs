using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //TODO: create guess variable to track what part of the pattern the user is at
        Random rand = new Random();

        int guessIndex;

        List<int> playerGuess = new List<int>();

        //Buttons
        Button[] buttons = new Button[4];

        List<Color> baseColors = new List<Color>(new Color[] { Color.PaleGoldenrod, Color.Firebrick, Color.Gold, Color.LightCoral });
        List<Color> highlightColors = new List<Color>(new Color[] { Color.GreenYellow, Color.Red, Color.Orange, Color.DodgerBlue });

         List<SoundPlayer> gameSounds = new List<SoundPlayer>(new SoundPlayer[] {new SoundPlayer(Properties.Resources.Glep_Sound),
             new SoundPlayer(Properties.Resources.Alan_Sound), new SoundPlayer(Properties.Resources.Charlie_sound),
                new SoundPlayer(Properties.Resources.Pim_Sound)});
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //TODO: clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            Form1.pattern.Clear();

            //add buttons to list
            buttons[0] = greenButton;
            buttons[1] = redButton;
            buttons[2] = yellowButton;
            buttons[3] = blueButton;

            Refresh();
            Thread.Sleep(500);

            ComputerTurn();
        }

        private void ComputerTurn()
        {
            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list
            //Form1.pattern.Add(rand.Next(0, 4));
            Form1.pattern.Add(rand.Next(0, 4));

            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.pattern.Count; i++)
            {
                buttons[Form1.pattern[i]].BackColor = highlightColors[Form1.pattern[i]];
                buttons[Form1.pattern[i]].Refresh();
                Thread.Sleep(1000);
                buttons[Form1.pattern[i]].BackColor = baseColors[Form1.pattern[i]];
                buttons[Form1.pattern[i]].Refresh();
                Thread.Sleep(1000);
            }
            //TODO: set guess index value back to 0
            guessIndex = 0;

        }

        public void GameOver()
        {
            //TODO: Play a game over sound


            //TODO: close this screen and open the GameOverScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameOverScreen go = new GameOverScreen();

            go.Location = new Point((f.ClientSize.Width - go.Width) / 2, (f.ClientSize.Height - go.Height) / 2);

            f.Controls.Add(go);
            go.Focus();
        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            //TODO: is the value at current guess index [guess] equal to a green. If so:
            // light up button, play sound, and pause
            if (Form1.pattern[guessIndex] == 0)
            {
                greenButton.BackColor = highlightColors[0];
                greenButton.Refresh();
                Thread.Sleep(1000);
                greenButton.BackColor = baseColors[0];
                greenButton.Refresh();
                Thread.Sleep(1000);

                guessIndex++;
                ComputerTurn();
            }
            else
            {
                GameOver();
            }
            // set button colour back to original
            // add one to the guess index
            // check to see if we are at the end of the pattern. If so:
            // call ComputerTurn() method
            // else call GameOver method
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[guessIndex] == 1)
            {
                redButton.BackColor = highlightColors[1];
                redButton.Refresh();
                Thread.Sleep(1000);
                redButton.BackColor = baseColors[1];
                redButton.Refresh();
                Thread.Sleep(1000);

                guessIndex++;
                ComputerTurn();
            }
            else
            {
                GameOver();
            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[guessIndex] == 2)
            {
                yellowButton.BackColor = highlightColors[2];
                yellowButton.Refresh();
                Thread.Sleep(1000);
                yellowButton.BackColor = baseColors[2];
                yellowButton.Refresh();
                Thread.Sleep(1000);

                guessIndex++;
                ComputerTurn();
            }
            else
            {
                GameOver();
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[guessIndex] == 3)
            {
                blueButton.BackColor = highlightColors[3];
                blueButton.Refresh();
                Thread.Sleep(1000);
                blueButton.BackColor = baseColors[3];
                blueButton.Refresh();
                Thread.Sleep(1000);

                guessIndex++;
                ComputerTurn();
            }
            else
            {
                GameOver();
            }
        }
    }
}
