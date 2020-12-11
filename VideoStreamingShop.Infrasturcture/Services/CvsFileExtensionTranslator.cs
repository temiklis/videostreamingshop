using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces.FileExtensions;
using VideoStreamingShop.Infrasturcture.Models;
using System.Linq;

namespace VideoStreamingShop.Infrasturcture.Services
{
    //need to move from services folder
    internal class CvsFileExtensionTranslator : IFileExtensionTranslator
    {
        private string _pathToTranslationFile;
        public CvsFileExtensionTranslator(string pathToTranslationFile)
        {
            _pathToTranslationFile = pathToTranslationFile;
        }
        public Extension GetFormat(string format)
        {
            using (var reader = new StreamReader(_pathToTranslationFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<SupportedExtension>();
                var item = records.FirstOrDefault(v => v.MimeType.Equals(format));
                if (item != null)
                    return item.Extension;
            }

            return default;
        }
    }
}
