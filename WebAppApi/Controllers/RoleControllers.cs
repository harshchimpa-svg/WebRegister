using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiApplication.DTO;
using WebApiDomain.Model;
using WebApiData.Repository;

namespace WebAppApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly Repository _user;
        private readonly IConfiguration _configuration;
        public UserController(Repository user, IConfiguration configuration)
        {
            _user = user;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleDto dto)
        {
            var role = new Role { Name = dto.Name };
            await _user.AddAsync(role);
            await _user.SaveAsync();
            return Ok(role);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _user.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _user.GetByIdAsync(id);
            if (role == null) return NotFound("Role not found");
            return Ok(role);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleDto dto)
        {
            var role = await _user.GetByIdAsync(id);
            if (role == null) return NotFound("Role not found");

            role.Name = dto.Name;
            _user.Update(role);
            await _user.SaveAsync();

            return Ok(role);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _user.GetByIdAsync(id);
            if (role == null) return NotFound("Role not found");

            _user.Delete(role);
            await _user.SaveAsync();

            return Ok("Role deleted successfully");
        }
    }
}
