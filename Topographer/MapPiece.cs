using System;
using System.Drawing;
using Minecraft;

namespace Topographer
{
    public class MapPiece : IDisposable
    {
        public Bitmap Image;
        public Coord Coords;

        public MapPiece(Bitmap img, Coord c)
        {
            Image = img;
            Coords = c;
        }

        public void Dispose()
        {
            if (this.Image != null)
            {
                Image.Dispose();
                Image = null;
            }
        }
    }
}
