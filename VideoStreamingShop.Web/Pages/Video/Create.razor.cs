using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Data;
using VideoStreamingShop.Web.ViewModels.Video;

namespace VideoStreamingShop.Web.Pages.Video
{
    public partial class Create
    {
        [Inject]
        private IVideoService videoService { get; set; }

        private CreateVideoViewModel createVideoViewModel = new CreateVideoViewModel();

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async void HandleValidSubmit()
        {
            var isSuccess = await videoService.CreateVideoWithBaseInformation(createVideoViewModel);
        }
    }
}
