using Microsoft.AspNetCore.Mvc;
using MyCart.Service.Dtos;
using MyCart.Service.Dtos.UserLogins;
using MyCart.Service.UserLogins;

namespace MyCart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;

        public UserLoginController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

       /* [HttpGet]
        public async Task<IActionResult> GetAllUserLogins()
        {
            var userLogins = await _userLoginService.GetAllUserLoginsAsync();
            return Ok(userLogins);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserLoginById(int id)
        {
            var userLogin = await _userLoginService.GetUserLoginByIdAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }
            return Ok(userLogin);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserLogin([FromBody] UserLoginDto userLoginDto)
        {
             await _userLoginService.AddUserLoginAsync(userLoginDto);
            return CreatedAtAction(nameof(GetUserLoginById), new { id = userLoginDto.Id }, userLoginDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserLogin(int id, [FromBody] UserLoginDto userLoginDto)
        {
            if (id != userLoginDto.Id)
            {
                return BadRequest("UserLogin ID mismatch");
            }

            await _userLoginService.UpdateUserLoginAsync(id, userLoginDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLogin(int id)
        {
            await _userLoginService.DeleteUserLoginAsync(id);
            return NoContent();
        }*/
        [HttpPost("userLogin")]
        public async Task<ActionResult> UserLogin([FromForm]LoginDto loginDto)
        {
           var data=await _userLoginService.UserLogin(loginDto);
            return Ok(data.Token);
        }
    }
}
