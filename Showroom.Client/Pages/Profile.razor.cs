using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Showroom.Client.Services;
using Showroom.Models;

namespace Showroom.Client.Pages
{
    public partial class Profile
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        protected async override Task OnInitializedAsync()
        {            
            var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            UserProfile = await UserService.GetUser(authenticationState.User.Identity.GetUserId());

            await base.OnInitializedAsync();
        }

        public User UserProfile { get; set; }
    }
}
