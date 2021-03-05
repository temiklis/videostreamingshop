using System;

namespace VideoStreamingShop.Web.Data
{
    internal static class API
    {
        internal static class Video
        {
            public static string GetAllVideoItems(string baseUrl, int page, int count)
            {
                return $@"video?skip={page}&take={count}";
            }

            public static string GetVideoByID(string baseUrl, int id)
            {
                return $"video/{id}";
            }

            public static string GetNotFullyCreatedVideos(string baseUrl, int page, int count)
            {
                return $"video/GetNotFullyCreated?page={page}&count={count}";
            }

            public static string CreateVideoWithBaseInformation()
            {
                return "video/create";
            }
        }
    }
}