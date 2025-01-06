using Microsoft.AspNetCore.Mvc;
using MyCart.Service.Dtos;
using MyCart.Service.Users;

namespace MyCart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        // Constructor injection for UserService
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Get a user by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync(); // Assuming the service has this method.
            if (users == null || users.Count == 0)
            {
                return NotFound(new { message = "No users found." });
            }

            return Ok(users);
        }


        // Create a new user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserInDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest(new { message = "Invalid user data." });
            }

            var createdUser = await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        // Update an existing user
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserInDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest(new { message = "Invalid user data." });
            }

            var updatedUser = await _userService.UpdateUserAsync(id, userDto);
            if (updatedUser == null)
            {
                return NotFound(new { message = "User not found." });
            }

            return Ok(updatedUser);
        }

        // Soft delete a user (set IsActive to false)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deletedUser = await _userService.DeleteUserAsync(id);
            if (deletedUser == null)
            {
                return NotFound(new { message = "User not found." });
            }

            return Ok(deletedUser); // Returning the deactivated user as response
        }
    }
}
