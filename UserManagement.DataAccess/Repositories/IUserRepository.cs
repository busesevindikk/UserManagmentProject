using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.DataAccess.Entities;

namespace UserManagement.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> AddUserAsync(UserEntity user);
        Task<UserEntity> UpdateUserAsync(UserEntity user);
        Task DeleteUserAsync(int userId);
        Task<UserEntity> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserEntity>> GetUsersAsync();
        Task<int> GetActiveUserCountAsync();

        Task<IEnumerable<UserEntity>> GetActiveUsersAsync();

        Task<IEnumerable<UserEntity>> GetUsersByDateRangeAsync(DateTime startDate, DateTime endDate);


    }
}
