using System.Collections.Generic;

namespace VideoStreamingShop.Models.Shared
{
    public class Result<T>
    {
        public IEnumerable<Error> Errors { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public T Content { get; set; }
    }
}