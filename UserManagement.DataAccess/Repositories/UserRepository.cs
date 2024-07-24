using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UserManagement.DataAccess.Repositories.UserRepository;
using UserManagement.DataAccess.Entities;

namespace UserManagement.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementDbContext _context;
        public UserRepository(UserManagementDbContext context)
        {
            _context = context;
        }


        public async Task<UserEntity> AddUserAsync(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserEntity> UpdateUserAsync(UserEntity user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<UserEntity>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> GetActiveUserCountAsync()
        {
            return await _context.Users.CountAsync(u => u.isActive);
        }

        public async Task<IEnumerable<UserEntity>> GetUsersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Users
                                 .Where(u => u.CreatedDate >= startDate && u.CreatedDate <= endDate)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<UserEntity>> GetActiveUsersAsync()
        {
            return await _context.Users.Where(x=>x.isActive==true).ToListAsync();
        }
    }
}

