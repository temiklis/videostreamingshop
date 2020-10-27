using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Interfaces;

namespace VideoStreamingShop.Infrasturcture.Services
{
    internal class LocalVideoStorage : IVideoFileStorage
    {
        public Task<byte[]> DownloadVideo(string videoId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadVideo(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
