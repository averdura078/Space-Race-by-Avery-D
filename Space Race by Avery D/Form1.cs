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
        //meteor positions random number generator
        Random randGen = new Random();
        //meteor colour
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        //score
        int player1Score = 0;
        int player2Score = 0;

        //start
        int countdown = 3;




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
            e.Graphics.FillRectangle(grayBrush, player1);
            e.Graphics.DrawLine(redPen, player1.X - 3, player1.Y + 3, player1.X + player1.Width / 2 + 3, player1.Y - 10);
            e.Graphics.DrawLine(redPen, player1.X + player1.Width + 3, player1.Y + 3, player1.X + player1.Width / 2 - 3, player1.Y - 10);
            if (wPressed == true)
            {
                //draw fire
            }

            //player 1
            e.Graphics.FillRectangle(grayBrush, player2);
            e.Graphics.DrawLine(bluePen, player2.X - 3, player2.Y + 3, player2.X + player2.Width / 2 + 3, player2.Y - 10);
            e.Graphics.DrawLine(bluePen, player2.X + player2.Width + 3, player2.Y + 3, player2.X + player2.Width / 2 - 3, player2.Y - 10);
            if (upPressed == true)
            {
                //draw fire
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
            //move player 1
            if (upPressed == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }
            if (downPressed == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            Refresh();
        }

        private void startTimer_Tick(object sender, EventArgs e)
        {
            startLabel.Text = $"{countdown}";
            countdown--;
            if (countdown == -1)
            {
                startLabel.Text = "GO!";
                startTimer.Stop();
                gameTimer.Start();
            }

            Refresh();
        }
    }
}
