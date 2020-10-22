using System.IO;
using System.Threading.Tasks;

namespace VideoStreamingShop.Core.Interfaces
{
    public interface IVideoFileStorage
    {
        Task<FileStream> DownloadVideo(string videoId);
        Task<bool> UploadVideo(byte[] data);
    }
}
