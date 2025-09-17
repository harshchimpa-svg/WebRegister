using WebApiDomain.Model;

namespace WebApiData.Repository
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task AddAsync(global::WebApiDomain.Model.Role role);
    }
}
