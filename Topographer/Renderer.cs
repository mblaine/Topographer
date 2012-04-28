using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using Minecraft;
using Topographer.PNG;

namespace Topographer
{
    public class Renderer
    {
        public delegate void UpdateStatus(String s);
        private UpdateStatus updateStatus = null;

        public delegate void DoneCallback();
        private DoneCallback callback = null;

        private TextWriter log = null;

        private const int REGIONWIDTH = 512;
        private const int REGIONHEIGHT = 512;

        private String regionDir;
        private String outPath;

        public int LowerLimit = 0;
        public int UpperLimit = 255;
        public bool ConsiderBiomes = true;
        public bool ShowHeight = true;
        public bool Transparency = true;
        public bool BiomeOverlay = false;
        public bool CropMap = true;
        public uint Rotate = 0;

        public bool LowerMemory = true;

        public HashSet<byte> Only = null;
        public HashSet<byte> Exclude = null;

        public Renderer(String regionDir, String outPath, UpdateStatus updateStatus = null, DoneCallback callback = null)
        {
            this.regionDir = regionDir;
            this.outPath = outPath;
            this.updateStatus = updateStatus;
            this.callback = callback;
        }

        public Renderer(String regionDir, String outPath, TextWriter log = null)
        {
            this.regionDir = regionDir;
            this.outPath = outPath;
            this.log = log;
        }

        public void Render()
        {
            Point topLeft = new Point(int.MaxValue, int.MaxValue);
            Point bottomRight = new Point(int.MinValue, int.MinValue);

            if (LowerLimit > UpperLimit)
            {
                int temp = LowerLimit;
                LowerLimit = UpperLimit;
                UpperLimit = temp;
            }

            if (Only != null && Exclude != null)
            {
                foreach (byte b in Exclude)
                {
                    if (Only.Contains(b))
                        Only.Remove(b);
                }
                Exclude = null;
            }

            String[] paths = Directory.GetFiles(regionDir, "*.mca", SearchOption.TopDirectoryOnly);
            
            foreach (String path in paths)
            {
                Match m = Regex.Match(path, @"r\.(-?\d+)\.(-?\d+)\.mc[ar]");
                Coord c = new Coord(int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value));
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

            String format = String.Format("Reading region {{0}} of {0}", paths.Length);
            int count = 0;

            if (LowerMemory)
            {
                int regionsWide = (bottomRight.X - topLeft.X) / REGIONWIDTH;
                int regionsTall = (bottomRight.Y - topLeft.Y) / REGIONHEIGHT;
                Point regionTopLeft = new Point(topLeft.X / REGIONWIDTH, topLeft.Y / REGIONHEIGHT);
                String[,] regions = new String[regionsWide, regionsTall];

                foreach (String path in paths)
                {
                    Match m = Regex.Match(path, @"r\.(-?\d+)\.(-?\d+)\.mc[ar]");
                    Coord c = new Coord(int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value));
                    c.Add(-regionTopLeft.X, -regionTopLeft.Y);
                    regions[c.X, c.Z] = path;
                }

                Bitmap strip = new Bitmap(bottomRight.X - topLeft.X, REGIONHEIGHT, PixelFormat.Format32bppArgb);
                PngWriter writer = new PngWriter(outPath, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);

                for (int y = 0; y < regionsTall; y++)
                {
                    using (Graphics g = Graphics.FromImage(strip))
                    {
                        g.Clear(Color.Transparent);
                    }

                    for (int x = 0; x < regionsWide; x++)
                    {
                        if (regions[x, y] != null)
                        {
                            count++;
                            if (updateStatus != null)
                                updateStatus(String.Format(format, count));
                            if (log != null)
                            {
                                log.Write(String.Format(format, count));
                                log.WriteLine(String.Format(" :: {0}", Path.GetFileName(regions[x, y])));
                            }

                            RegionFile region = new RegionFile(regions[x, y]);
                            Coord offset = new Coord(region.Coords);
                            offset.RegiontoAbsolute();
                            offset.X -= topLeft.X;

                            if (BiomeOverlay)
                                RenderRegionBiomes(region, strip, offset.X, 0);
                            else
                                RenderRegion(region, strip, offset.X, 0);
                        }
                    }
                    writer.WriteBitmap(strip);
                }

                writer.Close();
                strip.Dispose();
            }
            else
            {
                Bitmap map = new Bitmap(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
                foreach (String path in paths)
                {
                    count++;
                    if (updateStatus != null)
                        updateStatus(String.Format(format, count));
                    if (log != null)
                    {
                        log.Write(String.Format(format, count));
                        log.WriteLine(String.Format(" :: {0}", Path.GetFileName(path)));
                    }
                    RegionFile region = new RegionFile(path);
                    Coord offset = new Coord(region.Coords);
                    offset.RegiontoAbsolute();
                    offset.Add(-topLeft.X, -topLeft.Y);

                    if (BiomeOverlay)
                        RenderRegionBiomes(region, map, offset.X, offset.Z);
                    else
                        RenderRegion(region, map, offset.X, offset.Z);
                }

                if (CropMap)
                    map = Crop(map);
                Rotate = (Rotate % 360) / 90;
                if (Rotate == 1)
                    map.RotateFlip(RotateFlipType.Rotate90FlipNone);
                else if (Rotate == 2)
                    map.RotateFlip(RotateFlipType.Rotate180FlipNone);
                else if (Rotate == 3)
                    map.RotateFlip(RotateFlipType.Rotate270FlipNone);

                map.Save(outPath, ImageFormat.Png);
                map.Dispose();

            }
            
            if (updateStatus != null)
                updateStatus("Done");
            if (log != null)
                log.WriteLine("Done");
            if (callback != null)
                callback();
        }

        private Bitmap RenderRegion(RegionFile region, Bitmap b, int offsetX, int offsetY)
        {
            foreach (Chunk c in region.Chunks)
            {
                if (c == null || c.Root == null)
                    continue;
                Coord chunkOffset = new Coord(c.Coords);
                chunkOffset.ChunktoRegionRelative();
                chunkOffset.ChunktoAbsolute();
                RenderChunk(c, b, offsetX + chunkOffset.X, offsetY + chunkOffset.Z);
            }

            return b;
        }

        private void RenderChunk(Chunk c, Bitmap b, int offsetX, int offsetY)
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

            highest = ((highest + 1) * 16) - 1;
            if (highest > UpperLimit)
                highest = UpperLimit;
            if (highest < LowerLimit)
                highest = LowerLimit;

            for (int z = 0; z < 16; z++)
            {
                for (int x = 0; x < 16; x++)
                {
                    int y = GetHeight(sections, x, z, highest, LowerLimit, Only, Exclude);
                    if (y < LowerLimit)
                        continue;
                    byte id, data;
                    GetBlock(sections, x, y, z, out id, out data);
                    byte biome = 255;
                    if(ConsiderBiomes)
                        biome = ((byte[])c.Root["Level"]["Biomes"])[x + z * 16];
                    
                    Color color = ColorPalette.Lookup(id, data, biome);

                    if (Transparency)
                    {
                        y--;
                        while (color.A < 255 && y >= LowerLimit)
                        {
                            GetBlock(sections, x, y, z, out id, out data);
                            if (Only != null && !Only.Contains(id))
                                id = 0;
                            if (Exclude != null && Exclude.Contains(id))
                                id = 0;
                            Color c2 = ColorPalette.Lookup(id, data, biome);
                            color = Blend(color, c2);
                            y--;
                        }
                    }
                    else
                        color = Color.FromArgb(255, color.R, color.G, color.B);

                    if (ShowHeight)
                    {
                        //brighten/darken by height; arbitrary value, but /seems/ to look okay
                        color = AddtoColor(color, (int)(y / 1.7 - 42));
                    }

                    b.SetPixel(offsetX + x, offsetY + z, color);
                }
            }
        }

        private Bitmap RenderRegionBiomes(RegionFile region, Bitmap b, int offsetX, int offsetY)
        {
            foreach (Chunk c in region.Chunks)
            {
                if (c == null || c.Root == null)
                    continue;
                Coord chunkOffset = new Coord(c.Coords);
                chunkOffset.ChunktoRegionRelative();
                chunkOffset.ChunktoAbsolute();
                RenderChunkBiomes(c, b, offsetX + chunkOffset.X, offsetY + chunkOffset.Z);
            }

            return b;
        }

        private void RenderChunkBiomes(Chunk c, Bitmap b, int offsetX, int offsetY)
        {
            byte[] biomes = (byte[])c.Root["Level"]["Biomes"];

            for (int z = 0; z < 16; z++)
            {
                for (int x = 0; x < 16; x++)
                {
                    byte biome = biomes[x + z * 16];
                    Color color = ColorPalette.Lookup(biome);
                    b.SetPixel(offsetX + x, offsetY + z, color);
                }
            }
        }

        private static int GetHeight(TAG_Compound[] sections, int x, int z, int yStart = 255, int yEnd = 0, HashSet<byte> only = null, HashSet<byte> exclude = null)
        {
            int h = yStart;
            for (; h >= yEnd; h--)
            {
                byte b = GetBlock(sections, x, h, z);
                if (b != 0)
                {
                    if(only != null && only.Contains(b))
                        return h;
                    else if(exclude != null && !exclude.Contains(b))
                        return h;
                    else if(only == null && exclude == null)
                        return h;
                }
            }
            return yEnd - 1;
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

        private static byte GetLight(TAG_Compound[] sections, int x, int y, int z)
        {
            byte light = 15;

            int section = (int)Math.Floor(y / 16.0);

            if (sections[section] != null)
            {
                int offset = ((y % 16) * 16 + z) * 16 + x;
                light = ((byte[])sections[section]["BlockLight"])[offset >> 1];
                if (offset % 2 == 0)
                    light = (byte)(light & 0x0F);
                else
                    light = (byte)((light >> 4) & 0x0F);
            }

            if (light > 15)
                light = 15;
            else if (light < 4)
                light = 4;
            return light;
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

            double a1 = c1.A / 255.0;
            double a2 = c2.A / 255.0;
            a2 *= (1.0 - a1);
            double a = a1 + a2;

            int r = (int)(c1.R * a1 + c2.R * a2);
            int g = (int)(c1.G * a1 + c2.G * a2);
            int b = (int)(c1.B * a1 + c2.B * a2);
            a *= 255;
            
            if (c1.A == 255 || c2.A == 255)
                a = 255;
            return Color.FromArgb((int)a, r, g, b);
        }

        private static Bitmap Crop(Bitmap b)
        {
            int top = 0;
            int bottom = b.Height - 1;
            int left = 0;
            int right = b.Width - 1;

            bool stop = false;
            for (int y = 0; y < b.Height && !stop; y++)
            {
                for (int x = 0; x < b.Width && !stop; x++)
                {
                    if (b.GetPixel(x, y).A > 0)
                    {
                        top = y;
                        stop = true;
                        break;
                    }
                }
            }
            
            stop = false;
            for (int y = b.Height - 1; y > top && !stop; y--)
            {
                for (int x = 0; x < b.Width && !stop; x++)
                {
                    if (b.GetPixel(x, y).A > 0)
                    {
                        bottom = y + 1;
                        stop = true;
                        break;
                    }
                }
            }

            stop = false;
            for (int x = 0; x < b.Width && !stop; x++)
            {
                for(int y = 0; y < b.Height && !stop; y++)
                {
                    if (b.GetPixel(x, y).A > 0)
                    {
                        left = x;
                        stop = true;
                        break;
                    }
                }
            }

            stop = false;
            for (int x = b.Width - 1; x > left && !stop; x--)
            {
                for (int y = 0; y < b.Height && !stop; y++)
                {
                    if (b.GetPixel(x, y).A > 0)
                    {
                        right = x + 1;
                        stop = true;
                        break;
                    }
                }
            }

            Bitmap ret = b.Clone(Rectangle.FromLTRB(left, top, right, bottom), b.PixelFormat);
            b.Dispose();
            return ret;
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
