namespace Showroom.Client.Pages
{
    using System;
    using System.Threading.Tasks;
    using Showroom.Models;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using Showroom.Presentation.UserInterface;

    public partial class WebGLViewer
    {
        private ElementReference _unityCanvas;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                ProjectName ??= "Attic";
                ProgressUpdater.IsFinished = false;
                await CreateUnityInstance(ProjectName);

                StateHasChanged();
            }
        }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public IProgressUpdater ProgressUpdater { get; private set; }

        [Parameter]
        public int Height { get; set; }

        [Parameter]
        public int Width { get; set; }

        [Parameter]
        public string ProjectName { get; set; }


        [JSInvokable]
        public void OnProgress(double progress)
        {
            ProgressUpdater.UpdateProgress((int)Math.Round(progress * 100));

            StateHasChanged();
        }

        [JSInvokable]
        public void OnFinished()
        {
            ProgressUpdater.IsFinished = true;
            StateHasChanged();
        }

        private async Task CreateUnityInstance(string projectName)
        {
            var data = new UnityInstanceData()
            {
                dataUrl = $"Builds/{ProjectName}/Build/Build.data",
                frameworkUrl = $"Builds/{ProjectName}/Build/Build.framework.js",
                codeUrl = $"Builds/{ProjectName}/Build/Build.wasm",
                streamingAssetsUrl = "StreamingAssets",
                companyName = "Vaclav Pfudl",
                productName = $"{projectName}",
                productVersion = "1.0"
            };

            var objectReference = DotNetObjectReference.Create(this);

            await JsRuntime.InvokeAsync<Object>("CreateUnityInstance",
                _unityCanvas, data, objectReference);            
        }
    }
}
