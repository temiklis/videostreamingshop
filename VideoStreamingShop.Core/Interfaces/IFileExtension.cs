using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStreamingShop.Core.Interfaces
{
    public interface IFileExtension
    {
        IMimeShiffing MimeShiffing { get; }
        bool Validate(byte[] data);
    }

    public class ImageFileExtension : IFileExtension
    {
        public IMimeShiffing MimeShiffing => throw new NotImplementedException();

        private List<string> Extensions = new List<string>() 
        {
            "jpg",
            "png"
        };
        public bool Validate(byte[] data)
        {
            var type = MimeShiffing.MimeTypeFrom(data, string.Empty);
            return Extensions.Contains(type);
        }
    }

    public class VideoFileExtension : IFileExtension
    { 
        public IMimeShiffing MimeShiffing => throw new NotImplementedException();

        private List<string> Extensions = new List<string>()
        {
            "MP4",
            "AVI",
            "MKV",
            "MOV",
            "FLV"
        };

        public bool Validate(byte[] data)
        {
            var type = MimeShiffing.MimeTypeFrom(data, string.Empty);
            return Extensions.Contains(type);
        }
    }
}
