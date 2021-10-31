using System.Collections.Generic;
using System.Threading.Tasks;
using Showroom.Models;

namespace Showroom.Client.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjects();
    }
}