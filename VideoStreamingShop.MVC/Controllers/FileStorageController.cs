using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingShop.Core.Usecases.Storage;

namespace VideoStreamingShop.MVC.Controllers
{
    public class FileStorageController : Controller
    {
        private readonly UploadImagesForVideoInteractor _uploadImagesForVideoInteractor;
        public FileStorageController(UploadImagesForVideoInteractor uploadImagesForVideoInteractor)
        {
            _uploadImagesForVideoInteractor = uploadImagesForVideoInteractor;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImagesForVideo([FromQuery]int videoId)
        {
            var request = new UploadImagesForVideoRequestMessage()
            {
                FilesData = new List<byte[]>(),
                VideoId = videoId
            };

            var files = Request.Form.Files;
            foreach (var file in files)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    request.FilesData.Add(stream.ToArray());
                }
            }

            var response = await _uploadImagesForVideoInteractor.Handle(request, CancellationToken.None);
            if(response.ValidationResult.Errors.Count > 0)
            {
                return Json(new { status = "Error" });
            }

            string message = $"{files.Count} files uploaded";

            return Json(new { status = "success", paths = response.Paths});
        }
    }
}
