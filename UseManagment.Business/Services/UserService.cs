using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using UserManagment.Contract.Dtos;
using UserManagement.DataAccess.Entities;
using UserManagement.DataAccess.Repositories;
using UserManagment.Contract.Request;

namespace UserManagement.Business
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly RabbitMQPublisher _rabbitMQPublisher;

        public UserService(IUserRepository userRepository, IMapper mapper, RabbitMQPublisher rabbitMQPublisher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _rabbitMQPublisher = rabbitMQPublisher;
        }


        public async Task<UserDto> CreateUserAsync(UserCreate userCreate)
        {
            var userEntity = _mapper.Map<UserEntity>(userCreate);
            var createdUser = await _userRepository.AddUserAsync(userEntity);
            return _mapper.Map<UserDto>(createdUser);


        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var userEntities = await _userRepository.GetUsersAsync();
            return _mapper.Map<List<UserDto>>(userEntities);
        }

        public async Task<UserDto> UpdateUserAsync(UserUpdate userUpdate)
        {
            var userEntity = _mapper.Map<UserEntity>(userUpdate);
            var updatedUser = await _userRepository.UpdateUserAsync(userEntity);
            return _mapper.Map<UserDto>(updatedUser);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<IEnumerable<UserDto>> GetActiveUsers()
        {
            var users =  await _userRepository.GetActiveUsersAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return userDtos;
        }

        public async Task<IEnumerable<UserDto>> GetUsersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var users = await _userRepository.GetUsersByDateRangeAsync(startDate,endDate);
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return userDtos;
        }
    }

    
}
