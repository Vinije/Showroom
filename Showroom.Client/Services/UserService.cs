using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Showroom.Models;

namespace Showroom.Client.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> manager)
        {
            _userManager = manager;
        }

        
        public async Task<User> GetUser(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }
    }
}
