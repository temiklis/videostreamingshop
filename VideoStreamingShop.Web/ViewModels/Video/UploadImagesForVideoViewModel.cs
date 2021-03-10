using System;
using VideoStreamingShop.Web.Models.Shared;

namespace VideoStreamingShop.Web.ViewModels.Video
{
    // TODO: move that class after testing
    //TODO rename that shit
    // reconscturct model later 
    internal class UploadImagesForVideoViewModel
    {
        public Guid Id { get; private set; }
        public string ImageUrl { get; set; }

        public bool IsDeleteStarted = false;

        public FileData File { get; set; }

        public UploadImagesForVideoViewModel(string imageUrl, FileData file)
        {
            Id = Guid.NewGuid();
            ImageUrl = imageUrl;
            File = file;
        }
    }
}
