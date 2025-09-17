using WebApiDomain.Model;

namespace WebApiApplication.Interfaces
{
    public interface IRoleApplication
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role?> GetByIdAsync(int id);
        Task AddAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(int id);
    }
}
