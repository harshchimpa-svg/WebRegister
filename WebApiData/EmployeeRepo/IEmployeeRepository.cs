using System.Threading.Tasks;
using WebApiDomain.Model;

namespace WebApiData.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee?> GetByEmailAsync(string email);
    }
}
