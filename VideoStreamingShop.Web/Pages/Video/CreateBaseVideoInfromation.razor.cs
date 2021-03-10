using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Data;
using VideoStreamingShop.Web.Models.DTOs;
using VideoStreamingShop.Web.ViewModels.Video;

namespace VideoStreamingShop.Web.Pages.Video
{
    public partial class CreateBaseVideoInfromation : ComponentBase
    {
        [Parameter]
        public EventCallback<int> OnVideoCreated { get; set; }

#warning remove unnecessary parameters
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        [Inject]
        private IVideoService videoService { get; set; }
        [Inject]
        private IMapper mapper { get; set; }


        private CreateVideoViewModel createVideoViewModel = new CreateVideoViewModel();

        private string ValidMessage = "Good";



        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async void HandleValidSubmit()
        {
            var createVideoDto = mapper.Map<CreateVideoDTO>(createVideoViewModel);
            var result = await videoService.CreateVideoWithBaseInformation(createVideoDto);
            if (result.IsSuccessStatusCode)
            {
                var createdVideoId = result.Content;
                await OnVideoCreated.InvokeAsync(createdVideoId);
            }
        }
    }
}
