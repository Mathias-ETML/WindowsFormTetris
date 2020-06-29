namespace projetTetris
{
    class VariablesEntreForm
    {
        public static string g_strNomJoueurInput = "";
        public static byte g_byteLvlJoueur = 0;
        public static System.UInt64 g_uint64ScoreJoueur = 0;
        public static int g_intNbrLignesJoueur = 0;

        public static float g_fltDifficulteJoueur = 1.0f;
        public static bool g_boolDoesPlayerWantMusic = false;

        public static bool g_boolSoftColorsEnabled = false;
        public static System.Collections.Generic.List<System.Threading.Thread> g_listThread = new System.Collections.Generic.List<System.Threading.Thread>();
    }
}
