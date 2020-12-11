using System;
using System.IO;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces.Storage;

namespace VideoStreamingShop.Infrasturcture.Services
{
    internal class LocalImageStorage : IImageStorage
    {
        private string _storagePath;
        public LocalImageStorage(string storagePath)
        {
            _storagePath = storagePath;
        }

        private void CreateDefaultDirectoryIfNotExist()
        {
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }
        public Task<byte[]> Download(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Upload(byte[] data, Extension format)
        {
            CreateDefaultDirectoryIfNotExist();

            string generatedName = $"{Guid.NewGuid().ToString()}.{format.ToString()}";
            string filepath = $"{_storagePath}/{generatedName}";

            using (FileStream stream = new FileStream(filepath, FileMode.Create))
            {
                stream.Seek(0, SeekOrigin.End);
                await stream.WriteAsync(data, 0, data.Length); 
            }

            return filepath;
        }
    }
}
