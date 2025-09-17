using Microsoft.EntityFrameworkCore;
using WebApiDomain.Model;

namespace WebApiData.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _context.Employee.FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}
