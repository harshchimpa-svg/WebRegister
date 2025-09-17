using WebApiDomain.Model;

namespace WebApiApplication.Interfaces
{
    public interface IBlogApplication
    {
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);
        Task<IEnumerable<Blog>> GetByUserIdAsync(int userId);
        Task AddAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task DeleteAsync(int id);
    }
}
