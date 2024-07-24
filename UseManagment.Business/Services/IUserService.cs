using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagment.Contract.Dtos;
using UserManagment.Contract.Request;

namespace UserManagement.Business
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserCreate userCreate);
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> UpdateUserAsync(UserUpdate userUpdate);
        Task DeleteUserAsync(int userId);
        

        Task<IEnumerable<UserDto>> GetActiveUsers();
        Task<IEnumerable<UserDto>> GetUsersByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
