using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using MyCart.Repository.Products.Dtos.ChangePassword;
using MyCart.Service.Dtos;
using MyCart.Service.Dtos.UserLogins;
using MyCart.Service.UserLogins;
using MyCart.Service.Users;
using System.Security.Claims;

namespace MyCart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        private readonly IUserService _userService;

        public UserLoginController(IUserLoginService userLoginService, IUserService userService)
        {
            _userLoginService = userLoginService;
            _userService = userService;
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
        [Authorize]
        [HttpPut("Change-password")]
        public async Task<ActionResult> ChangePassword([FromForm]ChangePasswordDto changePasswordDto)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue("Id"));
            if (changePasswordDto.OldPassword==changePasswordDto.NewPassword )
            {
                return BadRequest("Old password and new Password are same..");
            }
            if(changePasswordDto.NewPassword!=changePasswordDto.ConfirmPassword ) 
            {
                return BadRequest("New password and confirm password is not match");
            }


            var changepassword = await _userLoginService.UserLoginAsync(userId, changePasswordDto);
            if (changepassword.IsSuccess == true)
            {
                return Ok(changepassword.Message);
            }
            return BadRequest(changepassword.Message);
        }
        [HttpPost("Forget-Password")]
        public async Task<ActionResult> ForgetPassword(string email)
        {
            var user= await _userService.GetByEmail(email);
            if (user.IsSuccess)
            {
                return Ok(user.Message);
            }
            return BadRequest(user.Message);
        }
        
    }
}
