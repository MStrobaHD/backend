using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.UserRepository.NormalUser
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDatabaseContext _context;

        public UserRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public Task<User> GetUserBadgesAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserDataAsync(int userId)
        {
            return await _context.User
                .Where(user => user.Id == userId)
                .SingleOrDefaultAsync();
        }

        public Task<User> GetUserMarksAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserStatisticsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserVerdictAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserDataAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetUserFromBaseAsync(int id)
        {
            var userToBase = await _context.User.FindAsync(id);
            return userToBase;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.User.ToListAsync();
        }
    }
}
