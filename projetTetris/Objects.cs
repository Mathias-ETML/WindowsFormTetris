using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetTetris
{
    public class Objects
    {
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

            // false, false, false, 0, 0, 0, 0, 0, null
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
}
