using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Showroom.Models;
using System.Net.Http.Json;

namespace Showroom.Client.Services
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<IProject>> GetProjects()
        {
            return await _httpClient.GetFromJsonAsync<Project[]>("api/project");
        }

        public async Task<IEnumerable<IProject>> GetProjectsByUser(string userId)
        {
            return await _httpClient.GetFromJsonAsync<Project[]>($"api/project/GetProjectsByUser/{userId}");
        }

        public async Task AddNewProject(IProject newProject)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync<Project>($"api/project", newProject as Project);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Could not create a new project.");
            }
        }

        public async Task DeleteProject(int projectId)
        {
            var httpResponse = await _httpClient.DeleteAsync($"api/project/{projectId}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Could not delete a project.");
            }
        }

        public async Task EditProject(int projectId, IProject project)
        {
            var httpResponse = await _httpClient.PutAsJsonAsync($"api/project/{projectId}", project as Project);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Could not edit a project.");
            }
        }
    }
}
