using System.IO;
using System.Threading.Tasks;

namespace VideoStreamingShop.Core.Interfaces
{
    public interface IVideoFileStorage
    {
        Task<byte[]> DownloadVideo(string videoId);
        Task<string> UploadVideo(byte[] data);
    }
}
