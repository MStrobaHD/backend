using ESA_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDatabaseContext _context;

        public AuthRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> LoginAsync(string username)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Username == username);
            return user;
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _context.User.AnyAsync(x => x.Username == username);
        }
    }
}
