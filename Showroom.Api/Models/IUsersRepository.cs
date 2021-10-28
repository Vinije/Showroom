namespace Showroom.Api.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Showroom.Models;

    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int userId);
        Task<User> GetUserByEmail(string email);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(int id, User user);
        Task<User> DeleteUser(int userId);
    }
}
