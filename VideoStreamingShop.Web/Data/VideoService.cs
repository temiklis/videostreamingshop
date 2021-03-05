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
using VideoStreamingShop.Web.Models.DTOs;
using VideoStreamingShop.Web.ViewModels;
using VideoStreamingShop.Web.ViewModels.Video;

namespace VideoStreamingShop.Web.Data
{
    public class VideoService : IVideoService
    {
        //TODO: Need to create class for httpclientFactory;
        private readonly HttpClient _httpClient;
        //TODO
        private readonly string _remoteServiceBaseUrl;
        public VideoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //TODO CHANGE THIS MODEL TO DTO OBJECT
        public async Task<bool> CreateVideoWithBaseInformation(CreateVideoDTO createVideoViewModel)
        {
            var uri = API.Video.CreateVideoWithBaseInformation();

            var json = JsonConvert.SerializeObject(createVideoViewModel);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync(uri, content);

            return response.IsSuccessStatusCode;
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
