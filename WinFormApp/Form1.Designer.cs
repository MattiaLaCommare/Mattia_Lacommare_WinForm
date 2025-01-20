namespace WinFormApp
{
    partial class Gioco
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            player = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            lblScore = new Label();
            lblhighScore = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox8 = new PictureBox();
            lblDashCooldown = new Label();
            lblGameOver1 = new Label();
            lblGameOver2 = new Label();
            lblSpeedLvl = new Label();
            lblPowerupMiniTimer = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.platform_tilesblue1;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(787, 50);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.platform_tilesblue;
            pictureBox2.Location = new Point(0, 402);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(787, 80);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // player
            // 
            player.BackColor = Color.Transparent;
            player.Image = Properties.Resources.run_up0;
            player.Location = new Point(237, 36);
            player.Name = "player";
            player.Size = new Size(66, 80);
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            player.TabIndex = 2;
            player.TabStop = false;
            player.Click += player_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources.Rocks2;
            pictureBox3.Location = new Point(570, 301);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(147, 114);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            pictureBox3.Tag = "obstacle";
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = Properties.Resources.Stop_sign_updise;
            pictureBox4.Location = new Point(393, 45);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(53, 123);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            pictureBox4.Tag = "obstacle";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("AniMe Matrix - MB_EN", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScore.ForeColor = SystemColors.Control;
            lblScore.Location = new Point(12, 412);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(155, 29);
            lblScore.TabIndex = 5;
            lblScore.Text = "Score: 0";
            // 
            // lblhighScore
            // 
            lblhighScore.AutoSize = true;
            lblhighScore.BackColor = Color.Transparent;
            lblhighScore.Font = new Font("AniMe Matrix - MB_EN", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblhighScore.ForeColor = SystemColors.Control;
            lblhighScore.Location = new Point(12, 445);
            lblhighScore.Name = "lblhighScore";
            lblhighScore.Size = new Size(232, 29);
            lblhighScore.TabIndex = 6;
            lblhighScore.Text = "High Score: 0";
            lblhighScore.Click += lblhighScore_Click;
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Interval = 20;
            gameTimer.Tick += GameTimerEvent;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = Properties.Resources.Crate;
            pictureBox5.Location = new Point(577, 45);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(76, 71);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 7;
            pictureBox5.TabStop = false;
            pictureBox5.Tag = "obstacle";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = Properties.Resources.Stop_sign;
            pictureBox6.Location = new Point(436, 284);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(52, 121);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 8;
            pictureBox6.TabStop = false;
            pictureBox6.Tag = "obstacle";
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Image = Properties.Resources.ShieldPwrp;
            pictureBox7.Location = new Point(340, 197);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(55, 47);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 9;
            pictureBox7.TabStop = false;
            pictureBox7.Tag = "Shield";
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.Transparent;
            pictureBox8.Image = Properties.Resources.Crate;
            pictureBox8.Location = new Point(545, 45);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(35, 35);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 10;
            pictureBox8.TabStop = false;
            pictureBox8.Tag = "obstacle";
            // 
            // lblDashCooldown
            // 
            lblDashCooldown.AutoSize = true;
            lblDashCooldown.BackColor = Color.Transparent;
            lblDashCooldown.FlatStyle = FlatStyle.Popup;
            lblDashCooldown.Font = new Font("AniMe Matrix - MB_EN", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDashCooldown.ForeColor = Color.Transparent;
            lblDashCooldown.Location = new Point(497, 412);
            lblDashCooldown.Name = "lblDashCooldown";
            lblDashCooldown.Size = new Size(230, 29);
            lblDashCooldown.TabIndex = 11;
            lblDashCooldown.Text = "Dash: Ready!";
            lblDashCooldown.Click += CoolDown_Click;
            // 
            // lblGameOver1
            // 
            lblGameOver1.BackColor = Color.Black;
            lblGameOver1.Font = new Font("AniMe Matrix - MB_EN", 47.9999924F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGameOver1.ForeColor = Color.Lime;
            lblGameOver1.Location = new Point(-9, 0);
            lblGameOver1.Name = "lblGameOver1";
            lblGameOver1.Size = new Size(814, 482);
            lblGameOver1.TabIndex = 12;
            lblGameOver1.Text = "Gravity Runner";
            lblGameOver1.TextAlign = ContentAlignment.MiddleCenter;
            lblGameOver1.Click += lblGameOver1_Click;
            // 
            // lblGameOver2
            // 
            lblGameOver2.BackColor = Color.Black;
            lblGameOver2.Font = new Font("AniMe Matrix - MB_EN", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblGameOver2.ForeColor = SystemColors.AppWorkspace;
            lblGameOver2.Location = new Point(228, 284);
            lblGameOver2.Name = "lblGameOver2";
            lblGameOver2.Size = new Size(366, 34);
            lblGameOver2.TabIndex = 13;
            lblGameOver2.Text = "Press enter to restart";
            // 
            // lblSpeedLvl
            // 
            lblSpeedLvl.AutoSize = true;
            lblSpeedLvl.BackColor = Color.Transparent;
            lblSpeedLvl.Font = new Font("AniMe Matrix - MB_EN", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSpeedLvl.ForeColor = SystemColors.Control;
            lblSpeedLvl.Location = new Point(12, 9);
            lblSpeedLvl.Name = "lblSpeedLvl";
            lblSpeedLvl.Size = new Size(269, 29);
            lblSpeedLvl.TabIndex = 14;
            lblSpeedLvl.Text = "Speed Level: 10";
            lblSpeedLvl.Click += lblSpeedLvl_Click;
            // 
            // lblPowerupMiniTimer
            // 
            lblPowerupMiniTimer.AutoSize = true;
            lblPowerupMiniTimer.BackColor = Color.Transparent;
            lblPowerupMiniTimer.FlatStyle = FlatStyle.Popup;
            lblPowerupMiniTimer.Font = new Font("AniMe Matrix - MB_EN", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPowerupMiniTimer.ForeColor = Color.SpringGreen;
            lblPowerupMiniTimer.Location = new Point(480, 445);
            lblPowerupMiniTimer.Name = "lblPowerupMiniTimer";
            lblPowerupMiniTimer.Size = new Size(276, 29);
            lblPowerupMiniTimer.TabIndex = 15;
            lblPowerupMiniTimer.Text = "Powerup: none";
            // 
            // Gioco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_still;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(788, 483);
            Controls.Add(lblGameOver2);
            Controls.Add(lblGameOver1);
            Controls.Add(lblPowerupMiniTimer);
            Controls.Add(lblSpeedLvl);
            Controls.Add(pictureBox7);
            Controls.Add(lblDashCooldown);
            Controls.Add(lblhighScore);
            Controls.Add(lblScore);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox8);
            Controls.Add(pictureBox3);
            Controls.Add(player);
            DoubleBuffered = true;
            MaximizeBox = false;
            Name = "Gioco";
            Text = "Gravity RUn";
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox player;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label lblScore;
        private Label lblhighScore;
        private System.Windows.Forms.Timer gameTimer;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private Label lblDashCooldown;
        private Label lblGameOver1;
        private Label lblGameOver2;
        private Label lblSpeedLvl;
        private Label lblPowerupMiniTimer;
    }
}
