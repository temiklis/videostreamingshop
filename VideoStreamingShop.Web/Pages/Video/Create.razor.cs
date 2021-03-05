using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Data;
using VideoStreamingShop.Web.Models.DTOs;
using VideoStreamingShop.Web.ViewModels.Video;

namespace VideoStreamingShop.Web.Pages.Video
{
    public partial class Create : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IVideoService videoService { get; set; }
        [Inject] 
        private IMapper mapper { get; set; }

        private CreateVideoViewModel createVideoViewModel = new CreateVideoViewModel();

        public string ValidMessage = "Good";

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async void HandleValidSubmit()
        {
            var createVideoDto = mapper.Map<CreateVideoDTO>(createVideoViewModel);
            var isSuccess = await videoService.CreateVideoWithBaseInformation(createVideoDto);
            if (isSuccess)
            {
                NavigationManager.NavigateTo("");
            }
            else
            {
                //show module or nothing else
            }
        }
    }
}
