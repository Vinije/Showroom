namespace Showroom.Services
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Showroom.Models;

    public class UserDataService : IUserDataService
    {
        private readonly HttpClient _httpClient;

        public UserDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _httpClient.GetJsonAsync<User[]>("api/user");
        }

        public async Task<User> GetUser(int id)
        {
            return await _httpClient.GetJsonAsync<User>($"api/user/{id}");
        }

        public async Task UpdateUser(int id, User user)
        {
            await _httpClient.PutJsonAsync($"api/user/{id}", user);
        }

        public async Task<User> AddUser(User user)
        {
            return await _httpClient.PostJsonAsync<User>("api/user", user);
        }

        public async Task<HttpResponseMessage> DeleteUser(int id)
        {
            return await _httpClient.DeleteAsync($"api/user/{id}");
        }
    }
}
