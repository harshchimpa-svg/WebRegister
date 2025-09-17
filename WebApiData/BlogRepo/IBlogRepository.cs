using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiDomain.Model;

namespace WebApiData.Repository
{
    public interface IBlogRepository : IRepository<Blog>
    {
        new Task AddAsync(global::WebApiDomain.Model.Blog blog);

        Task<IEnumerable<Blog>> GetByUserIdAsync(int userId);
    }
}
