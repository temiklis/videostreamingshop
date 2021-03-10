using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Data;
using VideoStreamingShop.Web.Models.DTOs;
using VideoStreamingShop.Web.Models.Shared;
using VideoStreamingShop.Web.ViewModels.Video;

namespace VideoStreamingShop.Web.Pages.Video
{
    public partial class UploadImagesForVideo : ComponentBase
    {
        [Parameter]
        public int VideoId { get; set; }

        [Inject]
        private IStorageService storageService { get; set; }

        //remove thit shit
        private List<UploadImagesForVideoViewModel> model = new List<UploadImagesForVideoViewModel>();

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            var maxAllowedFiles = 4;
            var format = "image/png";

            foreach (var imageFile in e.GetMultipleFiles(maxAllowedFiles))
            {
                var resizedImageFile = await imageFile.RequestImageFileAsync(format, 200, 200);

                var buffer = new byte[resizedImageFile.Size];
                await resizedImageFile.OpenReadStream().ReadAsync(buffer);

                var imageDataUrl = $"data:{format};base64,{Convert.ToBase64String(buffer)}";

                var file = new FileData()
                {
                    Data = buffer,
                    FileType = imageFile.ContentType,
                    Size = imageFile.Size
                };

                model.Add(new UploadImagesForVideoViewModel(imageDataUrl, file));
            }
        }

        private void OnUploadClicked()
        {
            if (model.Count > 0)
            {
                var uploadImagesDTO = new UploadImagesForVideoDTO()
                {
                    Id = VideoId,
                    Files = model.Select(x => x.File)
                };

                storageService.UploadImagesForVideo(uploadImagesDTO);
            }
        }

        private void RemoveFile(Guid id)
        {
            var fileToRemove = model.FirstOrDefault(x => x.Id == id);
            if (fileToRemove == null)
                return;

            model.Remove(fileToRemove);
        }

        private void RunDeletionAnimation(Guid id)
        {
            var fileToDelete = model.FirstOrDefault(x => x.Id == id);
            fileToDelete.IsDeleteStarted = true;
        }
    }
}
