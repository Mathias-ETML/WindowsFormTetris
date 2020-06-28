using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static projetTetris.VariablesEntreForm;

namespace projetTetris
{
    public partial class formBestScores : Form
    {
        private string g_strPath = @"K:\INF\Eleves\DemoMot\CIN1A\matrogey\Scores\scores.txt";
        private const byte G_BYTENBRJOUEURSCOREAFFICHER = 5;

        public formBestScores()
        {
            InitializeComponent();

            onStart();
        }

        /// <summary>
        /// display the scores
        /// if you did better, it will place you're score in a txt file
        /// </summary>
        private void onStart()
        {
            List<string> list_strText = File.ReadLines(g_strPath).Take(G_BYTENBRJOUEURSCOREAFFICHER).ToList();
            UInt64[] tab_uint64ScoreJoueursFichier = new UInt64[G_BYTENBRJOUEURSCOREAFFICHER];
            string[] tab_strPlayerNames = new string[G_BYTENBRJOUEURSCOREAFFICHER];
            string strBuffer = "";
            sbyte byteWherePlayerBeatedOther = 6;


            for (int i = G_BYTENBRJOUEURSCOREAFFICHER - 1; i >= 0; i--)
            {
                tab_uint64ScoreJoueursFichier[i] = Convert.ToUInt64(list_strText[i].Split(',')[0]);
                tab_strPlayerNames[i] = list_strText[i].Split(',')[1];
            }

            list_strText = null;

            for (int i = G_BYTENBRJOUEURSCOREAFFICHER - 1; i >= 0; i--)
            {
                if (tab_uint64ScoreJoueursFichier[i] < g_uint64ScoreJoueur)
                {
                    byteWherePlayerBeatedOther = (sbyte)i;
                    tab_uint64ScoreJoueursFichier[i] = g_uint64ScoreJoueur;
                    tab_strPlayerNames[i] = g_strNomJoueurInput;
                    break;
                }
            }

            for (int i = G_BYTENBRJOUEURSCOREAFFICHER - 1; i >= 0; i--)
            {
                if (i == byteWherePlayerBeatedOther)
                {
                    strBuffer += "Vous ! : " + g_uint64ScoreJoueur.ToString() + "\n";
                }
                else
                {
                    strBuffer += tab_strPlayerNames[i] + " : " + tab_uint64ScoreJoueursFichier[i].ToString() + "\n";
                }
            }

            if (byteWherePlayerBeatedOther == 6)
            {
                strBuffer += "\n\n" + g_strNomJoueurInput + " : " + g_uint64ScoreJoueur.ToString();
            }
            else
            {
                File.WriteAllText(g_strPath, String.Empty);

                using (StreamWriter sw = new StreamWriter(g_strPath, true))
                {
                    for (int i = 0; i < G_BYTENBRJOUEURSCOREAFFICHER; i++)
                    {
                        sw.WriteLine(tab_uint64ScoreJoueursFichier[i].ToString() + "," + tab_strPlayerNames[i]);
                    }
                }
            }

            lblScore.Text = strBuffer;
        }
    }
}
