using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Models.DTOs;

namespace VideoStreamingShop.Web.Data
{
    //TODO: need to think about separate storagies classes
    public class StorageService : IStorageService
    {
        private readonly HttpClient _httpClient;
        public StorageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<string>> UploadImagesForVideo(UploadImagesForVideoDTO uploadImagesForVideoDTO)
        {
            var uri = API.Storage.UploadImagesForVideo(uploadImagesForVideoDTO.Id);

            MultipartFormDataContent content = new MultipartFormDataContent();
            foreach (var file in uploadImagesForVideoDTO.Files)
            {
                content.Add(new ByteArrayContent(file.Data, 0, file.Data.Length), "files", Guid.NewGuid().ToString());
            }

            var response = await _httpClient.PostAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<string>();
            }

            var json = response.Content.ReadAsStringAsync();

            return null;
        }
    }
}
