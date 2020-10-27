using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStreamingShop.Core.Entities
{
    public class VideoFile : Entity
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Uri { get; set; }
        public VideoFile() { }
        public VideoFile(string name, string version, string uri)
        {
            this.Name = name;
            this.Version = version;
            this.Uri = uri;
        }
    }
}
