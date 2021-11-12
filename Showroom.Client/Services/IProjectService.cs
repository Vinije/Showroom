using System.Collections.Generic;
using System.Threading.Tasks;
using Showroom.Models;

namespace Showroom.Client.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjects();

        Task<IEnumerable<Project>> GetProjectsByUser(string userId);

        Task AddNewProject(Project newProject);
    }
}