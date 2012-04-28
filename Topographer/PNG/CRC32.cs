using System;

namespace Topographer.PNG
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
            table = new uint[256];
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
}
