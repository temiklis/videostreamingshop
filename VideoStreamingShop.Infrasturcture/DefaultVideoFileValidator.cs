using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Interfaces;

namespace VideoStreamingShop.Infrasturcture
{
    internal class DefaultVideoFileValidator : IVideoFileValidator
    {
        public bool IsVideoFileFormat { get => true;}
    }
}
