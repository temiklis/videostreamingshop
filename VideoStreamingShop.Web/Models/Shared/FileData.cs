using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamingShop.Web.Models.Shared
{
    public class FileData
    {
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public long Size { get; set; }
    }
}
