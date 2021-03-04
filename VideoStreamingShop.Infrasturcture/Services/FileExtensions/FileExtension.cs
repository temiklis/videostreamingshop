using System.Collections.Generic;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Interfaces.FileExtensions;

namespace VideoStreamingShop.Infrasturcture.Services.FileExtensions
{
    internal abstract class FileExtension : IFileExtension
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
}
