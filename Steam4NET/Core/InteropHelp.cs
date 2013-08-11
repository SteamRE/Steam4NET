using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Steam4NET.Core
{
    public class InteropHelp
    {

        /// <summary>
        /// Decodes ANSI encoded return string to UTF-8
        /// </summary>
        public static string DecodeANSIReturn(string buffer)
        {
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(buffer));
        }

        public class BitVector64
        {
            private UInt64 data;

            public BitVector64()
            {
            }
            public BitVector64(UInt64 value)
            {
                data = value;
            }

            public UInt64 Data
            {
                get { return data; }
                set { data = value; }
            }

            public UInt64 this[uint bitoffset, UInt64 valuemask]
            {
                get
                {
                    return (data >> (ushort)bitoffset) & valuemask;
                }
                set
                {
                    data = (data & ~(valuemask << (ushort)bitoffset)) | ((value & valuemask) << (ushort)bitoffset);
                }
            }
        }
    }
}
