using Autofac.Features.AttributeFilters;
using System;
using System.IO;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Infrascturucre;
using VideoStreamingShop.Core.Interfaces.FileExtensions;
using VideoStreamingShop.Core.Interfaces.Storage;

namespace VideoStreamingShop.Infrasturcture.Services
{
    internal class LocalImageStorage : IImageStorage
    {
        private readonly string _storagePath;
        private readonly IFileExtension _fileExtension;
        public LocalImageStorage(string storagePath, [KeyFilter(FileType.Image)] IFileExtension fileExtension)
        {
            _storagePath = storagePath;
            _fileExtension = fileExtension;
        }

        public Task<byte[]> Download(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Upload(byte[] data)
        {
            if (!_fileExtension.Validate(data))
            {
                throw new BadImageFormatException();
            }

            var format = _fileExtension.GetFormat(data);

            CreateDefaultDirectoryIfNotExist();

            string generatedName = $"{Guid.NewGuid()}.{format}";
            string filepath = $"{_storagePath}/{generatedName}";

            using (FileStream stream = new FileStream(filepath, FileMode.Create))
            {
                stream.Seek(0, SeekOrigin.End);
                await stream.WriteAsync(data, 0, data.Length); 
            }

            return filepath;
        }

        private void CreateDefaultDirectoryIfNotExist()
        {
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }
    }
}
