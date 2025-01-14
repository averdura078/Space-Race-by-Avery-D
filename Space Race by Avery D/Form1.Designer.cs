namespace Space_Race_by_Avery_D
{
    partial class Form1
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.player1ScoreLabel = new System.Windows.Forms.Label();
            this.player2ScoreLabel = new System.Windows.Forms.Label();
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            this.startLabel = new System.Windows.Forms.Label();
            this.playAgainButton = new System.Windows.Forms.Button();
            this.winLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // player1ScoreLabel
            // 
            this.player1ScoreLabel.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.player1ScoreLabel.Location = new System.Drawing.Point(0, 0);
            this.player1ScoreLabel.Name = "player1ScoreLabel";
            this.player1ScoreLabel.Size = new System.Drawing.Size(63, 45);
            this.player1ScoreLabel.TabIndex = 0;
            this.player1ScoreLabel.Text = "0";
            // 
            // player2ScoreLabel
            // 
            this.player2ScoreLabel.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.player2ScoreLabel.Location = new System.Drawing.Point(537, 0);
            this.player2ScoreLabel.Name = "player2ScoreLabel";
            this.player2ScoreLabel.Size = new System.Drawing.Size(63, 45);
            this.player2ScoreLabel.TabIndex = 1;
            this.player2ScoreLabel.Text = "0";
            this.player2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // startTimer
            // 
            this.startTimer.Enabled = true;
            this.startTimer.Interval = 1000;
            this.startTimer.Tick += new System.EventHandler(this.startTimer_Tick);
            // 
            // startLabel
            // 
            this.startLabel.BackColor = System.Drawing.Color.White;
            this.startLabel.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.Color.Black;
            this.startLabel.Location = new System.Drawing.Point(261, 177);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(95, 45);
            this.startLabel.TabIndex = 2;
            this.startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playAgainButton
            // 
            this.playAgainButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playAgainButton.Enabled = false;
            this.playAgainButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.playAgainButton.FlatAppearance.BorderSize = 2;
            this.playAgainButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.playAgainButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.playAgainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playAgainButton.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAgainButton.ForeColor = System.Drawing.Color.White;
            this.playAgainButton.Location = new System.Drawing.Point(154, 238);
            this.playAgainButton.Name = "playAgainButton";
            this.playAgainButton.Size = new System.Drawing.Size(307, 57);
            this.playAgainButton.TabIndex = 3;
            this.playAgainButton.Text = "Play Again";
            this.playAgainButton.UseVisualStyleBackColor = true;
            this.playAgainButton.Visible = false;
            this.playAgainButton.Click += new System.EventHandler(this.playAgainButton_Click);
            // 
            // winLabel
            // 
            this.winLabel.BackColor = System.Drawing.Color.Black;
            this.winLabel.Font = new System.Drawing.Font("Stencil", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.ForeColor = System.Drawing.Color.White;
            this.winLabel.Location = new System.Drawing.Point(8, 177);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(580, 45);
            this.winLabel.TabIndex = 4;
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.winLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Space_Race_by_Avery_D.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.playAgainButton);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.player2ScoreLabel);
            this.Controls.Add(this.player1ScoreLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label player1ScoreLabel;
        private System.Windows.Forms.Label player2ScoreLabel;
        private System.Windows.Forms.Timer startTimer;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Button playAgainButton;
        private System.Windows.Forms.Label winLabel;
    }
}

