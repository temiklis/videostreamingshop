using System.Collections.Generic;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Interfaces.FileExtensions;

namespace VideoStreamingShop.Infrasturcture.Services.FileExtensions
{
    internal class ImageFileExtension : FileExtension
    {
        public ImageFileExtension(IMimeShiffing mimeShiffing, IFileExtensionTranslator translator, List<Extension> supportedExtensions)
            : base(mimeShiffing, translator)
        {
            Extensions = supportedExtensions;
        }
    }
}
