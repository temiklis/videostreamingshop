using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Models.Shared;
using VideoStreamingShop.Web.Models.DTOs;
using VideoStreamingShop.Web.ViewModels;
using VideoStreamingShop.Web.ViewModels.Video;

namespace VideoStreamingShop.Web.Data
{
    //TODO NEED TO WRITE WRAPPER FOR Results
    public class VideoService : IVideoService
    {
        //TODO: Need to create class for httpclientFactory;
        private readonly HttpClient _httpClient;
        //TODO remove this later
        private readonly string _remoteServiceBaseUrl;
        public VideoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<int>> CreateVideoWithBaseInformation(CreateVideoDTO createVideoViewModel)
        {
            var uri = API.Video.CreateVideoWithBaseInformation();

            var json = JsonConvert.SerializeObject(createVideoViewModel);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                return new Result<int>()
                {
                    IsSuccessStatusCode = false
                };
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var createdVideoId = JsonConvert.DeserializeObject<int>(jsonResponse);
            return new Result<int>()
            {
                IsSuccessStatusCode = true,
                Content = createdVideoId
            };
        }

        public async Task<IEnumerable<VideoCardViewModel>> Get(int page = 0, int take = 20)
        {
            var uri = API.Video.GetAllVideoItems(_remoteServiceBaseUrl, page, take);

            var responseString = await _httpClient.GetStringAsync(uri);

            var cards = JsonConvert.DeserializeObject<IEnumerable<VideoCardViewModel>>(responseString);

            return cards;
        }

        public async Task<VideoPageViewModel> GetById(int id)
        {
            var uri = API.Video.GetVideoByID(_remoteServiceBaseUrl, id);

            var responseString = await _httpClient.GetStringAsync(uri);

            var video = JsonConvert.DeserializeObject<VideoPageViewModel>(responseString);

            return video;
        }

        public async Task<NotFullyCreatedVideoViewModel> GetNotFullyCreatedVideos(int page, int count)
        {
            var uri = API.Video.GetNotFullyCreatedVideos(_remoteServiceBaseUrl, page, count);

            var responseString = await _httpClient.GetStringAsync(uri);

            var entities = JsonConvert.DeserializeObject<NotFullyCreatedVideoViewModel>(responseString);

            return entities;
        }
    }
}
