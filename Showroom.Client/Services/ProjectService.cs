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

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await _httpClient.GetFromJsonAsync<Project[]>("api/project");
        }

        public async Task<IEnumerable<Project>> GetProjectsByUser(string userId)
        {
            return await _httpClient.GetFromJsonAsync<Project[]>($"api/project/GetProjectsByUser/{userId}");
        }

        public async Task AddNewProject(Project newProject)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync<Project>($"api/project", newProject);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Could not create a new project.");
            }
        }
    }
}
