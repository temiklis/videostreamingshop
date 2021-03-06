﻿using System.IO;
using System.Threading.Tasks;

namespace VideoStreamingShop.Core.Interfaces.Storage
{
    public interface IVideoFileStorage
    {
        Task<byte[]> DownloadVideo(string videoUri);
        Task<string> UploadVideo(byte[] data);
    }
}
