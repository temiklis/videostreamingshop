using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Core.Interfaces.FileExtensions
{
    public interface IFileExtensionTranslator
    {
        Extension GetFormat(string format);
    }
}
