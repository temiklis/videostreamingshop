using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.ViewModels;
using VideoStreamingShop.Web.Data;
using Microsoft.AspNetCore.Components;

namespace VideoStreamingShop.Web.Pages
{
    public partial class Home : ComponentBase
    { 
        [Inject]
        private IVideoService _videoService { get; set; }

        private List<VideoCardViewModel> videoCards = new List<VideoCardViewModel>();

        private int page = 0;
        private int count = 20;
        protected override async Task OnInitializedAsync()
        {
            //automapper required
            videoCards = (List<VideoCardViewModel>)await _videoService.Get(page, count);
        }
    }
}
