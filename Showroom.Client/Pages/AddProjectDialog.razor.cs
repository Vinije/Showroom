using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Showroom.Client.Services;
using Showroom.Models;
using Showroom.Presentation.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;

namespace Showroom.Client.Pages
{
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Mime;
    using Microsoft.CodeAnalysis.CSharp;

    public partial class AddProjectDialog : IVisibleProjectDialog<IProject>
    {
        [Parameter]
        public EventCallback AddProjectCloseEvent { get; set; }

        [Parameter]
        public Action<string> ErrorHandler { get; set; }

        [Inject] 
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public IProjectService ProjectService { get; set; }

        public IProject NewProject { get; set; }

        public bool IsVisible { get; set; }

        public bool IsEditMode { get; set; }

        public string Title => IsEditMode ? "Edit Project" : "Add Project";

        public void Show()
        {
            IsVisible = true;
            ResetPage();
        }

        public void Show(IProject project)
        {
            Show();

            IsEditMode = true;

            NewProject = project;
        }

        public void Hide()
        {
            IsVisible = false;
        }

        public void ResetPage()
        {
            NewProject = new Project();

            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

            if (authenticationState?.User?.Identity?.IsAuthenticated == true)
            {
                NewProject.OwnerId = authenticationState.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            else
            {
                ErrorHandler?.Invoke("Could not add a project - user not authenticated");
                return;
            }

            try
            {
                await UpdateProjectRepository();
            }
            catch (Exception e)
            {
                ErrorHandler?.Invoke(e.ToString());
            }

            Hide();

            await AddProjectCloseEvent.InvokeAsync();

            StateHasChanged();
        }

        private async Task OnThumbnailFileChange(InputFileChangeEventArgs e)
        {
            //TODO: move this to FileService

            NewProject.ProjectThumbnail = e.File.Name;

            await using var fileStream = new FileStream($"./wwwroot/Images/{e.File.Name}", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            await e.File.OpenReadStream(1024 * 1024 * 5).CopyToAsync(fileStream);

            StateHasChanged();
        }

        private async Task UpdateProjectRepository()
        {
            if (IsEditMode)
            {
                await ProjectService.EditProject(NewProject.Id, NewProject);
            }
            else
            {
                await ProjectService.AddNewProject(NewProject);
            }
        }
    }
}
