using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Minecraft;

namespace Topographer
{
    public class Renderer
    {
        public delegate void UpdateStatus(String s);
        private UpdateStatus updateStatus;

        public delegate void DoneCallback();
        DoneCallback callback;

        private const int REGIONWIDTH = 512;
        private const int REGIONHEIGHT = 512;

        private String regionDir;
        private String outPath;

        public Renderer(String regionDir, String outPath, UpdateStatus updateStatus = null, DoneCallback callback = null)
        {
            this.regionDir = regionDir;
            this.outPath = outPath;
            this.updateStatus = updateStatus;
            this.callback = callback;
        }

        public void Render()
        {
            List<MapPiece> pieces = new List<MapPiece>();
            Point topLeft = new Point(int.MaxValue, int.MaxValue);
            Point bottomRight = new Point(int.MinValue, int.MinValue);

            String[] paths = Directory.GetFiles(regionDir, "*.mca", SearchOption.TopDirectoryOnly);
            String format = String.Format("Reading region {{0}} of {0}", paths.Length);
            int count = 0;
            foreach (String path in paths)
            {
                count++;
                if (updateStatus != null)
                    updateStatus(String.Format(format, count));
                RegionFile region = new RegionFile(path);
                pieces.Add(new MapPiece(RenderRegion(region), region.Coords));

                Coord c = new Coord(region.Coords);
                c.RegiontoAbsolute();
                if (c.X < topLeft.X)
                    topLeft.X = c.X;
                if (c.Z < topLeft.Y)
                    topLeft.Y = c.Z;
                c.Add(REGIONWIDTH, REGIONHEIGHT);
                if (c.X > bottomRight.X)
                    bottomRight.X = c.X;
                if (c.Z > bottomRight.Y)
                    bottomRight.Y = c.Z;
            }

            Bitmap map = new Bitmap(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
            if (updateStatus != null)
                updateStatus("Combining region maps");
            using (Graphics g = Graphics.FromImage(map))
            {
                foreach (MapPiece piece in pieces)
                {
                    Coord offset = new Coord(piece.Coords);
                    offset.RegiontoAbsolute();
                    offset.Add(-topLeft.X, -topLeft.Y);
                    g.DrawImage(piece.Image, offset.X, offset.Z);
                    piece.Dispose();
                }
            }

            map.Save(outPath, ImageFormat.Png);
            map.Dispose();

            if (updateStatus != null)
                updateStatus("");
            if (callback != null)
                callback();
        }

        private Bitmap RenderRegion(RegionFile region)
        {
            Bitmap b = new Bitmap(REGIONWIDTH, REGIONHEIGHT);

            foreach (Chunk c in region.Chunks)
            {
                if (c == null || c.Root == null)
                    continue;
                Coord chunkOffset = new Coord(c.Coords);
                chunkOffset.ChunktoRegionRelative();
                chunkOffset.ChunktoAbsolute();
                RenderChunk(c, b, chunkOffset.X, chunkOffset.Z);
            }

            return b;
        }

        private static void RenderChunk(Chunk c, Bitmap b, int offsetX, int offsetY)
        {
            int[] heightmap = (int[])c.Root["Level"]["HeightMap"];
            TAG_Compound[] sections = new TAG_Compound[16];
            int highest = -1;
            foreach (TAG t in (TAG[])c.Root["Level"]["Sections"])
            {
                byte index = (byte)t["Y"];
                if (index > highest)
                    highest = index;
                sections[index] = (TAG_Compound)t;
                
            }

            //chunk exists but all blocks are air
            if (highest < 0)
                return;

            for (int z = 0; z < 16; z++)
            {
                for (int x = 0; x < 16; x++)
                {
                    int y = GetHeight(sections, x, z, ((highest + 1) * 16) - 1);
                    byte id, data;
                    GetBlock(sections, x, y, z, out id, out data);
                    
                    Color color = ColorPalette.Lookup(id, data);

                    y--;
                    while (color.A < 255 && y >= 0)
                    {
                        GetBlock(sections, x, y, z, out id, out data);
                        Color c2 = ColorPalette.Lookup(id, data);
                        color = Blend(color, c2);
                        y--;
                    }
                    
                    //brighten/darken by height; arbitrary value, but /seems/ to look okay
                    color = AddtoColor(color, (int)(y / 1.7 - 42));

                    b.SetPixel(offsetX + x, offsetY + z, color);
                }
            }
        }

        private static int GetHeight(TAG_Compound[] sections, int x, int z, int yStart = 255)
        {
            int h = yStart;
            for (; h > 0; h--)
            {
                if (GetBlock(sections, x, h, z) != 0)
                {
                    return h;
                }
            }
            return h;
        }

        private static byte GetBlock(TAG_Compound[] sections, int x, int y, int z)
        {
            byte id, data;
            GetBlock(sections, x, y, z, out id, out data);
            return id;
        }

        private static void GetBlock(TAG_Compound[] sections, int x, int y, int z, out byte id, out byte data)
        {
            id = 0;
            data = 0;
            int section = (int)Math.Floor(y / 16.0);

            if (sections[section] != null)
            {
                int offset = ((y % 16) * 16 + z) * 16 + x;
                id = ((byte[])sections[section]["Blocks"])[offset];
                data = ((byte[])sections[section]["Data"])[offset >> 1];
                if (offset % 2 == 0)
                    data = (byte)(data & 0x0F);
                else
                    data = (byte)((data >> 4) & 0x0F);
            }
        }

        private static Color AddtoColor(Color c, int diff)
        {
            int red = c.R + diff;
            if (red > 255)
                red = 255;
            else if (red < 0)
                red = 0;
            int green = c.G + diff;
            if (green > 255)
                green = 255;
            else if (green < 0)
                green = 0;
            int blue = c.B + diff;
            if (blue > 255)
                blue = 255;
            else if (blue < 0)
                blue = 0;
            return Color.FromArgb(c.A, red, green, blue);
        }

        private static Color Blend(Color c1, Color c2)
        {
            if (c2.A == 0)
                return c1;
            else if(c1.A == 0)
                return c2;

            int a = (c1.A + c2.A) / 2;
            if (c1.A == 255 || c2.A == 255)
                a = 255;
            int r = (c1.R + c2.R) / 2;
            int g = (c1.G + c2.G) / 2;
            int b = (c1.B + c2.B) / 2;
            return Color.FromArgb(a, r, g, b);
        }

        public static int GetRegionCount(String regionDir)
        {
            try
            {
                return Directory.GetFiles(regionDir, "*.mca", SearchOption.TopDirectoryOnly).Length;
            }
            catch (DirectoryNotFoundException)
            {
                return 0;
            }
        }
    }
}
