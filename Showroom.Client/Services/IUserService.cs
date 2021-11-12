using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Showroom.Models;

namespace Showroom.Client.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(string userId);

        Task<User> GetUserByName(string userName);
    }
}
