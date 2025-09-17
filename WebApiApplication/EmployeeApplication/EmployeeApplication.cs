using WebApiApplication.DTO;
using WebApiApplication.Interfaces;
using WebApiData.Repository;
using WebApiDomain.Model;

namespace WebApiApplication.Services
{
    public class EmployeeApplication : IEmployeeApplication
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeApplication(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<Employee?> GetEmployeeByEmail(string email)
        {
            return await _employeeRepo.GetByEmailAsync(email);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeRepo.GetAllAsync();
        }


        public async Task<Employee> RegisterAsync(RegisterDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.PasswordHash,
                RoleId = 2
            };

            await _employeeRepo.AddAsync(employee);
            await _employeeRepo.SaveAsync();
            return employee;
        }


        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var emp = await _employeeRepo.GetByEmailAsync(dto.Email);
            if (emp == null || emp.PasswordHash != dto.Password)
                return null;

            return $"TOKEN_FOR_{emp.Email}_{emp.Role}";
        }

        public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            var emp = await _employeeRepo.GetByIdAsync(userId);
            if (emp == null || emp.PasswordHash != oldPassword)
                return false;

            emp.PasswordHash = newPassword;
            _employeeRepo.Update(emp);
            await _employeeRepo.SaveAsync();
            return true;
        }


        public async Task UpdateAsync(Employee employee)
        {
            _employeeRepo.Update(employee);
            await _employeeRepo.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await _employeeRepo.GetByIdAsync(id);
            if (emp != null)
            {
                _employeeRepo.Delete(emp);
                await _employeeRepo.SaveAsync();
            }
        }
    }
}
