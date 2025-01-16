using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

//Space Race Game
//Avery Durand
//ISS3U
//Mr. T

namespace Space_Race_by_Avery_D
{
    public partial class Form1 : Form
    {
        //both players
        int playerSpeed = 8;
        SolidBrush grayBrush = new SolidBrush(Color.LightGray);
        Pen redPen = new Pen(Color.Red, 6);
        Pen bluePen = new Pen(Color.Blue, 6);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush fireBrush = new SolidBrush(Color.Orange);

        //player 1 (left side)
        Rectangle player1 = new Rectangle(90, 300, 20, 25);
        //player 1 keys
        bool wPressed = false;
        bool sPressed = false;

        //player 2 (right side)
        Rectangle player2 = new Rectangle(330, 300, 20, 25);
        //player 2 keys
        bool upPressed = false;
        bool downPressed = false;

        //meteors
        List<Rectangle> meteors = new List<Rectangle>();
        List<int> meteorSpeeds = new List<int>();
        //meteor positions random number generator
        Random randGen = new Random();
        //meteor colour
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        //score
        int player1Score = 0;
        int player2Score = 0;

        //start
        int countdown = 3;
        int go = 5;

        //sounds
        //explosion sound player
        SoundPlayer collision = new SoundPlayer(Properties.Resources.explode);
        //start sound player
        SoundPlayer start = new SoundPlayer(Properties.Resources.three);
        //win sound player
        SoundPlayer win = new SoundPlayer(Properties.Resources.fanfare);
        //point sound player
        SoundPlayer point = new SoundPlayer(Properties.Resources.beep);
        //lose sound player
        SoundPlayer lose = new SoundPlayer(Properties.Resources.trombone);

        //time bar
        Pen whitePen = new Pen(Color.White, 6);
        int timePosition = 0;
        int probability = 0;

        public Form1()
        {
            InitializeComponent();
            start.Play();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //player 1
            e.Graphics.FillEllipse(grayBrush, player1);
            e.Graphics.DrawLine(redPen, player1.X - 3, player1.Y + 3, player1.X + player1.Width / 2 + 3, player1.Y - 10);
            e.Graphics.DrawLine(redPen, player1.X + player1.Width + 3, player1.Y + 3, player1.X + player1.Width / 2 - 3, player1.Y - 10);
            e.Graphics.DrawLine(redPen, player1.X, player1.Y, player1.X + player1.Width, player1.Y);
            e.Graphics.FillEllipse(blackBrush, player1.X + 5, player1.Y + 5, 10, 10);
            if (wPressed == true)
            {
                e.Graphics.FillEllipse(fireBrush, player1.X + 5, player1.Y + player1.Height, 10, 15);
            }

            //player 2
            e.Graphics.FillEllipse(grayBrush, player2);
            e.Graphics.DrawLine(bluePen, player2.X - 3, player2.Y + 3, player2.X + player2.Width / 2 + 3, player2.Y - 10);
            e.Graphics.DrawLine(bluePen, player2.X + player2.Width + 3, player2.Y + 3, player2.X + player2.Width / 2 - 3, player2.Y - 10);
            e.Graphics.DrawLine(bluePen, player2.X, player2.Y, player2.X + player2.Width, player2.Y);
            e.Graphics.FillEllipse(blackBrush, player2.X + 5, player2.Y + 5, 10, 10);
            if (upPressed == true)
            {
                e.Graphics.FillEllipse(fireBrush, player2.X + 5, player2.Y + player2.Height, 10, 15);
            }

            //meteors
            for (int i = 0; i < meteors.Count; i++)
            {
                e.Graphics.FillEllipse(whiteBrush, meteors[i]);
                if (meteorSpeeds[i] < 0)
                {
                    Rectangle nottail = new Rectangle(meteors[i].X - 1, meteors[i].Y - 1, 9, 9);
                    e.Graphics.FillEllipse(fireBrush, nottail);
                }
                if (meteorSpeeds[i] > 0)
                {
                    Rectangle nottail = new Rectangle(meteors[i].X + meteors[i].Width - 4, meteors[i].Y - meteors[i].Height + 2, 9, 9);
                    e.Graphics.FillEllipse(fireBrush, nottail);
                }
            }

            //time bar
            e.Graphics.DrawLine(whitePen, 232, timePosition, 232, 400);

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            MovePlayers();
            CreateMeteors();
            MoveMeteors();
            RemoveMeteors();
            CheckForCollision();
            CheckForPoint();
            CheckForWin();
            MoveTimeBar();
            Refresh();
        }

        private void startTimer_Tick(object sender, EventArgs e)
        {
            startLabel.Visible = true;
            startLabel.Text = $"{countdown}";
            countdown--;
            go--;
            if (countdown == -1)
            {
                startLabel.Text = "GO!";
                gameTimer.Start();
            }
            if (go == 0)
            {
                startLabel.Visible = false;
                startTimer.Stop();
            }

            Refresh();
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            start.Play();

            //reset and start countdown
            countdown = 3;
            go = 5;
            startTimer.Start();

            //reset scores
            player1Score = 0;
            player2Score = 0;

            //reset meteors (get rid of them)
            meteors.Clear();
            meteorSpeeds.Clear();

            //unpress keys
            wPressed = false;
            sPressed = false;
            upPressed = false;
            downPressed = false;

            //reset positions to bottom
            player1.Y = this.Height - player1.Height;
            player2.Y = this.Height - player2.Height;

            //hide play again until next time
            playAgainButton.Enabled = false;
            playAgainButton.Visible = false;
            winLabel.Visible = false;

            //reset time position
            timePosition = 0;
        }

        public void MovePlayers()
        {
            //move player 1
            if (wPressed == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }
            if (sPressed == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }
            //move player 2
            if (upPressed == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }
            if (downPressed == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }
        }

        public void CreateMeteors()
        {
            //create meteors
            //random percent occurrance
            int randValue = randGen.Next(1, 101);
            //left or right
            int side = randGen.Next(1, 3);
            //random speed
            int randSpeed = randGen.Next(5, 14);
            if (randValue < 22)
            {
                int x = 0;

                if (side == 1)
                {
                    //set meteor to appear on left
                    x = 0;
                    //set meteor speed
                    meteorSpeeds.Add(randSpeed);
                }
                else if (side == 2)
                {
                    //set meteor to appear on right
                    x = this.Width;
                    //set meteor speed
                    meteorSpeeds.Add(randSpeed * -1);
                }

                int randY = randGen.Next(1, this.Height - 40);
                int randsizeX = randGen.Next(15, 40);
                Rectangle newMeteor = new Rectangle(x, randY, randsizeX, 5);
                meteors.Add(newMeteor);
            }
        }

        public void MoveMeteors()
        {
            //move meteors
            for (int i = 0; i < meteors.Count; i++)
            {
                int x = meteors[i].X + meteorSpeeds[i];
                meteors[i] = new Rectangle(x, meteors[i].Y, meteors[i].Width, meteors[i].Height);
            }
        }

        public void CheckForCollision()
        {
            //check for collision with meteors
            for (int i = 0; i < meteors.Count; i++)
            {
                if (player1.IntersectsWith(meteors[i]))
                {
                    player1.Y = this.Height - player1.Height;
                    //collision.Play();
                }
                if (player2.IntersectsWith(meteors[i]))
                {
                    player2.Y = this.Height - player2.Height;
                    //collision.Play();
                }
            }

        }

        public void CheckForPoint()
        {
            //check if either player reached the other side and add point
            if (player1.Y < 0)
            {
                point.Play();
                player1Score += 1;
                player1.Y = this.Height - player1.Height;
            }
            if (player2.Y < 0)
            {
                point.Play();
                player2Score += 1;
                player2.Y = this.Height - player2.Height;
            }
        }

        public void CheckForWin()
        {
            if (player1Score == 3)
            {
                gameTimer.Stop();
                win.Play();
                winLabel.Text = $"RED ROCKET WINS {player1Score} to {player2Score}";
                winLabel.Visible = true;
                playAgainButton.Enabled = true;
                playAgainButton.Visible = true;
            }
            if (player2Score == 3)
            {
                gameTimer.Stop();
                win.Play();
                winLabel.Text = $"BLUE ROCKET WINS {player2Score} to {player1Score}";
                winLabel.Visible = true;
                playAgainButton.Enabled = true;
                playAgainButton.Visible = true;
            }
            //refresh scores
            player1ScoreLabel.Text = $"{player1Score}";
            player2ScoreLabel.Text = $"{player2Score}";
        }

        public void MoveTimeBar()
        {
            //move time bar
            probability++;
            if (probability % 2 == 0)
            {
                timePosition++;
                if (timePosition == 325)
                {
                    gameTimer.Stop();
                    lose.Play();
                    winLabel.Text = $"No one wins.";
                    winLabel.Visible = true;
                    playAgainButton.Enabled = true;
                    playAgainButton.Visible = true;
                }
            }
        }

        public void RemoveMeteors()
        {
            for (int i = 0; i < meteors.Count; i++)
            {
                if (meteors[i].X < 0 || meteors[i].X > this.Width)
                {
                    meteors.RemoveAt(i);
                    meteorSpeeds.RemoveAt(i);
                }
            }
        }

    }
}
