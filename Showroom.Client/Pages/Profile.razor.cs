using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Showroom.Client.Services;
using Showroom.Models;

namespace Showroom.Client.Pages
{
    public partial class Profile
    {
        [Parameter]
        public string Username { get; set; }        

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public IProjectService ProjectService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            string userId = authenticationState.User.FindFirstValue(ClaimTypes.NameIdentifier);

            AuthenticatedUser = await UserService.GetUserById(userId);                  
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            UserProfile = await UserService.GetUserById(Username);

            UserProjects = await ProjectService.GetProjectsByUser(UserProfile.Id);

            StateHasChanged();
        }

        public AddProjectDialog ProjectDialog { get; set; }

        public User UserProfile { get; set; }

        public User AuthenticatedUser { get; private set; }

        public IEnumerable<IProject> UserProjects { get; private set; }

        public void ShowAddProjectDialog()
        {
            ProjectDialog?.Show();
        }

        private async Task AddDialogClosed()
        {
            UserProjects = await ProjectService.GetProjectsByUser(UserProfile.Id);

            StateHasChanged();
        }
    }
}
