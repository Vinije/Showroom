using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace VaclavPfudl.Components.Utilities
{
    public partial class AnchorNavigation : IDisposable
    {
        private readonly string _jsInteropCode;

        public AnchorNavigation()
        {
            _jsInteropCode = $"{GetType().Assembly.GetName().Name}.Utilities.AnchorNavigation.js";
        }

        [Parameter]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public NavigationManager NavigationManager { get; set; }

        public void Dispose()
        { 
            NavigationManager.LocationChanged -= OnLocationChanged;
        }

        protected async override void OnInitialized()
        {
            base.OnInitialized();            

            await JSRuntime.InvokeVoidAsync("eval",
                        GetEmbeddedJSInteropCode(GetType().Assembly, _jsInteropCode));

            NavigationManager.LocationChanged += OnLocationChanged;
        }

        private async void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            await ScrollToFragment();
        }

        private async Task ScrollToFragment()
        {
            var uri = new Uri(NavigationManager.Uri, UriKind.Absolute);
            var fragment = uri.Fragment;
            if (fragment.StartsWith('#'))
            {
                var elementId = fragment.Substring(1);
                var index = elementId.IndexOf(":~:", StringComparison.Ordinal);
                if (index > 0)
                {
                    elementId = elementId.Substring(0, index);
                }

                if (!string.IsNullOrEmpty(elementId))
                {                    
                    await JSRuntime.InvokeVoidAsync("BlazorScrollToId", elementId);
                }
            }
        }

        public static string GetEmbeddedJSInteropCode(Assembly assembly, string path)
        {
            using var stream = assembly.GetManifestResourceStream(path);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
