using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiApplication.DTO;
namespace WebAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IEmployeeApplication _employeeApp;

        public AuthController(IEmployeeApplication employeeApp)
        {
            _employeeApp = employeeApp;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _employeeApp.RegisterAsync(dto);
            return Ok(new { message = "Registration successful" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _employeeApp.LoginAsync(dto);
            return Ok(new { token });
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var result = await _employeeApp.ChangePasswordAsync(userId, oldPassword, newPassword);
            if (!result)
                return BadRequest("Password change failed");
            return Ok("Password changed successfully");
        }


    }
}
