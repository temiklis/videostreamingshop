﻿using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Data;
using VideoStreamingShop.Web.Models.DTOs;
using VideoStreamingShop.Web.ViewModels.Video;

namespace VideoStreamingShop.Web.Pages.Video
{
    public partial class Create : ComponentBase
    {
        private bool IsBaseInfromationCreated = false;
        private bool IsBaseInfromationSectionVisible = true;

        private int createdVideoId;

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private void HandleBaseVideoInfromationCreated(int videoId)
        {
            IsBaseInfromationCreated = true;

            createdVideoId = videoId;
        }
        private void HideBaseInfromation()
        {
            IsBaseInfromationSectionVisible = false;
        }
    }
}
