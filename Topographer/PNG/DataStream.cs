using System;
using System.IO;

namespace Topographer.PNG
{
    //Like a MemoryStream, except at any point the data in it can be returned
    //and the stream emptied. No idea what to actually call it.
    public class DataStream : Stream
    {
        private MemoryStream stream = new MemoryStream();

        public byte[] GetDataSoFar()
        {
            byte[] ret = stream.ToArray();
            stream.Dispose();
            stream = new MemoryStream();
            return ret;
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Flush()
        {
            stream.Flush();
        }

        public override long Length
        {
            get { return stream.Length; }
        }

        public override long Position
        {
            get
            {
                return stream.Position;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            stream.Write(buffer, offset, count);
        }
    }
}
