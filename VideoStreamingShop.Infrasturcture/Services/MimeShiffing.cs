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
        static extern int FindMimeFromData(IntPtr pBC,
        [MarshalAs(UnmanagedType.LPWStr)] string pwzUrl,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 3)]
        byte[] pBuffer,
        int cbSize,
        [MarshalAs(UnmanagedType.LPWStr)] string pwzMimeProposed,
        int dwMimeFlags,
        out IntPtr ppwzMimeOut,
        int dwReserved);

        public static int MimeSampleSize = 256;

        public static string DefaultMimeType = "application/octet-stream";

        public string MimeTypeFrom(byte[] dataBytes)
        {
            if (dataBytes == null)
            {
                throw new ArgumentNullException("data", "Hey, data is null.");
            }

            IntPtr mimeTypePointer = IntPtr.Zero;
            try
            {
                FindMimeFromData(IntPtr.Zero, null, dataBytes, MimeSampleSize, null, 0, out mimeTypePointer, 0);
                var mime = Marshal.PtrToStringUni(mimeTypePointer);
                return mime ?? DefaultMimeType;
            }
            catch (AccessViolationException e)
            {
                return DefaultMimeType;
            }
            finally
            {
                if (mimeTypePointer != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(mimeTypePointer);
                }
            }
        }

    }
}
