namespace Showroom.Services
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Showroom.Models;

    public interface IUserDataService
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int id);

        Task UpdateUser(int id, User user);

        Task<User> AddUser(User user);

        Task<HttpResponseMessage> DeleteUser(int ind);
    }
}
