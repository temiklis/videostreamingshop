using System;
using System.IO;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Interfaces.Storage;

namespace VideoStreamingShop.Infrasturcture.Services
{
    internal class LocalVideoStorage : IVideoFileStorage
    {
        private string folderPath; 
        public LocalVideoStorage(string path)
        {
            folderPath = path;
        }
        public Task<byte[]> DownloadVideo(string videoUri)
        {
            byte[] fileData = null;

            if (File.Exists(videoUri))
            using (var stream = new FileStream(videoUri, FileMode.Open))
            {
                using(BinaryReader binaryReader = new BinaryReader(stream))
                {
                    fileData = binaryReader.ReadBytes((int)stream.Length);
                }
            }

            return Task.FromResult(fileData);
        }

        public async Task<string> UploadVideo(byte[] data)
        {
            var pathToFile = $@"{folderPath}\{Guid.NewGuid()}";

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            using (var stream = new FileStream(pathToFile, FileMode.OpenOrCreate))
            {
                stream.Seek(0, SeekOrigin.End);
                await stream.WriteAsync(data, 0, data.Length);
            }

            return pathToFile;
        }
    }
}
