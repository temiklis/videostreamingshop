using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingShop.Core.Interfaces;

namespace VideoStreamingShop.MVC.Controllers
{
    public class VideoController : Controller
    {
        private readonly IMediator _mediator;
        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        { 
            return View();
        }
    }
}
