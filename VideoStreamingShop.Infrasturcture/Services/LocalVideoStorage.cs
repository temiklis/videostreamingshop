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
        private readonly IVideoFileValidator _videoFileValidator;
        public LocalVideoStorage(IVideoFileValidator videoFileValidator)
        {
            _videoFileValidator = videoFileValidator;
        }
        public Task<FileStream> DownloadVideo(string videoId)
        {
            var filePath = string.Empty;
            if (File.Exists(filePath))
            {
                FileStream stream = new FileStream(filePath, FileMode.Open);
                return Task.FromResult(stream);
            }

            return null;
        }

        public async Task<bool> UploadVideo(byte[] data)
        {
            var uniqName = Guid.NewGuid();
            var format = string.Empty;
            var filepath = Path.Combine(string.Empty, $"{uniqName.ToString()}.{format}");

            if (_videoFileValidator.IsVideoFileFormat)
            {
                using (FileStream stream = new FileStream(filepath, FileMode.Create))
                {
                    stream.Seek(0, SeekOrigin.End);
                    await stream.WriteAsync(data, 0, data.Length);
                }

                return true;
            }

            return false;
        }
    }
}
