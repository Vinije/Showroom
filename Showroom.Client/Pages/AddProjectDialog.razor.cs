using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Showroom.Client.Services;
using Showroom.Models;
using Showroom.Presentation.Interfaces;

namespace Showroom.Client.Pages
{
    public partial class AddProjectDialog : IVisibleDialog
    {
        [Parameter]
        public EventCallback AddProject_CloseEvent { get; set; }

        [Parameter]
        public Action<string> ErrorHandler { get; set; }

        [Inject]
        public IProjectService ProjectService { get; set; }

        public Project NewProject { get; set; }

        public bool IsVisible { get; set; }

        public void Show()
        {
            IsVisible = true;
            ResetPage();
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
            try
            {
                await ProjectService.AddNewProject(NewProject);
            }
            catch (Exception e)
            {
                ErrorHandler?.Invoke(e.ToString());
            }

            Hide();

            await AddProject_CloseEvent.InvokeAsync();

            StateHasChanged();
        }
    }
}
