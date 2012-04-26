﻿using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace Topographer
{
    //http://www.libpng.org/pub/png/spec/1.2/PNG-CRCAppendix.html
    public class CRC32
    {
        private static uint[] table = null;

        private CRC32()
        {
        }

        private static void GenerateTable()
        {
            uint c;

            for (int n = 0; n < 256; n++)
            {
                c = (uint)n;
                for (int k = 0; k < 8; k++)
                {
                    if ((c & 1) == 1)
                        c = 0xedb88320 ^ (c >> 1);
                    else
                        c = c >> 1;
                }
                table[n] = c;
            }
        }

        public static uint Calculate(byte[] data)
        {
            if (table == null)
                GenerateTable();

            uint c = 0xffffffff;

            for (int n = 0; n < data.Length; n++)
            {
                c = table[(c ^ data[n]) & 0xff] ^ (c >> 8);
            }
            return c ^ 0xffffffff;
        }
    }

    public class PngWriter : IDisposable
    {
        BinaryWriter writer = null;
        bool disposed = false;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public PngWriter(String path, int width, int height)
        {
            FileStream s = new FileStream(path, FileMode.OpenOrCreate | FileMode.Truncate);
            writer = new BinaryWriter(s);
            BeginWrite(width, height);
        }

        public PngWriter(Stream s, int width, int height)
        {
            writer = new BinaryWriter(s);
            BeginWrite(width, height);
        }

        //http://www.libpng.org/pub/png/spec/1.2/PNG-Contents.html
        private void BeginWrite(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentException("Width must be greater than zero.");
            if(height <= 0)
                throw new ArgumentException("Height must be greater than zero.");

            Width = width;
            Height = height;

            writer.Write(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 });

            byte[] data = new byte[13];
            byte[] temp = BitConverter.GetBytes(width);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(temp);
            Array.Copy(temp, 0, data, 0, 4);
            
            temp = BitConverter.GetBytes(height);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(temp);
            Array.Copy(temp, 0, data, 4, 4);

            data[8] = 8; //bit depth
            data[9] = 6; //color type (rgba)
            data[10] = 0; //compression method (deflate)
            data[11] = 0; //filter method (adaptive)
            data[12] = 0; //interlace method (nnone)

            WriteChunk("IHDR", data);

            data = new byte[1];
            data[0] = 0; //rendering intent (perceptual)
            
            WriteChunk("sRGB", data);

            data = BitConverter.GetBytes(45455);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);

            WriteChunk("gAMA", data);
            
            data = new byte[9];
            temp = BitConverter.GetBytes(4724); //no idea, but it's what Bitmap.Save() produces
            if (BitConverter.IsLittleEndian)
                Array.Reverse(temp);

            Array.Copy(temp, 0, data, 0, 4);
            Array.Copy(temp, 0, data, 4, 4);

            data[8] = 0; //unit specifier (unknown)

            WriteChunk("pHYs", data);
        }

        private void EndWrite()
        {
            WriteChunk("IEND", new byte[0]);
        }

        private void WriteChunk(String type, byte[] data)
        {
            byte[] chunk = new byte[data.Length + 8];

            byte[] temp = BitConverter.GetBytes(data.Length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(temp);

            Array.Copy(temp, 0, chunk, 0, 4);
                
            temp = ASCIIEncoding.ASCII.GetBytes(type);

            Array.Copy(temp, 0, chunk, 4, 4);

            Array.Copy(data, 0, chunk, 8, data.Length);

            temp = BitConverter.GetBytes(CRC32.Calculate(chunk));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(temp);
            
            writer.Write(chunk);
            writer.Write(temp);
        }

        public void WriteBitmap(Bitmap b)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().FullName);

            if (b.Width != Width)
                throw new ArgumentException(String.Format("The width of the supplied bitmap ({0}) must match the width of the output png ({1}).", b.Width, Width));
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().FullName);

            EndWrite();

            if (writer != null)
                writer.Dispose();
            
            disposed = true;
        }
    }
}