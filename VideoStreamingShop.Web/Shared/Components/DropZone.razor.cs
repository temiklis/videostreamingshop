using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamingShop.Web.Shared.Components
{
    public partial class DropZone : ComponentBase
    {
        [Parameter]
        public EventCallback<InputFileChangeEventArgs> OnInputFileChange { get; set; }
        [Parameter]
        public EventCallback OnDragEnter { get; set; }
        [Parameter]
        public EventCallback OnDragLeave { get; set; }
        
        string dropClass = string.Empty;

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async void HandleDragEnter()
        {
            if (OnDragEnter.HasDelegate)
            {
                await OnDragEnter.InvokeAsync();
                return;
            }

            dropClass = "drop-area-drug";
        }

        private async void HandleDragLeave()
        {
            if (OnDragLeave.HasDelegate)
            {
                await OnDragLeave.InvokeAsync();
                return;
            }

            dropClass = string.Empty;
        }

        private async Task OnFileChange(InputFileChangeEventArgs e)
        {
            dropClass = string.Empty;
            await this.OnInputFileChange.InvokeAsync();   
        }
    }
}
