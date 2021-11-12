namespace Showroom.Api.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Showroom.Models;

    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjects(string ownerId);

        Task<IEnumerable<Project>> GetProjects();
        
        Task<Project> GetProject(int id);
        
        Task<Project> AddProject(Project project);
        
        Task<Project> UpdateProject(int id, Project project);
        
        Task<Project> DeleteProject(int projectId);
    }
}
