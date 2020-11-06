using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VideoStreamingShop.Core.Interfaces
{
    public interface IImageStorage
    {
        Task<string> Upload(byte[] data);
        Task<byte[]> Download(string uri);
    }
}
