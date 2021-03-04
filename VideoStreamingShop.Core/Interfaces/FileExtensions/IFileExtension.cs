using System;
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
}
