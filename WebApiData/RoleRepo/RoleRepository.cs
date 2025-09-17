using WebApiDomain.Model;

namespace WebApiData.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext context) : base(context) { }
    }
}
