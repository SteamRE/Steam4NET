using System;
using System.Runtime.InteropServices;

namespace Steam4NET
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SteamParamStringArray_t
    {
        public IntPtr m_ppStrings;
        public Int32 m_nNumStrings;
    };
}
