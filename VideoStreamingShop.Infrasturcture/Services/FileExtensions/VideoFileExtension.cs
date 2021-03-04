using System.Collections.Generic;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Interfaces.FileExtensions;

namespace VideoStreamingShop.Infrasturcture.Services.FileExtensions
{
    public class VideoFileExtension : FileExtension
    {
        public VideoFileExtension(IMimeShiffing mimeShiffing, IFileExtensionTranslator translator, List<Extension> supportedExtensions)
            : base(mimeShiffing, translator)
        {
            Extensions = supportedExtensions;
        }
    }
}
