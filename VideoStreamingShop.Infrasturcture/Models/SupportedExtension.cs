using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Infrasturcture.Models
{
    public class SupportedExtension
    {
        public string MimeType { get; set; }
        public Extension Extension { get; set; }
    }
}
