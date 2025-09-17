using Microsoft.EntityFrameworkCore;
using WebApiDomain.Model;

namespace WebApiData.Repository
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        private readonly DataContext _context;

        public BlogRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetByUserIdAsync(int userId)
        {
            return await _context.Blogs
                .Where(b => b.CreatedById == userId)
                .ToListAsync();
        }
    }
}
