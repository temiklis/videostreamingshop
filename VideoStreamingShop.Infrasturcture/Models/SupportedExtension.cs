using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Infrasturcture.Models
{
    public class SupportedExtension
    {
        [Name("MIME")]
        public string MimeType { get; set; }
        [Name("Format")]
        public Extension Extension { get; set; }
    }
}
