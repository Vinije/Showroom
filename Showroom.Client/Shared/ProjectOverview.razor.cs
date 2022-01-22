using System.Security.Claims;

namespace Showroom.Client.Shared
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Showroom.Client.Pages;
    using Showroom.Client.Services;
    using Showroom.Models;
    using Showroom.Presentation.Interfaces;

    public partial class ProjectOverview
    {
        [Parameter] 
        public IProject Project { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject] public IProjectService ProjectService { get; set; }

        public bool IsUserAuthorizedToEdit { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (Project == null)
            {
                return;
            }

            var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            IsUserAuthorizedToEdit = authenticationState.User.FindFirstValue(ClaimTypes.NameIdentifier) == Project.OwnerId;
        }

        public IVisibleProjectDialog<IProject> ProjectDialog { get; set; }

        public bool IsHovered { get; set; }

        private void OnMouseOver()
        {
            if (IsHovered) return;

            IsHovered = true;
            StateHasChanged();
        }

        private void OnMouseLeave()
        {
            if (!IsHovered) return;

            IsHovered = false;
            StateHasChanged();
        }

        private async Task DeleteProject()
        {
            await ProjectService.DeleteProject(Project.Id);
        }

        private void EditProject()
        {
            ProjectDialog.Show(Project);
        }

        private void OnCloseProjectDialog()
        {
            StateHasChanged();
        }
    }
}
