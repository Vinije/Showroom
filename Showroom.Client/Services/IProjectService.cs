using System.Collections.Generic;
using System.Threading.Tasks;
using Showroom.Models;

namespace Showroom.Client.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<IProject>> GetProjects();

        Task<IEnumerable<IProject>> GetProjectsByUser(string userId);

        Task AddNewProject(IProject newProject);

        Task DeleteProject(int projectId);

        Task EditProject(int projectId, IProject project);
    }
}