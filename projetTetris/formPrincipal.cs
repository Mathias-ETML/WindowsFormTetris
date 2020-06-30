using System;
using System.Timers;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.Threading.Tasks;
using static projetTetris.VariablesEntreForm;
using static projetTetris.VariablesPrincipales;
using static projetTetris.Colors;

namespace projetTetris
{
    public partial class formJeu : Form
    {
        // presetation : par quoi j'ai commencé, comment j'ai fais quoi (genre rota) , particularitées, bugs, demo
        // les bugs : colision avec bordure, rotaion dans les blocs, detection colision, clock principale, ( pour presentation )

        // TODO : TXT IN RESSOURCE
        // TODO : MUSIC FILE IN RESSOURCE ( if possible )

        Objects.ObjectOfPlayer objectOfPlayer = new Objects.ObjectOfPlayer(null, false, false, true, 0, 0, 0, 0, 0);
        Objects.ObjectInReserve objectInReserve = new Objects.ObjectInReserve(null, 0, 0, 0);
        GameColors gameColors = new GameColors();

        /// <summary>
        /// initialisation of the form
        /// </summary>
        public formJeu()
        {
            InitializeComponent();

            onStart();
        }

        /// <summary>
        /// initalisation of the variables, music ( if wanted ),  the timer, where the figures will spawn, 
        /// the text for the label, random for what figure will spawn, and the new thread for the game
        /// </summary>
        private void onStart()  
        {
            Random rnd = new Random();

            // reset if player restart
            g_boolStopThread = false;
            g_tab_labCarreInGame = new Label[G_BYTETAILLETABAXEX, G_BYTETAILLETABAXEY];
            g_byteFiguresSpawnCount = 0;
            g_shrtIntervalTimer = 1000;

            // add the thread to the list of thread to stop if player want to restart
            g_listThread.Add(Thread.CurrentThread);

            // enable music
            if (g_boolDoesPlayerWantMusic)
            {
                musiqueTetris = new SoundPlayer(@"K:\INF\Eleves\DemoMot\CIN1A\matrogey\Scores\musiqueTetris.wav");
                musiqueTetris.PlayLooping();
            }

            // dark mode
            if (g_boolSoftColorsEnabled)
            {
                // ty santiago :)
                panZoneJeu.BackColor = Color.FromArgb(37, 37, 38);
                panNextFigure.BackColor = Color.FromArgb(37, 37, 38);
                this.BackColor = Color.FromArgb(45, 45, 48);

                Font SoftFont = new Font("Consolas", 10, FontStyle.Bold);
                lblNomJoueur.Font = new Font("Consolas", (float)8.25, FontStyle.Bold); ;
                lblNomJoueur.ForeColor = Color.White;

                lblLevel.Font = SoftFont;
                lblLevel.ForeColor = Color.White;
                lblLignes.Font = SoftFont;
                lblLignes.ForeColor = Color.White;
                lblPlayerScore.Font = SoftFont;
                lblPlayerScore.ForeColor = Color.White;
            }
            // normal mode
            else
            {
                gameColors.normalColors();
            }

            // timer
            graviteTimer = new System.Timers.Timer();
            graviteTimer.Elapsed += new ElapsedEventHandler(onUpdateAsync);
            graviteTimer.Interval = g_shrtIntervalTimer;

            // init where figure will spawn
            objectOfPlayer.IntPosFigureAxeX = panZoneJeu.Width / 2 - G_BYTEWIDTHANDHEIGHTBLOCKS;

            // init text
            lblLevel.Text = "Niveau : 1";
            lblPlayerScore.Text = "Score : 0";
            lblLignes.Text = "Lignes : 0";
            lblNomJoueur.Text = "Nom : " + g_strNomJoueurInput;

            // init what figure will spawn
            objectInReserve.ByteNumFigureSpawnViaFigureReserve = (byte)rnd.Next(7);
            
            // start game on a new thread
            Thread g_threadGame = new Thread(spawnFigureRandomReserve);
            g_threadGame.SetApartmentState(ApartmentState.STA);
            g_threadGame.Start();

            g_listThread.Add(g_threadGame);
        }

        /// <summary>
        /// This block will compact the creation of a squared label with the color, location via the XY and return it
        /// </summary>
        /// <param name="color"> color you want </param>
        /// <param name="X"> the X of the for loop </param>
        /// <param name="Y"> the Y of the for loop ( if there is one, input a number between 0 and 4 </param>
        /// <returns> return a label with color, location and visual styles</returns>
        private Label cubeDesObjets(Color color, byte X, byte Y)
        {
            Label temp = new Label();

            temp.Width = G_BYTEWIDTHANDHEIGHTBLOCKS;
            temp.Height = G_BYTEWIDTHANDHEIGHTBLOCKS;
            temp.BackColor = color;

            // dark mode friendly
            if (!g_boolSoftColorsEnabled)
            {
                temp.BorderStyle = BorderStyle.FixedSingle;
            }

            temp.Location = new Point(G_BYTEWIDTHANDHEIGHTBLOCKS * X + panZoneJeu.Width/2 - G_BYTEWIDTHANDHEIGHTBLOCKS, G_BYTEWIDTHANDHEIGHTBLOCKS * Y);

            return temp;
        }

        /// <summary>
        /// this block will make spawn a square and will give the player the power to move it
        /// </summary>
        /// <param name="spawnDansReserve"> if the object need to spawn into the reservre witch show what is the next object to spawn </param>
        private void spawnCarre(bool spawnDansReserve)
        {
            // because it spawn in a panel that doesn't need interaction, we dont' need to reset the variables
            if (!spawnDansReserve)
            {
                resetVariables(2, false, "Carre");
            }
            else
            {
                objectInReserve.StrNameOfObject = "Carre";
            }

            // loop to spawn labels in a certain position
            for (byte y = 0; y < 2; y++)
            {
                for (byte x = 0; x < 2; x++)
                {
                    Label labCarre = cubeDesObjets(ConvertByteToColor(gameColors.Yellow), x, y);

                    creationFigures(labCarre, x, y, spawnDansReserve);
                }
            }

            // so we dont neeed to give him gravity
            if (!spawnDansReserve)
            {
                graviteTimer.Start();
            }
        }

        /// <summary>
        /// this block will make spawn a stick and will give the player the power to move it
        /// </summary>
        /// <param name="spawnDansReserve"> if the object need to spawn into the reservre witch show what is the next object to spawn </param>
        private void spawnBaton(bool spawnDansReserve)
        {
            // because it spawn in a panel that doesn't need interaction, we dont' need to reset the variables
            if (!spawnDansReserve)
            {
                resetVariables(4, false, "Baton");
            }
            else
            {
                objectInReserve.StrNameOfObject = "Baton";
            }

            // loop to spawn labels in a certain position
            for (byte y = 0; y < 4; y++)
            {
                Label labBatton = cubeDesObjets(ConvertByteToColor(gameColors.Pink), 0, y);

                creationFigures(labBatton, 0, y, spawnDansReserve);
            }

            // so we dont neeed to give him gravity
            if (!spawnDansReserve)
            {
                graviteTimer.Start();
            }
        }

        /// <summary>
        /// this block will make spawn a reverse " T " and will give the player the power to move it
        /// </summary>
        /// <param name="spawnDansReserve"> if the object need to spawn into the reservre witch show what is the next object to spawn </param>
        private void spawnT(bool spawnDansReserve)
        {
            // because it spawn in a panel that doesn't need interaction, we dont need to reset the variables
            if (!spawnDansReserve)
            {
                resetVariables(3, true, "T");
            }
            else
            {
                objectInReserve.StrNameOfObject = "T";
            }

            // loop to spawn labels in a certain position
            for (byte y = 0; y < 2; y++)
            {
                for (byte x = 0; x < 3; x++)
                {
                    // algo for the reversed " T "
                    if (x != 0 && y != 0 || x != 2 && y != 0 || x == 1)
                    {
                        Label labT = cubeDesObjets(ConvertByteToColor(gameColors.Blue), x, y);

                        creationFigures(labT, x, y, spawnDansReserve);
                    }
                }
            }

            // so we dont neeed to give him gravity
            if (!spawnDansReserve)
            {
                graviteTimer.Start();
            }
        }

        /// <summary>
        /// this block will make spawn a L and will give the player the power to move it
        /// </summary>
        /// <param name="spawnDansReserve"> if the object need to spawn into the reservre witch show what is the next object to spawn </param>
        private void spawnL(bool spawnDansReserve)
        {
            // because it spawn in a panel that doesn't need interaction, we dont need to reset the variables
            if (!spawnDansReserve)
            {
                resetVariables(3, true, "L");
            }
            else
            {
                objectInReserve.StrNameOfObject = "L";
            }

            // loop to spawn labels in a certain position
            for (byte y = 0; y < 2; y++)
            {
                for (byte x = 0; x < 3; x++)
                {
                    // algo for the L
                    if (y != 0 && x != 0 || x != 1 && y != 0 || x == 2)
                    {
                        Label labL = cubeDesObjets(ConvertByteToColor(gameColors.Red), x, y);

                        creationFigures(labL, x, y, spawnDansReserve);
                    }
                }
            }

            // so we dont neeed to give him gravity
            if (!spawnDansReserve)
            {
                graviteTimer.Start();
            }
        }

        /// <summary>
        /// this block will make spawn a inversed L and will give the player the power to move it
        /// </summary>
        /// <param name="spawnDansReserve"> if the object need to spawn into the reservre witch show what is the next object to spawn </param>
        private void spawnSymetrieHorizontalL(bool spawnDansReserve)
        {
            // because it spawn in a panel that doesn't need interaction, we dont need to reset the variables
            if (!spawnDansReserve)
            {
                resetVariables(3, true, "SHL");
            }
            else
            {
                objectInReserve.StrNameOfObject = "SHL";
            }

            // loop to spawn labels in a certain position
            for (byte y = 0; y < 2; y++)
            {
                for (byte x = 0; x < 3; x++)
                {
                    // algo for the inversed L
                    if (y != 0 && x != 2 || x != 1 && y != 0 || x == 0)
                    {
                        Label labLSH = cubeDesObjets(ConvertByteToColor(gameColors.Orange), x, y);

                        creationFigures(labLSH, x, y, spawnDansReserve);
                    }
                }
            }

            // so we dont neeed to give him gravity
            if (!spawnDansReserve)
            {
                graviteTimer.Start();
            }
        }

        /// <summary>
        /// this block will make spawn a S and will give the player the power to move it
        /// </summary>
        /// <param name="spawnDansReserve"> if the object need to spawn into the reservre witch show what is the next object to spawn </param>
        private void spawnS(bool spawnDansReserve)
        {
            // because it spawn in a panel that doesn't need interaction, we dont need to reset the variables
            if (!spawnDansReserve)
            {
                resetVariables(3, false, "S");
            }
            else
            {
                objectInReserve.StrNameOfObject = "S";
            }

            // loop to spawn labels in a certain position
            for (byte y = 0; y < 2; y++)
            {
                for (byte x = 0; x < 3; x++)
                {
                    // algo for the S
                    if (x != 0  && y != 0 || x != 2 && y != 1)
                    {
                        Label labS = cubeDesObjets(ConvertByteToColor(gameColors.DarkGreen), x, y);

                        creationFigures(labS, x, y, spawnDansReserve);
                    }
                }
            }

            // so we dont neeed to give him gravity
            if (!spawnDansReserve)
            {
                graviteTimer.Start();
            }
        }

        /// <summary>
        /// this block will make spawn a inversed S and will give the player the power to move it
        /// </summary>
        /// <param name="spawnDansReserve"> if the object need to spawn into the reservre witch show what is the next object to spawn </param>
        private void spawnSymetrieHorizontalS(bool spawnDansReserve)
        {
            // because it spawn in a panel that doesn't need interaction, we dont' need to reset the variables
            if (!spawnDansReserve)
            {
                resetVariables(3, false, "SHS");
            }
            else
            {
                objectInReserve.StrNameOfObject = "SHS";
            }

            // loop to spawn labels in a certain position
            for (byte y = 0; y < 2; y++)
            {
                for (byte x = 0; x < 3; x++)
                {
                    // algo for the reversed S
                    if (x != 2 && y != 0 || x != 0 && y != 1)
                    {
                        Label labSHS = cubeDesObjets(ConvertByteToColor(gameColors.Green), x, y);

                        creationFigures(labSHS, x, y, spawnDansReserve);
                    }
                }
            }

            // so we dont neeed to give him gravity
            if (!spawnDansReserve)
            {
                graviteTimer.Start();
            }
        }

        /// <summary>
        /// This block will put the label that was created into the playable zone or into the reserve
        /// </summary>
        /// <param name="item"> the item you want to put somewere </param>
        /// <param name="x"> the X of the for loop </param>
        /// <param name="y"> the Y of the for loop </param>
        /// <param name="spawnReserve"> if you want to spawn it into the reserve, else it will spawn into the playable zone </param>
        private void creationFigures(Label item, int x, int y, bool spawnReserve)
        {
            // put the label's into the reserve
            if (spawnReserve)
            {
                // put the labels into the list for the reserve
                objectInReserve.List_labFigureReserve.Add(item);

                // give more sence because the object where not centered
                if (objectInReserve.StrNameOfObject == "Carre" || objectInReserve.StrNameOfObject == "Baton")
                {
                    if (objectInReserve.StrNameOfObject == "Carre")
                    {
                        item.Location = new Point(x * G_BYTEWIDTHANDHEIGHTBLOCKS + G_BYTEWIDTHANDHEIGHTBLOCKS + G_BYTEWIDTHANDHEIGHTBLOCKS/2, y * G_BYTEWIDTHANDHEIGHTBLOCKS + G_BYTEWIDTHANDHEIGHTBLOCKS + G_BYTEWIDTHANDHEIGHTBLOCKS/2);
                    }
                    else
                    {
                        item.Location = new Point(x * G_BYTEWIDTHANDHEIGHTBLOCKS + G_BYTEWIDTHANDHEIGHTBLOCKS * 2, y * G_BYTEWIDTHANDHEIGHTBLOCKS + G_BYTEWIDTHANDHEIGHTBLOCKS/2);
                    }
                }
                else
                {
                    item.Location = new Point(x * G_BYTEWIDTHANDHEIGHTBLOCKS + G_BYTEWIDTHANDHEIGHTBLOCKS, y * G_BYTEWIDTHANDHEIGHTBLOCKS + G_BYTEWIDTHANDHEIGHTBLOCKS);
                }

                if (InvokeRequired && !g_boolStopThread)
                {
                    Invoke(new Action(() => panNextFigure.Controls.Add(item)));
                }
                else if(!g_boolStopThread)
                {
                    panNextFigure.Controls.Add(item);
                }
            }
            // else put them into the playable zone
            else
            {
                // check if the labels spawn into an existing label
                if (g_tab_labCarreInGame[item.Location.X / G_BYTEWIDTHANDHEIGHTBLOCKS, item.Location.Y / G_BYTEWIDTHANDHEIGHTBLOCKS] == null)
                {
                    // put the labels into the array for rotation
                    objectOfPlayer.Tab_bufferLabelRota[x, y] = item;

                    // put the label into the list
                    objectOfPlayer.List_labFigureJoueur.Add(item);

                    if (InvokeRequired && !g_boolStopThread)
                    {
                        Invoke(new Action(() => panZoneJeu.Controls.Add(item)));
                    }
                    else if (!g_boolStopThread)
                    {
                        panZoneJeu.Controls.Add(item);
                    }
                }
                // if yes its the end of the game
                else
                {
                    runFinalForm();
                    return;
                }
            }
        }


        /// <summary>
        /// This is compacting all the varaibles that need to be reseted at each spawn of objects
        /// </summary>
        /// <param name="hauteurRota"> what is the maximum height of the object </param>
        /// <param name="DoesPlayerNeefFullRotation"> if the object need more than 2 roation, like the reverse " T " </param>
        private void resetVariables(byte hauteurRota, bool DoesPlayerNeefFullRotation, string nameOfObject)
        {
            // reset evrything 
            objectOfPlayer.StrNameOfObject = nameOfObject;
            objectOfPlayer.List_labFigureJoueur.Clear();
            objectOfPlayer.ByteHateurFigureMaximal = hauteurRota;
            objectOfPlayer.IntPosFigureAxeX = panZoneJeu.Width / 2 - G_BYTEWIDTHANDHEIGHTBLOCKS;
            objectOfPlayer.Tab_bufferLabelRota = new Label[hauteurRota, hauteurRota];
            objectOfPlayer.IntPosFigureAxeY = 0;
            objectOfPlayer.BoolDidPlayerRotaded = false;
            objectOfPlayer.BoolDoesPlayerNeedFullRotation = DoesPlayerNeefFullRotation;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// This block will move the player object
        /// </summary>
        /// <param name="deplacementX"> how many pixel do you want to move it on the X axis ( it need to be the width/height of a label, so 30 pixel ) </param>
        /// <param name="deplacementY"> how many pixel do you want to move it on the Y axis ( it need to be the width/height of a label, so 30 pixel ) </param>
        /// <param name="needVerification"> if the object was allready checked, ( like in the main loop ) you dont need to re-check it </param>
        private void deplacementObjet(int deplacementX, int deplacementY, bool needVerification)
        {
            // check if need verifiction and if the player can move where he want
            if (needVerification && canPlayerMoveHere(deplacementX, deplacementY))
            {
                // move the player loction on the X axis
                objectOfPlayer.IntPosFigureAxeX += deplacementX;

                // loop to move every label
                for (int i = 0; i < 4; i++)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => objectOfPlayer.List_labFigureJoueur[i].Location = new Point(deplacementX + objectOfPlayer.List_labFigureJoueur[i].Location.X, deplacementY + objectOfPlayer.List_labFigureJoueur[i].Location.Y)));
                    }
                    else
                    {
                        objectOfPlayer.List_labFigureJoueur[i].Location = new Point(deplacementX + objectOfPlayer.List_labFigureJoueur[i].Location.X, deplacementY + objectOfPlayer.List_labFigureJoueur[i].Location.Y);
                    }
                }
            }
            // else juste move the figure because he doesn't need
            else if(!needVerification)
            {
                // loop to move every label
                for (int i = 0; i < 4; i++)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => objectOfPlayer.List_labFigureJoueur[i].Location = new Point(deplacementX + objectOfPlayer.List_labFigureJoueur[i].Location.X, deplacementY + objectOfPlayer.List_labFigureJoueur[i].Location.Y)));
                    }
                    else
                    {
                        objectOfPlayer.List_labFigureJoueur[i].Location = new Point(deplacementX + objectOfPlayer.List_labFigureJoueur[i].Location.X, deplacementY + objectOfPlayer.List_labFigureJoueur[i].Location.Y);
                    }
                }
            }
        }

        /// <summary>
        /// check if the player movment is in the playable zone or if he dosen't go into other objects
        /// </summary>
        /// <param name="deplacementX"> where the player want to go on the X axis ( it need to be the width/height of a label, so 30 pixel ) </param>
        /// <param name="deplacementY"> where the player want to go on the Y axis ( it need to be the width/height of a label, so 30 pixel ) </param>
        /// <returns> return if the player can move here via a boolean </returns>
        private bool canPlayerMoveHere(int deplacementX, int deplacementY)
        {
            // loop to check if every label moved with the XY axis input are in the playable zone and dont interfer with other objects
            if (objectOfPlayer.List_labFigureJoueur.Count == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    // if true instatly break a return false;
                    if (deplacementX + objectOfPlayer.List_labFigureJoueur[i].Location.X < 0 || deplacementX + objectOfPlayer.List_labFigureJoueur[i].Location.X >= panZoneJeu.Width ||
                        g_tab_labCarreInGame[(deplacementX + objectOfPlayer.List_labFigureJoueur[i].Location.X) / G_BYTEWIDTHANDHEIGHTBLOCKS, (deplacementY + objectOfPlayer.List_labFigureJoueur[i].Location.Y) / G_BYTEWIDTHANDHEIGHTBLOCKS] != null)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }


        ///////////////////////////////////////////////


        /// <summary>
        /// get the player input
        /// </summary>
        /// <param name="sender">  </param>
        /// <param name="e"> what key the player pressed </param>
        private void inputUser(object sender, KeyEventArgs e)
        {
            if (objectOfPlayer.BoolCanPlayerMoveObject)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        deplacementObjet(-G_BYTEWIDTHANDHEIGHTBLOCKS, 0, true);
                        break;

                    case Keys.Right:
                        deplacementObjet(G_BYTEWIDTHANDHEIGHTBLOCKS, 0, true);
                        break;

                    case Keys.Space:
                        graviteTimer.Interval = 10;
                        objectOfPlayer.BoolCanPlayerMoveObject = false;
                        break;

                    case Keys.R:
                        rotationObjetJoueur();
                        break;

                    case Keys.H:
                        showHelp();
                        break;

                    case Keys.Escape:
                        showHelp();
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// this method will reset the values of the pressed key when the playe relase it
        /// </summary>
        /// <param name="sender">  </param>
        /// <param name="e"> what key the player pressed </param>
        private void stopInputUser(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // reset when player remove his finger from space key
                case Keys.Space:
                    graviteTimer.Interval = g_shrtIntervalTimer;
                    objectOfPlayer.BoolCanPlayerMoveObject = true;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// shows the help
        /// </summary>
        private void showHelp()
        {
            MessageBox.Show("Deplacement : Flèche droite et gauche" +
                            "\nRotation : R" +
                            "\nDrop : Espace" +
                            "\nHelp : Escape ou H");
        }


        ///////////////////////////////////////////////


        /// <summary>
        /// spawn a random figure in the reserve and will dispose the ones who are in the reserve
        /// </summary>
        private void spawnFigureRandomReserve()
        {
            Random rnd = new Random();

            // spawn the last figure that the random " made "
             spawnFigureZoneJeu();

            // make a new one
            objectInReserve.ByteNumFigureSpawnViaFigureReserve = (byte)rnd.Next(7);

            // dispose every figure in the reserve
            foreach (Label item in objectInReserve.List_labFigureReserve)
            {
                if (InvokeRequired && !this.IsDisposed && !g_boolStopThread)
                {
                    Invoke(new Action(() => item.Dispose()));
                }
                else if (!g_boolStopThread)
                {
                    item.Dispose();
                }
            }

            // spawn figure into reserve
            switch (objectInReserve.ByteNumFigureSpawnViaFigureReserve)
            {
                case 0:
                    spawnCarre(true);
                    break;

                case 1:
                    spawnBaton(true);
                    break;

                case 2:
                    spawnL(true);
                    break;

                case 3:
                    spawnT(true);
                    break;

                case 4:
                    spawnSymetrieHorizontalL(true);
                    break;

                case 5:
                    spawnS(true);
                    break;

                case 6:
                    spawnSymetrieHorizontalS(true);
                    break;

                default:
                    // bruh
                    break;
            }
        }

        /// <summary>
        /// spawn a figure in the playable zone
        /// </summary>
        private void spawnFigureZoneJeu()
        {
            // spawn figure into the playable zone
            switch (objectInReserve.ByteNumFigureSpawnViaFigureReserve)
            {
                case 0:
                    spawnCarre(false);
                    break;

                case 1:
                    spawnBaton(false);
                    break;

                case 2:
                    spawnL(false);
                    break;

                case 3:
                    spawnT(false);
                    break;

                case 4:
                    spawnSymetrieHorizontalL(false);
                    break;

                case 5:
                    spawnS(false);
                    break;

                case 6:
                    spawnSymetrieHorizontalS(false);
                    break;

                default:
                    // bruh
                    break;
            }
        }


        ///////////////////////////////////////////////


        /// <summary>
        /// will rotate the player figure
        /// </summary>
        private void rotationObjetJoueur()
        {
            // create a new buffer label to copy the rotaded figure and to check if the roation is possible
            Label[,] tab_labBufferCopyLabel = new Label[objectOfPlayer.ByteHateurFigureMaximal, objectOfPlayer.ByteHateurFigureMaximal];

            if (objectOfPlayer.StrNameOfObject != "Carre")
            {
                if (!objectOfPlayer.BoolDidPlayerRotaded && !objectOfPlayer.BoolDoesPlayerNeedFullRotation)
                {
                    objectOfPlayer.BoolDidPlayerRotaded = true;

                    // loop to copy the figure into the buffer array
                    for (int y = 0; y < objectOfPlayer.ByteHateurFigureMaximal; y++)
                    {
                        for (int x = 0; x < objectOfPlayer.ByteHateurFigureMaximal; x++)
                        {
                            // directly roate while looping
                            tab_labBufferCopyLabel[y, objectOfPlayer.ByteHateurFigureMaximal - 1 - x] = objectOfPlayer.Tab_bufferLabelRota[x, y];
                        }
                    }
                }
                else if (objectOfPlayer.BoolDidPlayerRotaded && !objectOfPlayer.BoolDoesPlayerNeedFullRotation)
                {
                    objectOfPlayer.BoolDidPlayerRotaded = false;

                    // loop to copy the figure into the buffer array
                    for (int y = 0; y < objectOfPlayer.ByteHateurFigureMaximal; y++)
                    {
                        for (int x = 0; x < objectOfPlayer.ByteHateurFigureMaximal; x++)
                        {
                            // directly roate while looping ad undo the rotation
                            tab_labBufferCopyLabel[objectOfPlayer.ByteHateurFigureMaximal - 1 - y, x] = objectOfPlayer.Tab_bufferLabelRota[x, y];
                        }
                    }
                }
                else
                {
                    // loop to copy the figure into the buffer array
                    for (int y = 0; y < objectOfPlayer.ByteHateurFigureMaximal; y++)
                    {
                        for (int x = 0; x < objectOfPlayer.ByteHateurFigureMaximal; x++)
                        {
                            // directly roate while looping and because it only need 2 different position, we can use the same loop to rotate
                            tab_labBufferCopyLabel[y, objectOfPlayer.ByteHateurFigureMaximal - 1 - x] = objectOfPlayer.Tab_bufferLabelRota[x, y];
                        }
                    }
                }

                // check if the rotation is possible
                if (rotationObjetJoueurIsLegal(tab_labBufferCopyLabel))
                {
                    for (int y = 0; y < objectOfPlayer.ByteHateurFigureMaximal; y++)
                    {
                        for (int x = 0; x < objectOfPlayer.ByteHateurFigureMaximal; x++)
                        {
                            // copy the bufer to the original array
                            objectOfPlayer.Tab_bufferLabelRota[x, y] = tab_labBufferCopyLabel[x, y];

                            // move every label who are in the original label
                            if (objectOfPlayer.Tab_bufferLabelRota[x, y] != null)
                            {
                                objectOfPlayer.Tab_bufferLabelRota[x, y].Location = new Point(x * G_BYTEWIDTHANDHEIGHTBLOCKS + objectOfPlayer.IntPosFigureAxeX, y * G_BYTEWIDTHANDHEIGHTBLOCKS + objectOfPlayer.IntPosFigureAxeY);
                            }
                        }
                    }
                }
                else
                {
                    // else nullify the array
                    tab_labBufferCopyLabel = null;
                }
            }
        }

        /// <summary>
        /// check if the player can rotate and is still in the playable zone or does not rotate into a figure
        /// </summary>
        /// <param name="labelRotated"> the array of the labels who was rotaded </param>
        /// <returns> return if player can rotate here </returns>
        private bool rotationObjetJoueurIsLegal(Label[,] labelRotated)
        {
            // loop to check the array
            for (int y = 0; y < objectOfPlayer.ByteHateurFigureMaximal; y++)
            {
                for (int x = 0; x < objectOfPlayer.ByteHateurFigureMaximal; x++)
                {
                    if (labelRotated[x, y] != null)
                    {
                        // check if is the playable zone and does not go into other figures
                        if (x * G_BYTEWIDTHANDHEIGHTBLOCKS + objectOfPlayer.IntPosFigureAxeX < 0 || x * G_BYTEWIDTHANDHEIGHTBLOCKS + objectOfPlayer.IntPosFigureAxeX >= panZoneJeu.Width ||
                            y * G_BYTEWIDTHANDHEIGHTBLOCKS + objectOfPlayer.IntPosFigureAxeY < 0 || y * G_BYTEWIDTHANDHEIGHTBLOCKS + objectOfPlayer.IntPosFigureAxeY >= panZoneJeu.Height ||
                            g_tab_labCarreInGame[(x * G_BYTEWIDTHANDHEIGHTBLOCKS + objectOfPlayer.IntPosFigureAxeX) / G_BYTEWIDTHANDHEIGHTBLOCKS, (y * G_BYTEWIDTHANDHEIGHTBLOCKS + objectOfPlayer.IntPosFigureAxeY) / G_BYTEWIDTHANDHEIGHTBLOCKS] != null)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }


        ///////////////////////////////////////////////


        /// <summary>
        /// check if a line was completed
        /// </summary>
        private void verifLigne()
        {
            bool isLineComplete = false;

            // check for every line if one is competed
            for (int y = G_BYTETAILLETABAXEY - 1; y >= 0; y--, isLineComplete = false)
            {
                for (int x = 0; x < G_BYTETAILLETABAXEX; x++, isLineComplete = true)
                {
                    // break if found a case without label
                    if (g_tab_labCarreInGame[x, y] == null)
                    {
                        isLineComplete = false;
                        break;
                    }
                }

                // if he find a line completed dispose every label from it
                if (isLineComplete)
                {
                    removeLigne(y);
                }
            }
        }

        /// <summary>
        /// dispose and nullify the object on the line who was completed
        /// </summary>
        /// <param name="y"> the Y axis where the line is completed </param>
        private void removeLigne(int y)
        {
            // add score to complete a line
            ajoutCompteurScoreLignes(1000, 1);

            for (int x = 0; x < G_BYTETAILLETABAXEX; x++)
            {
                if (!this.IsDisposed)
                {
                    // if i dispose AND nullify its because i don't know why but when i use my block to move every label down it just keep seeing that the label still exist
                    Invoke(new Action(() => g_tab_labCarreInGame[x, y].Dispose()));
                    g_tab_labCarreInGame[x, y] = null;
                }
                else
                {
                    return;
                }
            }
        }


        ////////////////////////////////////////////////


        /// <summary>
        /// this block will check if a line is empty and labels are floating
        /// </summary>
        private async Task checkBlockFlotant()
        {
            await Task.Run(() =>
            {
                bool boolIsLineEmpty = false;

                // loop through every line and check if there is a empty line with labels above
                for (int y = G_BYTETAILLETABAXEY - 1; y >= 1; boolIsLineEmpty = true, y--)
                {
                    for (int x = 0; x < G_BYTETAILLETABAXEX; x++, boolIsLineEmpty = true)
                    {
                        if (g_tab_labCarreInGame[x, y] != null)
                        {
                            boolIsLineEmpty = false;
                            break;
                        }
                    }

                    if (boolIsLineEmpty && y != 0)
                    {
                        // check if the colum above have label
                        for (int x = 0; x < G_BYTETAILLETABAXEX; x++)
                        {
                            if (g_tab_labCarreInGame[x, y - 1] != null)
                            {
                                moveObjetFlotant(y);

                                // if i reset the Y location is because there is maybe 2 line that are empty ( or more )
                                y = G_BYTETAILLETABAXEY;
                                break;
                            }
                        }
                    }
                }
            });
        }

        /// <summary>
        /// this block will make all the label above and on the Y axis go down of 30 pixel
        /// </summary>
        /// <param name="y"> the Y axis where you need to start moving down the labels </param>
        private void moveObjetFlotant(int y)
        {
            // move every item on the Y axis and above one block below ( 30 px )
            for (; y >= 0; y--)
            {
                for (int x = 0; x < G_BYTETAILLETABAXEX; x++)
                {
                    if (g_tab_labCarreInGame[x, y] != null)
                    {
                        Label item = g_tab_labCarreInGame[x, y];
                        g_tab_labCarreInGame[x, y] = null;

                        Invoke(new Action(() => item.Location = new Point(item.Location.X, item.Location.Y + G_BYTEWIDTHANDHEIGHTBLOCKS)));

                        g_tab_labCarreInGame[x, y + 1] = item;
                    }
                }
            }
        }

        /// <summary>
        /// This is the main loop, it's here that the gravity of the player object take place, and that here that the second thread is break
        /// There is other things that happen, for example the check if the player lost, or the continuation of the second thread with the verification if the player has completed a line, and the spawn of a new object
        /// </summary>
        /// <param name="source"> timer </param>
        /// <param name="e"> ElapsedEventArgs </param>
        private async void onUpdateAsync(object source, ElapsedEventArgs e)
        {
            // check if the player hit the bottom, left, right or object
            if (!objectOfPlayer.List_labFigureJoueur[0].IsDisposed && !g_boolStopThread && objectOfPlayer.List_labFigureJoueur.Count != 0 &&

                objectOfPlayer.List_labFigureJoueur[0].Location.Y + G_BYTEWIDTHANDHEIGHTBLOCKS < panZoneJeu.Height &&
                objectOfPlayer.List_labFigureJoueur[1].Location.Y + G_BYTEWIDTHANDHEIGHTBLOCKS < panZoneJeu.Height &&
                objectOfPlayer.List_labFigureJoueur[2].Location.Y + G_BYTEWIDTHANDHEIGHTBLOCKS < panZoneJeu.Height &&
                objectOfPlayer.List_labFigureJoueur[3].Location.Y + G_BYTEWIDTHANDHEIGHTBLOCKS < panZoneJeu.Height &&

                g_tab_labCarreInGame[objectOfPlayer.List_labFigureJoueur[0].Location.X / G_BYTEWIDTHANDHEIGHTBLOCKS, objectOfPlayer.List_labFigureJoueur[0].Location.Y / G_BYTEWIDTHANDHEIGHTBLOCKS + 1] == null &&
                g_tab_labCarreInGame[objectOfPlayer.List_labFigureJoueur[1].Location.X / G_BYTEWIDTHANDHEIGHTBLOCKS, objectOfPlayer.List_labFigureJoueur[1].Location.Y / G_BYTEWIDTHANDHEIGHTBLOCKS + 1] == null &&
                g_tab_labCarreInGame[objectOfPlayer.List_labFigureJoueur[2].Location.X / G_BYTEWIDTHANDHEIGHTBLOCKS, objectOfPlayer.List_labFigureJoueur[2].Location.Y / G_BYTEWIDTHANDHEIGHTBLOCKS + 1] == null &&
                g_tab_labCarreInGame[objectOfPlayer.List_labFigureJoueur[3].Location.X / G_BYTEWIDTHANDHEIGHTBLOCKS, objectOfPlayer.List_labFigureJoueur[3].Location.Y / G_BYTEWIDTHANDHEIGHTBLOCKS + 1] == null)
            {
                // deplacment of object and incrementation of the Y axis
                deplacementObjet(0, G_BYTEWIDTHANDHEIGHTBLOCKS, false);
                objectOfPlayer.IntPosFigureAxeY += G_BYTEWIDTHANDHEIGHTBLOCKS;
            }
            else
            {
                // stop the timer, incremente the number of figure spawned and incremente player score
                graviteTimer.Stop();
                ++g_byteFiguresSpawnCount;
                ajoutCompteurScoreLignes(100, 0);

                // check if the player stop playing
                if (!g_boolStopThread)
                {
                    // reset of variables
                    objectOfPlayer.BoolCanPlayerMoveObject = true;
                    graviteTimer.Interval = g_shrtIntervalTimer;

                    // put in the array the labels
                    foreach (Label item in objectOfPlayer.List_labFigureJoueur)
                    {
                        g_tab_labCarreInGame[item.Location.X / item.Width, item.Location.Y / item.Height] = item;
                    }

                    // if the number of item spawed, level is incremented of one and the timer is shorten
                    if (g_byteFiguresSpawnCount == 10)
                    {
                        g_byteFiguresSpawnCount = 0;
                        Invoke(new Action(() => lblLevel.Text = "Niveau : " + (++g_byteLvlJoueur + 1).ToString()));

                        if (g_shrtIntervalTimer > 0)
                        {
                            g_shrtIntervalTimer -= Convert.ToInt16((75 * g_fltDifficulteJoueur));
                        }
                    }

                    // check if there is completed line and/or empty lines, yes its not optimised
                    verifLigne();
                    await checkBlockFlotant();

                    // spawn the next figure
                    spawnFigureRandomReserve();
                }
            }
        }

        /// <summary>
        /// this block will make run the final form on a new thread
        /// </summary>
        private void runFinalForm()
        {
            if (!g_boolStopThread)
            {
                // start the last form on a new thread
                Thread g_threadFin = new Thread(launchEnd);
                g_threadFin.SetApartmentState(ApartmentState.STA);
                g_threadFin.Start();

                g_boolStopThread = true;
            }
        }

        /// <summary>
        /// this block make run the final form, dispose the actual form and dipose the music if the player wanted it
        /// </summary>
        private void launchEnd()
        {
            // check if music was launched
            if (g_boolDoesPlayerWantMusic)
            {
                musiqueTetris.Stop();
            }

            // dispose actual form
            Invoke(new Action(() => this.Dispose()));

            // run new form
            Application.Run(new formFin());
        }

        /// <summary>
        /// this block will add points to the player score
        /// </summary>
        /// <param name="pointAjouter"> point to add to the player score </param>
        /// <param name="ligneAjouter"> line to add that the player destroyed </param>
        private void ajoutCompteurScoreLignes(int pointAjouter, byte ligneAjouter)
        {
            // add score
            if (pointAjouter != 0 && !g_boolStopThread)
            {
                g_uint64ScoreJoueur += (ulong)pointAjouter;
                Invoke(new Action(() => lblPlayerScore.Text = "Score : " + g_uint64ScoreJoueur.ToString()));
            }
            // add number of line completed
            if (ligneAjouter != 0 && !g_boolStopThread)
            {
                g_intNbrLignesJoueur += ligneAjouter;
                Invoke(new Action(() => lblLignes.Text = "Lignes : " + g_intNbrLignesJoueur.ToString()));
            }
        }
    }
}
