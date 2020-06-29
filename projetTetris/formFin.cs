using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using static projetTetris.VariablesEntreForm;

namespace projetTetris
{
    public partial class formFin : Form
    {
        public formFin()
        {
            InitializeComponent();

            onStart();
        }

        /// <summary>
        /// init the player name, level, score and line completed
        /// show the best scores
        /// </summary>
        private void onStart()
        {
            lblNomJoueur.Text += g_strNomJoueurInput;
            lblLvlJoueur.Text += (g_byteLvlJoueur + 1).ToString();
            lblScore.Text += g_uint64ScoreJoueur.ToString();
            lblNbrLignes.Text += g_intNbrLignesJoueur.ToString();

            g_listThread.Add(Thread.CurrentThread);

            // yes the file is on a server but i am gonna put it in the ressource ( if i can )
            if (File.Exists(@"K:\INF\Eleves\DemoMot\CIN1A\matrogey\Scores\scores.txt"))
            {
                launchScores();
            }
        }

        /// <summary>
        /// show the best scores
        /// </summary>
        private void launchScores()
        {
            Application.Run(new formBestScores());
        }

        /// <summary>
        /// abort each thread !! except this one !! an relaunch the game
        /// </summary>
        /// <param name="sender"> button </param>
        /// <param name="e"> EventArgs </param>
        private void btnRestart_Click(object sender, EventArgs e)
        {
            Thread threadRestart = new Thread(() => Application.Run(new formLaunch()));
            threadRestart.SetApartmentState(ApartmentState.STA);
            threadRestart.Start();

            for (int i = 0; i < g_listThread.Count - 1; i++)
            {
                g_listThread[i].Abort();
            }

            this.Dispose();
        }
    }
}
