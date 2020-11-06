using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Interfaces;

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

        public async Task<string> Upload(byte[] data)
        {
            CreateDefaultDirectoryIfNotExist();

            string generatedName = Guid.NewGuid().ToString();
            string filepath = Path.Combine(_storagePath, generatedName);
            using (FileStream stream = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                stream.Seek(0, SeekOrigin.End);
                await stream.WriteAsync(data, 0, data.Length); 
            }

            return filepath;
        }
    }
}
