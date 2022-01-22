namespace Showroom.Client.Pages
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using Showroom.Api.Models;
    using Showroom.Client.Services;
    using Showroom.Models;
    using Showroom.Presentation.Themes;

    public partial class Home
    {
        [Inject] 
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject] 
        public IThemeManager ThemeManager { get; set; }

        [Inject] 
        public IProjectService ProjectService { get; set; }

        public IEnumerable<IProject> Projects { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime.InvokeAsync<object>("initializeCarousel");

            Projects = await ProjectService.GetProjects();

            StateHasChanged();
        }
    }
}
