using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using VideoStreamingShop.Core.Interfaces;

namespace VideoStreamingShop.Infrasturcture.Services
{
    internal class MimeShiffing : IMimeShiffing
    {
        [DllImport("urlmon.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false)]
        public static extern int FindMimeFromData(IntPtr pBC,
        [MarshalAs(UnmanagedType.LPWStr)] string pwzUrl,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.I1, SizeParamIndex=3)]
        byte[] pBuffer,
        int cbSize,
        [MarshalAs(UnmanagedType.LPWStr)] string pwzMimeProposed,
        int dwMimeFlags,
        out IntPtr ppwzMimeOut,
        int dwReserved);

        public string MimeTypeFrom(byte[] dataBytes, string mimeProposed)
        {
            if (dataBytes == null)
                throw new ArgumentNullException("dataBytes");
            string mimeRet = String.Empty;
            IntPtr suggestPtr = IntPtr.Zero, filePtr = IntPtr.Zero, outPtr = IntPtr.Zero;
            if (mimeProposed != null && mimeProposed.Length > 0)
            {
                //suggestPtr = Marshal.StringToCoTaskMemUni(mimeProposed); // for your experiments ;-)
                mimeRet = mimeProposed;
            }

            int ret = FindMimeFromData(IntPtr.Zero, null, dataBytes, dataBytes.Length, mimeProposed, 0, out outPtr, 0);
            if (ret == 0 && outPtr != IntPtr.Zero)
            {
                mimeRet = Marshal.PtrToStringUni(outPtr);
                Marshal.FreeCoTaskMem(outPtr); //msdn docs wrongly states that operator 'delete' must be used. Do not remove FreeCoTaskMem
                return mimeRet;

            }

            return mimeRet;
        }

    }
}
