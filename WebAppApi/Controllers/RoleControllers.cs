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
        private readonly IRoleRepository _roleRepo;

        public RoleController(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleRepo.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleRepo.GetByIdAsync(id);
            if (role == null) return NotFound("Role not found");
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleDto dto)
        {
            var role = new Role { Name = dto.Name };
            await _roleRepo.AddAsync(role);
            await _roleRepo.SaveAsync();
            return Ok(role);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleDto dto)
        {
            var role = await _roleRepo.GetByIdAsync(id);
            if (role == null) return NotFound("Role not found");

            role.Name = dto.Name;
            _roleRepo.Update(role);
            await _roleRepo.SaveAsync();

            return Ok(role);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleRepo.GetByIdAsync(id);
            if (role == null) return NotFound("Role not found");

            _roleRepo.Delete(role);
            await _roleRepo.SaveAsync();

            return Ok("Role deleted successfully");
        }
    }
}
