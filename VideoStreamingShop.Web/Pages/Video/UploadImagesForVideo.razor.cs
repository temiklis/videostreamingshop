using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamingShop.Web.Pages.Video
{
    // TODO: move that class after testing
    //TODO rename that shit
    // reconscturct model later 
    internal class UploadImagesForVideoViewModel
    {
        public Guid Id { get; private set; }
        public string ImageUrl { get; set; }

        public bool IsDeleteStarted = false;

        public UploadImagesForVideoViewModel(string imageUrl)
        {
            Id = Guid.NewGuid();
            this.ImageUrl = imageUrl;
        }
    }

    public partial class UploadImagesForVideo : ComponentBase
    {
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

                model.Add(new UploadImagesForVideoViewModel(imageDataUrl));
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
