using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserManagement.Business;
using UserManagment.Contract.Dtos;
using UserManagment.Contract.Request;

namespace UserManagment.API.Controllers
{
    //http://localhost:5020
    [Route("user")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(UserManagement.Business.IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users =  await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreate userCreate)
        {
            var userDto = await _userService.CreateUserAsync(userCreate);
            return Ok(userDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdate userUpdate)
        {
            var updatedUser = await _userService.UpdateUserAsync(userUpdate);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }



        [HttpGet("active-count")]
        public async Task<IActionResult> GetActiveUserCount()
        {
            var count = await _userService.GetAllUsersAsync();
            return Ok(count);

        }
        [HttpGet("active-users")]
        public async Task<IActionResult> GetActiveUsers()
        {
            var count = await _userService.GetActiveUsers();
            return Ok(count);
        }

        [HttpGet("by-date-range")]
        public async Task<IActionResult> GetUsersByDateRange( DateTime startDate, DateTime endDate)
        {
            var users = await _userService.GetUsersByDateRangeAsync(startDate, endDate);
            Debug.WriteLine("SDs"+startDate);
            return Ok(users);
        }
    }
}

