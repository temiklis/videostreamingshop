using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Core.Interfaces.Storage
{
    public interface IImageStorage
    {
        Task<string> Upload(byte[] data);
        Task<byte[]> Download(string uri);
    }
}
