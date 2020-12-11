using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Core.Interfaces.FileExtensions
{
    //refactor that code.
    public interface IFileExtension
    {
        IMimeShiffing MimeShiffing { get; }
        bool Validate(byte[] data);
        Extension GetFormat(byte[] data);
    }

    public abstract class FileExtension : IFileExtension
    {
        public IMimeShiffing MimeShiffing { get; private set; }

        protected readonly IFileExtensionTranslator _translator;

        public FileExtension(IMimeShiffing mimeShiffing, IFileExtensionTranslator translator)
        {
            MimeShiffing = mimeShiffing;
            _translator = translator;
        }

        protected List<Extension> Extensions { get; set; }

        public bool Validate(byte[] data)
        {
            var type = MimeShiffing.MimeTypeFrom(data);
            var format = _translator.GetFormat(type);
            return Extensions.Contains(format);
        }

        public Extension GetFormat(byte[] data)
        {
            var type = MimeShiffing.MimeTypeFrom(data);
            var format = _translator.GetFormat(type);
            return format;
        }
    }

    public class ImageFileExtension : FileExtension
    {
        public ImageFileExtension(IMimeShiffing mimeShiffing, IFileExtensionTranslator translator, List<Extension> supportedExtensions)
            : base(mimeShiffing, translator)
        {
            Extensions = supportedExtensions;
        }
    }

    public class VideoFileExtension : FileExtension
    { 
        public VideoFileExtension(IMimeShiffing mimeShiffing, IFileExtensionTranslator translator, List<Extension> supportedExtensions) 
            : base(mimeShiffing, translator)
        {
            Extensions = supportedExtensions;
        }
    }
}
