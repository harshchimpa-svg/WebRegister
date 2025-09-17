using WebApiDomain.Model;

namespace WebApiData.Repository
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<IEnumerable<Blog>> GetByUserIdAsync(int userId);
    }
}
