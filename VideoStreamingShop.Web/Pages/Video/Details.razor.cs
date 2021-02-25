using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Data;
using VideoStreamingShop.Web.ViewModels.Video;

namespace VideoStreamingShop.Web.Pages.Video
{
    public partial class Details
    {
        [Inject]
        private IVideoService videoService { get; set; }

        [Parameter]
        public int Id { get; set; }

        private VideoPageViewModel videoPageViewModel;

        protected override async Task OnInitializedAsync()
        {
            videoPageViewModel = await videoService.GetById(Id);
        }
    }
}
