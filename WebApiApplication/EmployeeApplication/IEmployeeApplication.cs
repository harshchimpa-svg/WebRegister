using WebApiApplication.DTO;
using WebApiDomain.Model;

public interface IEmployeeApplication
{
    Task<Employee?> GetEmployeeByEmail(string email);
    Task<IEnumerable<Employee>> GetAllEmployees();

    Task<Employee> RegisterAsync(RegisterDto dto);
    Task<string?> LoginAsync(LoginDto dto);
    Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);

    Task UpdateAsync(Employee employee);
    Task DeleteAsync(int id);
}
