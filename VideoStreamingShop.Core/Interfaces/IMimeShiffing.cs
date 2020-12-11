using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStreamingShop.Core.Interfaces
{
    public interface IMimeShiffing
    {
        string MimeTypeFrom(byte[] dataBytes);
    }
}
