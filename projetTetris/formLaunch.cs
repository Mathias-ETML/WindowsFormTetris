using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using static projetTetris.VariablesEntreForm;

namespace projetTetris
{
    public partial class formLaunch : Form
    {
        public formLaunch()
        {
            InitializeComponent();

            onStart();
        }

        /// <summary>
        /// check if the file at the path exist
        /// </summary>
        private void onStart()
        {
            // yes the file is on a server but i am gonna put it in the ressource ( if i can )
            if (!File.Exists(@"K:\INF\Eleves\DemoMot\CIN1A\matrogey\Scores\musiqueTetris.wav"))
            {
                checkBoxMusique.Visible = false;
            }

            g_listThread.Add(Thread.CurrentThread);
        }

        /// <summary>
        /// Take the player name if its valid and launch the game on a new thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJoueurInputNom_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtBoxInputJoueur.Text))
            {
                // prends le input du joueur
                g_strNomJoueurInput = txtBoxInputJoueur.Text;

                setColor();

                // demare le jeu sur un nouveau thread
                Thread g_threadSecondForm = new Thread(launchGame);
                g_threadSecondForm.SetApartmentState(ApartmentState.STA);
                g_threadSecondForm.Start();
            }
            else
            {
                // montre que c'est pas bien de ne pas mettre de texte
                MessageBox.Show("Entrez un nom valide !");
                txtBoxInputJoueur.Text = "";
            }
        }

        /// <summary>
        /// launch the game and dispose this form
        /// </summary>
        private void launchGame()
        {
            Invoke(new Action(() => this.Dispose()));

            // nom de la methode assez explicite je pense
            Application.Run(new formJeu());
        }

        /// <summary>
        /// check if the user pressed enter while he was writing his name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputUser(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnJoueurInputNom_Click(null, null);
            }
        }

        /// <summary>
        /// change the other check box to be not checked and change the difficulty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxFacile_CheckedChanged(object sender, EventArgs e)
        {
            g_fltDifficulteJoueur = 0.75f;
            checkBoxMoyen.Checked = false;
            checkBoxDifficile.Checked = false;
        }

        /// <summary>
        /// change the other check box to be not checked and change the difficulty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxMoyen_CheckedChanged(object sender, EventArgs e)
        {
            g_fltDifficulteJoueur = 1f;
            checkBoxFacile.Checked = false;
            checkBoxDifficile.Checked = false;
        }

        /// <summary>
        /// change the other check box to be not checked and change the difficulty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxDifficile_CheckedChanged(object sender, EventArgs e)
        {
            g_fltDifficulteJoueur = 1.25f;
            checkBoxFacile.Checked = false;
            checkBoxMoyen.Checked = false;
        }

        /// <summary>
        /// make you're check box checked
        /// </summary>
        /// <param name="sender"> the ckeck box </param>
        /// <param name="e"></param>
        private void checkBoxChangeCheck(object sender, EventArgs e)
        {
            ((CheckBox)sender).Checked = true;
        }

        /// <summary>
        /// change the boolean if the player want music if the check box change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxMusique_CheckedChanged(object sender, EventArgs e)
        {
            if (!g_boolDoesPlayerWantMusic)
            {
                g_boolDoesPlayerWantMusic = true;
            }
            else
            {
                g_boolDoesPlayerWantMusic = false;
            }
        }

        /// <summary>
        /// check if played want dark mode friendly
        /// </summary>
        private void setColor()
        {
            if (checkBoxSoftColor.Checked)
            {
                g_boolSoftColorsEnabled = true;
            }
        }

        /// <summary>
        /// show the controls
        /// </summary>
        /// <param name="sender"> button </param>
        /// <param name="e"> EventArgs </param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deplacement : Flèche droite et gauche" +
                "\nRotation : R" +
                "\nDrop : Espace" +
                "\nHelp : Escape ou H");
        }
    }
}
