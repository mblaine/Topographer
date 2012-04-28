using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Ionic.Zlib;
using System.Runtime.InteropServices;

namespace Topographer.PNG
{
    public class PngWriter : IDisposable
    {
        private BinaryWriter writer = null;
        private bool disposed = false;

        private ZlibStream zstream = null;
        private DataStream dstream = null;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public PngWriter(String path, int width, int height)
        {
            FileStream s = File.Exists(path) ? File.Open(path, FileMode.Truncate) : File.Open(path, FileMode.Create);
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
            data[12] = 0; //interlace method (none)

            WriteChunk("IHDR", data);

            data = new byte[1];
            data[0] = 0; //rendering intent (perceptual)
            
            WriteChunk("sRGB", data);

            data = BitConverter.GetBytes(45455);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);

            WriteChunk("gAMA", data);
            
            data = new byte[9];
            temp = BitConverter.GetBytes(3779); //pixels per meter at 96 dpi
            if (BitConverter.IsLittleEndian)
                Array.Reverse(temp);

            Array.Copy(temp, 0, data, 0, 4);
            Array.Copy(temp, 0, data, 4, 4);

            data[8] = 1; //unit specifier (meter)

            WriteChunk("pHYs", data);
        }

        private void EndWrite()
        {
            if(zstream != null)
                zstream.Close();
            if(dstream != null)
                WriteChunk("IDAT", dstream.GetDataSoFar());
            WriteChunk("IEND", new byte[0]);
        }

        private void WriteChunk(String type, byte[] data)
        {
            byte[] chunk = new byte[data.Length + 4];

            byte[] length = BitConverter.GetBytes(data.Length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(length);
                
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(type);

            Array.Copy(temp, 0, chunk, 0, 4);

            Array.Copy(data, 0, chunk, 4, data.Length);

            temp = BitConverter.GetBytes(CRC32.Calculate(chunk));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(temp);

            writer.Write(length);
            writer.Write(chunk);
            writer.Write(temp);
        }

        public void WriteBitmap(Bitmap b)
        {
            if (disposed)
                throw new ObjectDisposedException(GetType().FullName);

            if (b.Width != Width)
                throw new ArgumentException(String.Format("The width of the supplied bitmap ({0}) must match the width of the output png ({1}).", b.Width, Width));

            BitmapData bData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] data = new byte[b.Width * b.Height * 4];
            Marshal.Copy(bData.Scan0, data, 0, data.Length);
            b.UnlockBits(bData);

            if (dstream == null)
                dstream = new DataStream();
            if (zstream == null)
                zstream = new ZlibStream(dstream, CompressionMode.Compress);

            byte[] filterType = new byte[] { 0 }; //none
            byte[] pixel = new byte[4];
            int lineWidth = b.Width * 4;
            for (int y = 0; y < b.Height; y++)
            {
                zstream.Write(filterType, 0, 1);
                for (int x = 0; x < b.Width; x++)
                {
                    int offset = y * lineWidth + x * 4;
                    //needs to be rgba
                    if (BitConverter.IsLittleEndian)
                    {
                        pixel[2] = data[offset]; //b
                        pixel[1] = data[offset + 1]; //g
                        pixel[0] = data[offset + 2]; //r
                        pixel[3] = data[offset + 3]; //a
                    }
                    else
                    {
                        pixel[3] = data[offset]; //a
                        pixel[0] = data[offset + 1]; //r
                        pixel[1] = data[offset + 2]; //g
                        pixel[2] = data[offset + 3]; //b
                    }
                    
                    zstream.Write(pixel, 0, 4);
                }
            }
            zstream.Flush();
            WriteChunk("IDAT", dstream.GetDataSoFar());
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
