using System.Media;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class Gioco : Form
    {
        //----------------------------------------------------------------------------------------------------------------VARIABILI GLOBALI
        int gravity;
        int gravityValue;
        int obstacleSpeed; //Velocità del gioco 
        int score = 0;
        int level = 0; //livello per aumentare la velocità
        int powerupMiniTimer = 5; //secondi del powerup quandoa attivato
        int highScore = 0;
        bool gameOver = false; //se perdi
        bool powerup = false; //scudo (solo quello)
        bool dash = false;
        bool onTopPlatform = false;
        bool onBottomPlatform = false;
        bool powerupAntiFor = false; //serve per non far ripetere durante gametimer un azione specifica riguardante il powerup
        bool startGame = true; //quando inizia il gioco bisogna avviare il gioco la prima volta e poi non c'è più
        Random random = new Random();
        //----------------------------------------------------------------------------------------------------------------------------SUONI
        SoundPlayer land = new SoundPlayer(@"audio\Land.wav");  //atterraggio
        SoundPlayer jump = new SoundPlayer(@"audio\Jump.wav");  //salto
        SoundPlayer start = new SoundPlayer(@"audio\Speedup.wav"); //inizo il gioco - powerup
        SoundPlayer obstacleSkip = new SoundPlayer(@"audio\ObstacleSkip.wav");  //salti l'ostacolo
        SoundPlayer dashSound = new SoundPlayer(@"audio\Dash.wav"); //dash
        SoundPlayer death = new SoundPlayer(@"audio\Death.wav"); //morte
        SoundPlayer startGameMusic = new SoundPlayer(@"audio\StartGame.wav"); // musica background per l'avvio
        //---------------------------------------------------------------------------------------------------------------------------TIMERS
        private System.Windows.Forms.Timer powerUpTimer = new System.Windows.Forms.Timer();  //5 secondi, durata powerup
        private System.Windows.Forms.Timer dashTimer = new System.Windows.Forms.Timer(); //durata dash
        private System.Windows.Forms.Timer pwpLabelTimer = new System.Windows.Forms.Timer(); //timer per label powerup
        private System.Windows.Forms.Timer dashCoolDown = new System.Windows.Forms.Timer();  //cooldown dash
        //----------------------------------------------------------------------------------------------------------------COSTRUTTORE GIOCO
        public Gioco()//quando si avvia parte prima di tutto questo 
        {
            //------------------------------------------------------------------------------------------------SETUP TIMERS
            pwpLabelTimer.Interval = 1000;
            pwpLabelTimer.Tick += pwpLabelTimer_Tick;
            powerUpTimer.Interval = 5000;
            powerUpTimer.Tick += powerupTimer_Tick;
            dashTimer.Interval = 200;
            dashTimer.Tick += dashTimer_Tick;
            dashCoolDown.Interval = 1000;
            dashCoolDown.Tick += dashCoolDown_Tick;
            //-------------------------------------------------------------------------------------------------SCHERMATA INIZIALE
            InitializeComponent();
            if (startGame)
            {
                startGameMusic.Play();
                lblGameOver1.Text = "Gravity Runner";
                lblGameOver2.Text = "press enter to start";
                lblGameOver1.ForeColor = Color.Lime;
                lblGameOver1.Visible = true;
                gameOver = true; //Così posso cliccare "enter" dato il blocco per il restart
            }
            else
            {
                startGame = false;
                RestartGame(); //inizia seriamente il gioco
                start.Play();
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------COMANDI
        private void KeyIsUp(object sender, KeyEventArgs e) //keyeventargs è quando un tasto è schiacciato
        {
            if (e.KeyCode == Keys.Space) //------------------------------------------------------------------------------SPAZIO
            {
                if (player.Top == 328) //top platform
                {
                    player.Top -= 10;
                    gravity = -gravityValue;
                    jump.Play();
                }
                else if (player.Top == 35) //bottom platform
                {
                    player.Top += 10;
                    gravity = gravityValue;
                    jump.Play();
                }
            }
            if (e.KeyCode == Keys.Enter && gameOver)  //blocco per evitare lo spam di restart ---------------------------INVIO
            {
                RestartGame();
            }
            if (e.KeyCode == Keys.C && !dash && !gameOver) //funzionalità intera dash ----------------------------------- C
            {
                dash = true;
                gravity = 0; //rimane fermo a mezz'aria
                obstacleSpeed = obstacleSpeed + 10 * 5;
                dashTimer.Start(); //timer x durata dash
                dashSound.Play();
                //-----------------------------------------------------------------------------------SPRITES DASH
                if (powerup)
                {
                    player.Left -= 40;
                    player.Size = new Size(120, 80);
                    if (onTopPlatform) //sprites se si ha anche il powerup
                    {
                        player.Image = Properties.Resources.Dash_Shield_Up;
                    }
                    else if (onBottomPlatform)
                    {
                        player.Image = Properties.Resources.Dash_Shield_Down;
                    }
                }
                else //sprites normali del dash
                {
                    player.Left -= 40; //serviva ingrandirlo
                    player.Size = new Size(106, 80);
                    if (onTopPlatform)
                    {
                        player.Image = Properties.Resources.Dash_Down;
                    }
                    else if (onBottomPlatform)
                    {
                        player.Image = Properties.Resources.Dash_Up;
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------- AVVIO GIOCO
        private void RestartGame() //vale anche per restart
        { 
            //-------------------------------------------------------------------------------------------------SELETTORE MAPPE
            int backgroundLoader = random.Next(1, 6);
            switch (backgroundLoader)  //6 mappe diverse random
            {
                case 1:
                    this.BackgroundImage = Properties.Resources.background_still; //città blu
                    this.pictureBox1.BackgroundImage = Properties.Resources.platform_tilesblue;
                    this.pictureBox2.BackgroundImage = Properties.Resources.platform_tilesblue;
                    break;
                case 2:
                    this.BackgroundImage = Properties.Resources.Citadel; //cittadina viola
                    this.pictureBox1.BackgroundImage = Properties.Resources.platform_tilesPurple;
                    this.pictureBox2.BackgroundImage = Properties.Resources.platform_tilesPurple;
                    break;
                case 3:
                    this.BackgroundImage = Properties.Resources.MountainsForest; //foresta tranquilla
                    this.pictureBox1.BackgroundImage = Properties.Resources.platform_green;
                    this.pictureBox2.BackgroundImage = Properties.Resources.platform_green;
                    break;
                case 4:
                    this.BackgroundImage = Properties.Resources.Matrix; //matrix (il mio preferito)
                    this.pictureBox1.BackgroundImage = Properties.Resources.platform_tilesMatrix;
                    this.pictureBox2.BackgroundImage = Properties.Resources.platform_tilesMatrix;
                    break;
                case 5:
                    this.BackgroundImage = Properties.Resources.Sunset; //tramonto
                    this.pictureBox1.BackgroundImage = Properties.Resources.platform_tilesSunset;
                    this.pictureBox2.BackgroundImage = Properties.Resources.platform_tilesSunset;
                    break;
                case 6:
                    this.BackgroundImage = Properties.Resources.MountainsSunny; //montagne soleggiate
                    this.pictureBox1.BackgroundImage = Properties.Resources.platform_green;
                    this.pictureBox2.BackgroundImage = Properties.Resources.platform_green;
                    break;
            }
            //-------------------------------------------------------------------------------------------------RESET STATS
            player.Image = Properties.Resources.run_down0;
            player.Location = new Point(180, 149);
            score = 0;
            level = 0;
            obstacleSpeed = 15;
            gravityValue = 15;
            gravity = gravityValue;
            onBottomPlatform = true;
            gameOver = false;
            powerup = false;
            //----------------------------------------------------------------------------------------------PARENTELE LABLES
            lblScore.Parent = pictureBox2;//per impostare la trasparenza degli oggetti
            lblhighScore.Parent = pictureBox2;
            lblDashCooldown.Parent = pictureBox2;
            lblSpeedLvl.Parent = pictureBox1;
            lblPowerupMiniTimer.Parent = pictureBox2;
            //------------------------------------------------------------------------------------------------SETUP LABLES
            lblDashCooldown.Top = 10;
            lblPowerupMiniTimer.Top = 40;
            lblScore.Top = 10;
            lblhighScore.Top = 40;
            lblGameOver1.Visible = false;
            lblGameOver2.Visible = false;
            start.Play();
            //---------------------------------------------------------------------------------------------NASCITA OSTACOLI
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")//-------------------OSTACOLI NORMALI
                {
                    OverlapCheck(x);
                }
                if (x is PictureBox && (string)x.Tag == "obstacleWithoutHbx")//----OSTACOLI SENZA HITBOX (ESTERNA)
                {
                    OverlapCheck(x);
                }
            }
            //----------------------------------------------------------------------------POWERUP
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Shield") 
                {
                    x.Left = random.Next(5000, 20000);
                }
            }
            gameTimer.Start();
        }
        //--------------------------------------------------------------------------------------------------------------------TIMER GIOCO
        private void GameTimerEvent(object sender, EventArgs e) // """fps"""
        {
            //--------------------------------------------------------------------------------------------IMPOSTAZIONE LABELS
            lblScore.ForeColor = Color.White;
            lblScore.Text = "Score: " + score;
            lblhighScore.Text = "High Score: " + highScore;
            if (dash) { lblDashCooldown.Text = "Dash: Not Ready!"; }
            else { lblDashCooldown.Text = "Dash: Ready!"; }
            lblSpeedLvl.Text = "Speed Level: " + level;

            //------------------------------------------------------------------------------------------IMPOSTAZIONE PERSONAGGIO
            player.Top += gravity;
            onBottomPlatform = true;

            //-------------------------------------------------------------------------------------------ATTERRAGGIO PLATFORM SU
            if (player.Top > 328) //posizione BottomPlatform 
            {
                gravity = 0;
                player.Top = 328;
                land.Play();

                if (powerup) //------------------------------------------------------SPRITES ATTERRAGGIO
                {
                    player.Image = Properties.Resources.Shield_Up; //sarebbe down
                    player.Size = new Size(86, 80);
                }
                else //se no quella normale
                {
                    player.Image = Properties.Resources.run_down0;
                }

                //setta in che piattaforma è il player ora
                onBottomPlatform = true;
                onTopPlatform = false;
                //se atterra in una piattaforma il cooldown per il dash si resetta (si può spammare per terra)
                dashCoolDown.Stop();
                dash = false;
            }
            //-----------------------------------------------------------------------------------------ATTERRAGGIO PLATFORM GIU'
            else if (player.Top < 35) //Posizione TopPlatForm
            {
                gravity = 0;
                player.Top = 35;
                land.Play();

                if (powerup)
                {
                    player.Image = Properties.Resources.Shield_Down; //sarebbe Up
                    player.Size = new Size(86, 80);
                }
                else
                {
                    player.Image = Properties.Resources.run_up0;
                }
                onTopPlatform = true;
                onBottomPlatform = false;
                dashCoolDown.Stop();
                dash = false;
            }
            //------------------------------------------------------------------------------------------RESPAWN OSTACOLI + SCORE
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;  //gli ostacoli si muovono verso sinistra
                    Rectangle HitboxRocce = new Rectangle(pictureBox3.Left + 20, pictureBox3.Top + 20, pictureBox3.Width - 20, pictureBox3.Height - 20); //hitbox esterna più accurata
                    if (x.Left < -100)
                    {
                            score += 1;
                            obstacleSkip.Play();
                            OverlapCheck(x);
                    }
                    //-------------------------------------------------------------------------------------CONTROLLO GAMEOVER
                    if (x.Bounds.IntersectsWith(player.Bounds) || player.Bounds.IntersectsWith(HitboxRocce))
                    {
                        GameOver();
                    }
                }
                //---------------------------------------------------------------------------------------RESPAWN ROCCIA (NO HB)
                if (x is PictureBox && (string)x.Tag == "obstacleWithoutHbx")
                {
                    x.Left -= obstacleSpeed;
                    if (x.Left < -100)
                    {
                        score += 1;
                        obstacleSkip.Play();
                        bool overlapping; //overlap check manuale perchè bisogna anche contare l'altro tipo, se no non funziona
                        do
                        {
                            overlapping = false;
                            x.Left = random.Next(1000, 6000);

                            foreach (Control other in this.Controls)
                            {
                                if (other != x && other is PictureBox && (string)other.Tag == "obstacle")
                                {
                                    if (x.Bounds.IntersectsWith(other.Bounds))
                                    {
                                        overlapping = true;
                                        break;
                                    }
                                }
                            }
                        } while (overlapping);
                    }
                }
            } 
            //-----------------------------------------------------------------------------------------------RESPAWN POWERUP
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Shield")
                {
                    x.Left -= obstacleSpeed;

                    if (x.Left < -100)
                    {
                        x.Left = random.Next(5000, 20000);
                    }
                    //---------------------------------------------------------------------------------------HITBOX POWERUP
                    if (x.Bounds.IntersectsWith(player.Bounds) && !powerupAntiFor)
                    {//powerup serve per non ripetersi nel foreach o gametimer

                        player.Left -= 20; //per ingrandirlo
                        powerup = true;
                        powerupAntiFor = true;
                        powerupMiniTimer = 4; //parte da 4 perchè un secondo lo spreca 1 tick del circuito  

                        powerUpTimer.Start(); //start timers
                        pwpLabelTimer.Start();

                        lblPowerupMiniTimer.Text = "Powerup: " + powerupMiniTimer + "s"; //inizia il timer

                        start.Play();
                    }
                }
            }
            //------------------------------------------------------------------------------------------------DIFFICOLTA'
            for (int i = 9; i < score; i++)
            {
                if (!dash)
                {
                    if (i % 10 == 0)  // Ogni 10 punti
                    {
                        level = i / 10;  // Determina il livello in base al punteggio
                        obstacleSpeed = obstacleSpeed + (level * 5);  // Aumenta la velocità in base al livello
                        gravityValue = gravityValue + (level * 10);  // Aumenta la gravità in base al livello

                        if (i > 9)
                        {
                            obstacleSpeed = 15 + ((i / 10) * 5);
                            gravityValue = 10 + ((i / 10) * 10);
                        }
                    }
                }
            }
        }
        private void powerupTimer_Tick(object sender, EventArgs e) //-------------------------------------------------TIMER DURATA POWERUP
        {
            if (powerup) //setup delle sprites
            {
                if (onTopPlatform)
                {
                    player.Image = Properties.Resources.run_up0; ;
                }
                else if (onBottomPlatform)
                {
                    player.Image = Properties.Resources.run_down0;
                }
            }
            powerup = false;
            powerupAntiFor = false; //nel caso bisogna ricaricare un altra volta il for per bloccarlo al primo utilizzo
            player.Top += 20; //rimpicciolisco il player per farlo tornare normale
            player.Size = new Size(66, 80);
        }
        private void dashTimer_Tick(Object sender, EventArgs e) //------------------------------------------------------TIMER DURATA DASH
        {
            if (dash)
            {
                dashCoolDown.Start(); //timers
                dashTimer.Stop();

                obstacleSpeed = obstacleSpeed - 10 * 5;  //velocità aumentata del dash


                player.Left += 40; //cambio grandezza e carico sprites
                player.Size = new Size(66, 80);
                if (onTopPlatform)
                {
                    player.Image = Properties.Resources.run_up0;
                    gravity -= gravityValue; //ritorna alla gravità che aveva prima di fare il dash
                }
                else if (onBottomPlatform)
                {
                    player.Image = Properties.Resources.run_down0;
                    gravity += gravityValue;
                }
            }
        }
        private void dashCoolDown_Tick(object sender, EventArgs e) //-----------------------------------------TIMER DURATA COOLDOWN DASH
        {
            dash = false;
            dashCoolDown.Stop();
        }
        private void pwpLabelTimer_Tick(object sender, EventArgs e) //-----------------------------------------TIMER LABEL POWERUP TEMPO
        {
            if (powerupMiniTimer > 0) //se è più grande scende
            {
                powerupMiniTimer--;
                lblPowerupMiniTimer.Text = "Powerup: " + powerupMiniTimer + "s";
            }
            else //se no rimane none, visto che non ci sono powerup attivi
            {
                lblPowerupMiniTimer.Text = "Powerup: none";
            }
        }
        private void OverlapCheck(Control x)
        {
            bool overlapping;
            do
            {
                overlapping = false;
                x.Left = random.Next(1000, 6000);

                foreach (Control other in this.Controls)
                {
                    if (other != x && other is PictureBox && (string)other.Tag == "obstacle")
                    {
                        if (x.Bounds.IntersectsWith(other.Bounds))
                        {
                            overlapping = true;
                            break;
                        }
                    }
                }
            } while (overlapping);
        }
        private void GameOver()
        {
            if (powerup == false)
            {
                death.Play();
                gameOver = true;
                gameTimer.Stop(); //si ferma il gioco

                //setup label per il gameover
                lblGameOver1.Text = "Game Over";
                lblGameOver2.Text = "press enter to restart";
                lblGameOver1.ForeColor = Color.Red;
                lblGameOver1.Visible = true;
                lblGameOver2.Visible = true;
                //set the highscore
                if (score > highScore)
                {
                    highScore = score;
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------COSE INUTILI
        private void pictureBox3_Click(object sender, EventArgs e) { }
        private void player_Click(object sender, EventArgs e) { }
        private void lblhighScore_Click(object sender, EventArgs e) { }
        private void CoolDown_Click(object sender, EventArgs e) { }
        private void PowerupTime(object sender, EventArgs e) { }
        private void lblSpeedLvl_Click(object sender, EventArgs e) { }
        private void lblGameOver1_Click(object sender, EventArgs e) { }
        private void Gioco_Load(object sender, EventArgs e) { }
    }
}
