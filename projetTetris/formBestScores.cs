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
        private const string g_strPath = @"K:\INF\Eleves\DemoMot\CIN1A\matrogey\Scores\scores.txt";
        private readonly byte _g_byteNbrJoueurAfficher = (byte)File.ReadLines(g_strPath).Count();

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
            // variables
            List<string> list_strText = File.ReadLines(g_strPath).Take(_g_byteNbrJoueurAfficher).ToList();
            UInt64[] tab_uint64ScoreJoueursFichier = new UInt64[_g_byteNbrJoueurAfficher];
            string[] tab_strPlayerNames = new string[_g_byteNbrJoueurAfficher];
            string strBuffer = "";
            sbyte byteWherePlayerBeatedOther = 6;

            // take the score of each player
            for (int i = _g_byteNbrJoueurAfficher - 1; i >= 0; i--)
            {
                tab_uint64ScoreJoueursFichier[i] = Convert.ToUInt64(list_strText[i].Split(',')[0]);
                tab_strPlayerNames[i] = list_strText[i].Split(',')[1];
            }

            // optimise memory by nullifying
            list_strText = null;

            // check if the player did better that the player in the txt file
            for (int i = _g_byteNbrJoueurAfficher - 1; i >= 0; i--)
            {
                if (tab_uint64ScoreJoueursFichier[i] < g_uint64ScoreJoueur)
                {
                    byteWherePlayerBeatedOther = (sbyte)i;
                    tab_uint64ScoreJoueursFichier[i] = g_uint64ScoreJoueur;
                    tab_strPlayerNames[i] = g_strNomJoueurInput;
                    break;
                }
            }

            // build the string to show by putting the names and the score of the player in the string ( actual player included )
            for (int i = _g_byteNbrJoueurAfficher - 1; i >= 0; i--)
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

            // check if the player did better
            if (byteWherePlayerBeatedOther == 6)
            {
                strBuffer += "\n\n" + g_strNomJoueurInput + " : " + g_uint64ScoreJoueur.ToString();
            }
            // if yes will write it in the file
            else
            {
                File.WriteAllText(g_strPath, String.Empty);

                using (StreamWriter sw = new StreamWriter(g_strPath, true))
                {
                    for (int i = 0; i < _g_byteNbrJoueurAfficher; i++)
                    {
                        sw.WriteLine(tab_uint64ScoreJoueursFichier[i].ToString() + "," + tab_strPlayerNames[i]);
                    }
                }
            }

            lblScore.Text = strBuffer;
        }
    }
}
