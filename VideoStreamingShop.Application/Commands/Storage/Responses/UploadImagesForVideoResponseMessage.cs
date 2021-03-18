using System.Collections.Generic;

namespace VideoStreamingShop.Application.Commands.Storage
{
    public class UploadImagesForVideoResponseMessage
    {
        public FluentValidation.Results.ValidationResult ValidationResult { get; private set; }
        public List<string> Paths { get; private set; }
        public UploadImagesForVideoResponseMessage(FluentValidation.Results.ValidationResult validationResult, List<string> paths = null)
        {
            ValidationResult = validationResult;
            Paths = paths;
        }
    }

}
