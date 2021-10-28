namespace Showroom.Pages
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;
    using Showroom.Presentation.Themes;

    public partial class Home
    {
        [Inject] public IJSRuntime JsRuntime { get; set; }

        [Inject] public ThemeManager ThemeManager { get; set; }

        [Parameter] public bool UserLogged { get; set; } = false;

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime.InvokeAsync<object>("initializeCarousel");
        }
    }
}
