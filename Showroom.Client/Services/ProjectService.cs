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
    }
}
