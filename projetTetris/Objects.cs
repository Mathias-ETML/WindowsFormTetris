using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetTetris
{
    public class Objects
    {
        // define the player actual figure
        internal class ObjectOfPlayer
        {
            public bool BoolDoesPlayerNeedFullRotation { get; set; }
            public bool BoolDidPlayerRotaded { get; set; }
            public bool BoolCanPlayerMoveObject { get; set; }

            public byte ByteHateurFigureMaximal { get; set; }
            public int IntPosFigureAxeX { get; set; }
            public int IntPosFigureAxeY { get; set; }

            public List<System.Windows.Forms.Label> List_labFigureJoueur { get; set; }
            public System.Windows.Forms.Label[,] Tab_bufferLabelRota { get; set; }

            public string StrNameOfObject { get; set; }

            // null, false, false, false, 0, 0, 0, 0, 0
            public ObjectOfPlayer(string strNameOfObject, bool boolDoesPlayerNeedFullRotation, bool boolDidPlayerRotaded, bool boolCanPlayerMoveObject, byte byteHateurFigureMaximal, byte byteLocationXLoop, byte byteLocationYLoop, int intPosFigureAxeX, int intPosFigureAxeY)
            {
                BoolDoesPlayerNeedFullRotation = boolDoesPlayerNeedFullRotation;
                BoolDidPlayerRotaded = boolDidPlayerRotaded;
                BoolCanPlayerMoveObject = boolCanPlayerMoveObject;

                ByteHateurFigureMaximal = byteHateurFigureMaximal;
                IntPosFigureAxeX = intPosFigureAxeX;
                IntPosFigureAxeY = intPosFigureAxeY;

                List_labFigureJoueur = new List<System.Windows.Forms.Label>();
                Tab_bufferLabelRota = null;

                StrNameOfObject = strNameOfObject;
            }
        }

        // define the object who is in the reserve
        internal class ObjectInReserve
        {
            public byte ByteNumFigureSpawnViaFigureReserve { get; set; }
            public List<System.Windows.Forms.Label> List_labFigureReserve { get; set; }

            public ObjectInReserve(byte byteNumFigureSpawnViaFigureReserve, int intPosFigureAxeX, int intPosFigureAxeY)
            {
                ByteNumFigureSpawnViaFigureReserve = byteNumFigureSpawnViaFigureReserve;
                List_labFigureReserve = new List<System.Windows.Forms.Label>();
            }
        }
    }

    public class Colors
    {
        /// <summary>
        /// Input an array of 4 bytes and it will return a color
        /// </summary>
        /// <param name="color"> Array of 4 bytes  </param>
        /// <returns> return a color </returns>
        public static Color ConvertByteToColor(byte[] color)
        {
            return Color.FromArgb(color[0], color[1], color[2], color[3]);
        }

        // define color of the theme
        public class GameColors
        {
            public byte[] Green { get; set; }
            public byte[] DarkGreen { get; set; }
            public byte[] Orange { get; set; }
            public byte[] Red { get; set; }
            public byte[] Blue { get; set; }
            public byte[] Pink { get; set; }
            public byte[] Yellow { get; set; }

            // init original colors
            public GameColors()
            {
                SoftColors();
            }

            // my custom colors
            public void SoftColors()
            {
                Green = new byte[] { 255, 137, 197, 65 };
                DarkGreen = new byte[] { 255, 71, 176, 75 };
                Orange = new byte[] { 255, 255, 153, 0 };
                Red = new byte[] { 255, 247, 64, 44 };
                Blue = new byte[] { 255, 63, 77, 184 };
                Pink = new byte[] { 255, 236, 21, 98 };
                Yellow = new byte[] { 255, 229, 232, 49 };
            }

            // normal colors of System.Drawing.Color
            // will return an 4 byte array of ARGB
            public void normalColors()
            {
                Green = ColorToARGB(Color.Green);
                DarkGreen = ColorToARGB(Color.DarkSeaGreen);
                Orange = ColorToARGB(Color.OrangeRed);
                Red = ColorToARGB(Color.Red);
                Blue = ColorToARGB(Color.Blue);
                Pink = ColorToARGB(Color.Pink);
                Yellow = ColorToARGB(Color.Yellow);
            }

            /// <summary>
            /// will convert a color into a 4 byte ARGB array
            /// </summary>
            /// <param name="item"> a color </param>
            /// <returns> a 4 byte ARGB array </returns>
            private byte[] ColorToARGB(Color item)
            {
                return new byte[] { item.A, item.R, item.G, item.B };
            }
        }
    }
}
