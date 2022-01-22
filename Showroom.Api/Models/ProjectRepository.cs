namespace Showroom.Api.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Showroom.Models;

    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProjectRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await _appDbContext.Projects.ToArrayAsync();
        }

        public async Task<IEnumerable<Project>> GetProjects(string ownerId)
        {
            var projects = await _appDbContext.Projects.ToListAsync();

            return projects.FindAll(project => project.OwnerId == ownerId);
        }

        public async Task<Project> GetProject(int id)
        {
            return await _appDbContext.Projects.FirstOrDefaultAsync(project => project.Id == id);
        }

        public async Task<Project> AddProject(Project project)
        {
            var result = await _appDbContext.Projects.AddAsync(project);

            await _appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Project> UpdateProject(int id, Project project)
        {
            var foundProject = await _appDbContext.Projects.FirstOrDefaultAsync(item => item.Id == id);

            if (foundProject == null)
            {
                return null;
            }

            foundProject.ProjectThumbnail = project.ProjectThumbnail;
            foundProject.ProjectPath = project.ProjectPath;
            foundProject.OwnerId = project.OwnerId;
            foundProject.Description = project.Description;
            foundProject.ProjectType = project.ProjectType;
            
            await _appDbContext.SaveChangesAsync();

            return foundProject;
        }

        public async Task<Project> DeleteProject(int projectId)
        {
            var result = await _appDbContext.Projects.FirstOrDefaultAsync(project => project.Id == projectId);

            if (result == null) return null;

            _appDbContext.Remove(result);
            await _appDbContext.SaveChangesAsync();

            return result;
        }
    }
}
