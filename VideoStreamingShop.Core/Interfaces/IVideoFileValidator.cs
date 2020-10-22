using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStreamingShop.Core.Interfaces
{
    public interface IVideoFileValidator
    {
        /// <summary>
        /// Return true if video format supported
        /// </summary>
        bool IsVideoFileFormat { get; }
    }
}
