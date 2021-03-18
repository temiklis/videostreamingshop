using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Infrasturcture.Services
{
    internal class FileExtensionEnumConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            Enum.TryParse(text, out Extension extension);
            return extension;
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return Enum.GetName(typeof(Extension), value);
        }
    }
}