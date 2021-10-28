namespace Showroom.Api.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Showroom.Models;

    public class UserRepository : IUsersRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _appDbContext.Users.ToArrayAsync();
        }

        public async Task<User> GetUser(int userId)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> AddUser(User user)
        {
            var result = await _appDbContext.Users.AddAsync(user);

            await _appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var foundUser = await _appDbContext.Users.FirstOrDefaultAsync(user => user.UserId == id);

            if (foundUser == null)
            {
                return null;
            }

            foundUser.FirstName = user.FirstName;
            foundUser.LastName = user.LastName;
            foundUser.Email = user.Email;
            foundUser.DateOfBirth = user.DateOfBirth;
            foundUser.PhotoPath = user.PhotoPath;

            await _appDbContext.SaveChangesAsync();

            return foundUser;
        }

        public async Task<User> DeleteUser(int userId)
        {
            var result = await _appDbContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);

            if (result == null) return null;
            
            _appDbContext.Remove(result);
            await _appDbContext.SaveChangesAsync();

            return result;
        }
    }
}
