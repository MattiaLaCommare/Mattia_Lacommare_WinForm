using System.Media;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class Gioco : Form
    {
        //variabili globali, tutte le funzioni possono accederci
        int gravity;  //gravità del personaggio
        int gravityValue; //valore della gravità, cadi più veloce o più lento
        int obstacleSpeed; //la velocità con cui ti arrivano gli ostacoli addosso
        int score = 0; //punteggio
        int highScore = 0; //punteggio massimo, si resetta quando riapri il gioco
        bool gameOver = false; //nel caso sia true il gioco si ferma
        bool powerup = false; //easter egg, se trovi un piccione ti rederà immortale per 10 secondi
        bool dash = false; //se è true farai uno scatto in avanti rimanendo fermo in aria per un attimo, ideale per saltare ostacoli che bloccano
        bool onTopPlatform = false; //quando sei sulla piattaforma in alto
        bool onBottomPlatform = false; //quando sei sulla piattaforma in basso
        bool specialvl = false;
        Random random = new Random(); 
        SoundPlayer land = new SoundPlayer(@"audio\Land.wav"); //suono atterragio
        SoundPlayer jump = new SoundPlayer(@"audio\Jump.wav"); //suono salto
        SoundPlayer start = new SoundPlayer(@"audio\Speedup.wav"); //suono di quando si inizia, rinominato male perchè vecchio
        SoundPlayer obstacleSkip = new SoundPlayer(@"audio\ObstacleSkip.wav"); //suono di quando superi un ostacolo
        SoundPlayer dashSound = new SoundPlayer(@"audio\Dash.wav");//suono dello scatto
        SoundPlayer death = new SoundPlayer(@"audio\Death.wav");
        private System.Windows.Forms.Timer powerUpTimer = new System.Windows.Forms.Timer(); //timer per il powerup, 10 sec, quando si attiva rende powerup off
        private System.Windows.Forms.Timer dashTimer = new System.Windows.Forms.Timer(); //timer dash, durata minore di 1 sec, tempo in aria durante lo scatto
        private System.Windows.Forms.Timer dashCoolDown = new System.Windows.Forms.Timer(); //cooldown per il dash, non si può spammare e bisogna aspettare 1 sec
        public Gioco() //questo è il costruttore del gioco, ogni volta che si avvia il form viene creato e tutti questi dati si attivano
        {
            //---------Timerss----------\\
            powerUpTimer.Interval = 10000;
            powerUpTimer.Tick += powerupTimer_Tick;  
            dashTimer.Interval = 200;
            dashTimer.Tick += dashTimer_Tick;
            dashCoolDown.Interval = 1000;
            dashCoolDown.Tick += dashCoolDown_Tick;
            //-----------InizioGioco-----------\\
            InitializeComponent();
            RestartGame();
            start.Play();
            //------------SelettoreMappa------------\\

        }
        private void GameTimerEvent(object sender, EventArgs e) //questo è il timer del gioco, finche il timer è attivo tutto il gioco funziona
        {
            //--------------ImpostazionePunteggio----------\\
            lblScore.ForeColor = Color.White;
            lblScore.Text = "Score: " + score;
            lblhighScore.Text = "High Score: " + highScore; 
            player.Top += gravity;
            onBottomPlatform = true;

            //-----------PlayerATerraBasso--------\\
            if (player.Top > 328)
            {
                gravity = 0;
                player.Top = 328;
                player.Image = Properties.Resources.run_down0;
                land.Play();
                onBottomPlatform = true;
                onTopPlatform = false;
                dashCoolDown.Stop();
                dash = false;
            }
            //------------------PlayerATerraAlto------------------\\
            else if (player.Top < 35)
            {
                gravity = 0;
                player.Top = 35;
                player.Image = Properties.Resources.run_up0;
                land.Play();
                onTopPlatform = true;
                onBottomPlatform = false;
                dashCoolDown.Stop();
                dash = false;
            }
            //-------------------MovimentoOstaocli+Punteggio---------------\\
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;
                    
                    //--------RespawnOstacoli------\\
                    if (x.Left < -100)
                    {
                        x.Left = random.Next(1000, 4000);
                        if (specialvl == true)
                        {
                            score += 2;
                            obstacleSkip.Play();
                        }
                        else
                        {
                            score += 1;
                            obstacleSkip.Play();
                        }
                    }

                    //---------------------HitBox--------------------\\
                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        if (powerup == false)
                        {
                            death.Play();
                            gameOver = true;
                            gameTimer.Stop();
                            lblScore.Text += "   Game Over!! Press Enter to Restart.";
                            //set the highscore
                            if (score > highScore)
                            {
                                highScore = score;
                            }
                        }
                    }
                }
            }
            //----------------------------MovimentoPiccione+Powerup------------------\\
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "pidgeon")
                {
                    x.Left -= obstacleSpeed;

                    if (x.Left < -100)
                    {
                        x.Left = random.Next(800, 200000);
                        score += 1;
                    }

                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        score += 1;
                        powerup = true;
                        powerUpTimer.Start();
                    }
                }
            }

            //-----------------------AUMENTO DIFFICOLTA---------------------\\
            for (int i = 9; i < score; i++)
            {
                if (i % 10 == 0)  // Ogni 10 punti
                {
                    int level = i / 10;  // Determina il livello in base al punteggio
                    obstacleSpeed = obstacleSpeed + (level * 5);  // Aumenta la velocità in base al livello
                    gravityValue = gravityValue + (level * 5);  // Aumenta la gravità in base al livello

                    // Colori casuali basati sul livello
                    Color[] colors = new Color[]
                    {
                Color.Red, Color.DarkRed, Color.Brown, Color.Purple, Color.Blue,
                Color.Cyan, Color.Yellow, Color.Green, Color.Orange, Color.Pink,
                Color.Black, Color.White, Color.Gray, Color.LightBlue, Color.Violet,
                Color.LightGreen, Color.LightPink, Color.Beige, Color.Indigo, Color.Salmon,
                Color.MintCream, Color.SeaGreen, Color.Tomato, Color.Gold, Color.Lime,
                Color.SkyBlue, Color.PeachPuff, Color.Moccasin, Color.Lavender, Color.Fuchsia,
                Color.LightGoldenrodYellow, Color.DodgerBlue, Color.Tan, Color.AliceBlue,
                Color.Wheat, Color.SlateGray, Color.LavenderBlush, Color.PapayaWhip, Color.DarkOrange,
                Color.OrangeRed, Color.MediumPurple
                    };

                    lblScore.ForeColor = colors[level % colors.Length];  // Imposta il colore in modo ciclico

                    if (i > 9)
                    {
                        obstacleSpeed = obstacleSpeed + ((i / 10) * 10);
                        gravityValue = gravityValue + ((i / 10) * 10);
                    }
                }
            }

        }

        //--------------------_________________-----KEYBINDINGS----------____________________--------------\\
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (player.Top == 328)
                {
                    player.Top -= 10;
                    gravity = -gravityValue;
                    jump.Play();
                }
                else if (player.Top == 35)
                {
                    player.Top += 10;
                    gravity = gravityValue;
                    jump.Play();
                }
            }
            if (e.KeyCode == Keys.Enter && gameOver == true) // = a scrivere "&& gameOver" (perchè guarda direttamente se è true)
            {
                RestartGame();
            }
            if (e.KeyCode == Keys.C && !dash)
            {
                dash = true;
                gravity = 0;
                obstacleSpeed = obstacleSpeed * 5;
                dashTimer.Start();
                dashSound.Play();
            }
        }

        //-----------Impostazioni Di Restart------------\\
        private void RestartGame()
        {
            gameOver = false;
            onBottomPlatform = true;
            lblScore.Parent = pictureBox1;
            lblhighScore.Parent = pictureBox2;
            lblhighScore.Top = 0;
            player.Location = new Point(180, 149);
            player.Image = Properties.Resources.run_down0;
            score = 0;
            gravityValue = 15;
            obstacleSpeed = 15;
            gravity = gravityValue;
            start.Play();

            int backgroundLoader = random.Next(3,3);
            switch (backgroundLoader)  //permette di cambiare lo sfondo e lo stile delle piattaforme in base alla mappa selezionata casuale (7 mappe diverse)
            {
                case 1:
                    this.BackgroundImage = Properties.Resources.background_still; //città blu (anteprima)
                    this.pictureBox1.BackgroundImage = Properties.Resources.platform_tilesblue;
                    this.pictureBox2.BackgroundImage = Properties.Resources.platform_tilesblue;
                    break;
                case 2:
                    this.BackgroundImage = Properties.Resources.Citadel; //cittadina viola
                    this.pictureBox1.BackgroundImage = Properties.Resources.platform_tilesPurple;
                    this.pictureBox2.BackgroundImage = Properties.Resources.platform_tilesPurple;
                    break;
                case 3:
                    this.BackgroundImage = Properties.Resources.Space; //spazio (la più difficile per via delle piattaforme difficili da notare (punti x2)
                    this.pictureBox1.BackgroundImage = Properties.Resources.Powerup;
                    this.pictureBox2.BackgroundImage = Properties.Resources.Powerup;
                    specialvl = true;
                    break;
                case 4:
                    this.BackgroundImage = Properties.Resources.MountainsForest; //foresta tranquilla
                    this.pictureBox1.BackgroundImage = Properties.Resources.platform_green;
                    this.pictureBox2.BackgroundImage = Properties.Resources.platform_green;
                    break;
                case 5:
                    this.BackgroundImage = Properties.Resources.Matrix; //matrix (il mio preferito)
                    this.pictureBox1.BackgroundImage = Properties.Resources.platform_tilesMatrix;
                    this.pictureBox2.BackgroundImage = Properties.Resources.platform_tilesMatrix;
                    break;
                case 6:
                    this.BackgroundImage = Properties.Resources.Sunset; //tramonto
                    this.pictureBox1.BackgroundImage = Properties.Resources.platform_tilesSunset;
                    this.pictureBox2.BackgroundImage = Properties.Resources.platform_tilesSunset;
                    break;
                case 7:
                    this.BackgroundImage = Properties.Resources.MountainsSunny; //montagne soleggiate
                    this.pictureBox1.BackgroundImage = Properties.Resources.platform_green;
                    this.pictureBox2.BackgroundImage = Properties.Resources.platform_green;
                    break;
            }

            //-----------------Nascita Degli Ostacli---------------------\\

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left = random.Next(1000, 6000);
                }
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "pidgeon")
                {
                    x.Left = random.Next(1000, 50000);
                }
            }
            gameTimer.Start();
        }

        private void PowerupTime(object sender, EventArgs e)  //-----Non usato
        { }

        private void powerupTimer_Tick(object sender, EventArgs e)
        {
            if (powerup == true)
            {
                powerup = false;
            }
        }

        private void dashTimer_Tick(Object sender, EventArgs e)
        {
            if (dash == true)
            {
                dashCoolDown.Start();
                obstacleSpeed = obstacleSpeed / 5;
                dashTimer.Stop();
                if (onTopPlatform == true)
                {
                    gravity -= gravityValue;
                }
                else if (onBottomPlatform == true)
                {
                    gravity += gravityValue;
                }

            }
        }
        private void dashCoolDown_Tick(object sender, EventArgs e)
        {
            dash = false;
            dashCoolDown.Stop();
        }

        private void pictureBox3_Click(object sender, EventArgs e)   //----- Ho cliccato per sbaglio
        {

        }
    }
}
