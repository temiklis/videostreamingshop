using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamingShop.MVC.ViewModels
{
    public class PaginationViewModel<T> where T : class
    {
        public int Page { get; set; }
        public int Count { get; set; }
        public List<T> Data { get; set; }
    }
}
