using CsvHelper.Configuration;
using VideoStreamingShop.Infrasturcture.Models;

namespace VideoStreamingShop.Infrasturcture.Services
{
    public class SupportedExtensionMap : ClassMap<SupportedExtension>
    {
        public SupportedExtensionMap()
        {
            Map(x => x.MimeType)
                .Name("MIME");

            Map(x => x.Extension)
                .Name("Format")
                .TypeConverter<FileExtensionEnumConverter>();
        }
    }
}