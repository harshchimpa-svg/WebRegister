using System.Threading.Tasks;
using WebApiDomain.Model;

namespace WebApiData.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        new Task AddAsync(global::WebApiDomain.Model.Employee employee);
        Task<Employee?> GetByEmailAsync(string email);
        new void Update(global::WebApiDomain.Model.Employee employee);
    }
}
