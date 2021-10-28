namespace Showroom.Shared
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Showroom.Presentation.Themes;

    public partial class MainLayout
    {
        [Inject] 
        public IThemeManager ThemeManager { get; private set; }

        protected override Task OnInitializedAsync()
        {
            ThemeManager.ThemeChanged += ThemeManagerOnThemeChanged;
            return base.OnInitializedAsync();
        }

        private void ThemeManagerOnThemeChanged(string themeName)
        {
            InvokeAsync(StateHasChanged);
        }
    }
}
