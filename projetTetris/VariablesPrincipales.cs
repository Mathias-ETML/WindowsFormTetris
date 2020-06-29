namespace projetTetris
{
    class VariablesPrincipales
    {
        public static byte G_BYTETAILLETABAXEX = 10;
        public static byte G_BYTETAILLETABAXEY = 18;
        public static byte G_BYTEWIDTHANDHEIGHTBLOCKS = 30;

        public static System.Media.SoundPlayer musiqueTetris;
        
        public static bool g_boolStopThread = false;

        public static System.Windows.Forms.Label[,] g_tab_labCarreInGame;// = new System.Windows.Forms.Label[G_BYTETAILLETABAXEX, G_BYTETAILLETABAXEY];

        public static System.Timers.Timer graviteTimer;// = new System.Timers.Timer();
        public static short g_shrtIntervalTimer;// = 1000;

        public static byte g_byteFiguresSpawnCount;//s = 0;

        
    }
}