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
            Dictionary<int, TAG_Compound> sections = new Dictionary<int, TAG_Compound>();
            foreach (TAG t in (TAG[])c.Root["Level"]["Sections"])
            {
                sections.Add((byte)t["Y"], (TAG_Compound)t);
            }

            //chunk exists but all blocks are air
            if (sections.Count == 0)
                return;

            for (int z = 0; z < 16; z++)
            {
                for (int x = 0; x < 16; x++)
                {
                    int height = heightmap[z * 16 + x];

                    //trees runnning into the old height limit in converted worlds
                    //seem to cause the heightmap entries for its columns to be -128;
                    if (height < 0)
                        height = 128;

                    int sectionIndex = (int)Math.Floor((height - 1) / 16.0);
                    int sectionAboveIndex = (int)Math.Floor(height / 16.0);

                    int block = -1, damage = -1;
                    if (sections.ContainsKey(sectionIndex))
                    {
                        byte[] blocks = (byte[])sections[sectionIndex]["Blocks"];
                        byte[] data = (byte[])sections[sectionIndex]["Data"];
                        int blockOffset = ((((height - 1) % 16) * 16 + z) * 16 + x);
                        block = blocks[blockOffset];
                        damage = data[(int)Math.Floor(blockOffset / 2.0)];
                        if (blockOffset % 2 == 1)
                            damage = (damage >> 4) & 0x0F;
                        else
                            damage = damage & 0x0F;
                    }

                    int blockAbove = block;
                    if (sections.ContainsKey(sectionAboveIndex))
                    {
                        int blockAboveOffset = (((height % 16) * 16 + z) * 16 + x);
                        byte[] blocksAbove = (byte[])sections[sectionAboveIndex]["Blocks"];
                        blockAbove = blocksAbove[blockAboveOffset];
                    }

                    Color color = ColorPalette.Lookup(blockAbove, 0);
                    if (color == Color.Black)
                        color = ColorPalette.Lookup(block, damage);

                    //brighten/darken by height; arbitrary value, but /seems/ to look okay
                    color = AddtoColor(color, (int)(height / 1.7 - 42));

                    b.SetPixel(offsetX + x, offsetY + z, color);
                }
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
