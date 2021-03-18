using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.ViewModels;

namespace VideoStreamingShop.Web.Pages.Cards
{
    public partial class VideoCard : ComponentBase
    {
        [Inject]
        private IConfiguration configuration { get; set; }
        [Inject]
        private NavigationManager navigationManager { get; set; }
        //[Inject]
        //private ILogger Logger { get; set; }

        [Parameter]
        public VideoCardViewModel videoCard { get; set; }

        private string baseAddress;

        protected override void OnInitialized()
        {
            baseAddress = configuration.GetValue<string>("ApiSettings:BaseAddress");
            base.OnInitialized();
            navigationManager.LocationChanged += HandleLocationChanged;
        }

        private void HandleLocationChanged(object sender, LocationChangedEventArgs e)
        {
            //Logger.LogInformation("URL of new location: {Location}", e.Location);
        }

        void OnDetailsClick(int id)
        {
            navigationManager.NavigateTo($"video/details/{id}");
        }
    }
}
