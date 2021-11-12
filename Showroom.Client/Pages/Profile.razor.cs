using System.Collections.Generic;
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
        [Parameter]
        public string Username { get; set; }        

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public IProjectService ProjectService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            AuthenticatedUser = await UserService.GetUserById(authenticationState.User.Identity.GetUserId());                  
        }

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            UserProfile = await UserService.GetUserById(Username);

            UserProjects = await ProjectService.GetProjectsByUser(UserProfile.Id);
        }

        public AddProjectDialog ProjectDialog { get; set; }

        public User UserProfile { get; set; }

        public User AuthenticatedUser { get; private set; }

        public IEnumerable<Project> UserProjects { get; private set; }

        public void ShowAddProjectDialog()
        {
            ProjectDialog?.Show();
        }
    }
}
