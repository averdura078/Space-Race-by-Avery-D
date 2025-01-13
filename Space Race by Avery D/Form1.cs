using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        // List<int> meteorSides = new List<int>();
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




        public Form1()
        {
            InitializeComponent();
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
                e.Graphics.FillEllipse(fireBrush, player1.X + 2, player1.Height, 4, 15) ;
            }

            //player 1
            e.Graphics.FillEllipse(grayBrush, player2);
            e.Graphics.DrawLine(bluePen, player2.X - 3, player2.Y + 3, player2.X + player2.Width / 2 + 3, player2.Y - 10);
            e.Graphics.DrawLine(bluePen, player2.X + player2.Width + 3, player2.Y + 3, player2.X + player2.Width / 2 - 3, player2.Y - 10);
            e.Graphics.DrawLine(bluePen, player2.X, player2.Y, player2.X + player2.Width, player2.Y);
            e.Graphics.FillEllipse(blackBrush, player2.X + 5, player2.Y + 5, 10, 10);
            if (upPressed == true)
            {
                //draw fire
            }

            //meteors
            for (int i = 0; i < meteors.Count; i++)
            {
                e.Graphics.FillEllipse(whiteBrush, meteors[i]);
            }

        }

        private void gameTimer_Tick(object sender, EventArgs e)
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

            //create meteors
            //random percent occurrance
            int randValue = randGen.Next(1, 101);
            //left or right
            int side = randGen.Next(1, 3);
            //random speed
            int randSpeed = randGen.Next(5, 14);
            if (randValue < 20)
            {
                int x = 0;

                if (side == 1)
                {
                    //set meteor to appear on left
                    x = 0;
                    meteorSpeeds.Add(randSpeed);
                }
                else if (side == 2)
                {
                    //set meteor to appear on right
                    x = this.Width;
                    meteorSpeeds.Add(randSpeed * -1);
                }

                int randY = randGen.Next(1, this.Height - 40);
                Rectangle newMeteor = new Rectangle(x, randY, 20, 5);
                meteors.Add(newMeteor);
            }

            //move meteors
            for (int i = 0; i < meteors.Count; i++)
            {
                int x = meteors[i].X + meteorSpeeds[i];
                meteors[i] = new Rectangle(x, meteors[i].Y, meteors[i].Width, meteors[i].Height);
            }

            //check for collision with meteors
            for (int i = 0; i < meteors.Count; i++)
            {
                if (player1.IntersectsWith(meteors[i]))
                {
                    player1.Y = this.Height - player1.Height;
                    //play explosion sound
                }
                if (player2.IntersectsWith(meteors[i]))
                {
                    player2.Y = this.Height - player2.Height;
                    //play explosion sound
                }
            }

            //check if either player reached the other side and add point
            if (player1.Y < 0)
            {
                player1Score+=1;
                player1.Y = this.Height - player1.Height;
            }
            if (player2.Y < 0)
            {
                player2Score+=1;
                player2.Y = this.Height - player2.Height;
            }
            if (player1Score == 3 || player2Score == 3)
            {
                gameTimer.Stop();
            }
            //refresh scores
            player1ScoreLabel.Text = $"{player1Score}";
            player2ScoreLabel.Text = $"{player2Score}";



            Refresh();
        }

        private void startTimer_Tick(object sender, EventArgs e)
        {
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

    }
}
