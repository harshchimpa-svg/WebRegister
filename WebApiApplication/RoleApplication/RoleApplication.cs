using WebApiApplication.Interfaces;
using WebApiData.Repository;
using WebApiDomain.Model;

namespace WebApiApplication.Services
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepo;

        public RoleApplication(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public async Task<IEnumerable<Role>> GetAllRoles() => await _roleRepo.GetAllAsync();

        public async Task<Role?> GetByIdAsync(int id) => await _roleRepo.GetByIdAsync(id);

        public async Task AddAsync(Role role)
        {
            await _roleRepo.AddAsync(role);
            await _roleRepo.SaveAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            _roleRepo.Update(role);
            await _roleRepo.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var role = await _roleRepo.GetByIdAsync(id);
            if (role != null)
            {
                _roleRepo.Delete(role);
                await _roleRepo.SaveAsync();
            }
        }
    }
}
