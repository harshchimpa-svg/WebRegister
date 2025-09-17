using WebApiApplication.Interfaces;
using WebApiData.Repository;
using WebApiDomain.Model;

namespace WebApiApplication.Services
{
    public class BlogApplication : IBlogApplication
    {
        private readonly IBlogRepository _blogRepo;

        public BlogApplication(IBlogRepository blogRepo)
        {
            _blogRepo = blogRepo;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync() => await _blogRepo.GetAllAsync();

        public async Task<Blog?> GetByIdAsync(int id) => await _blogRepo.GetByIdAsync(id);

        public async Task<IEnumerable<Blog>> GetByUserIdAsync(int userId) => await _blogRepo.GetByUserIdAsync(userId);


        public async Task UpdateAsync(Blog blog)
        {
            _blogRepo.Update(blog);
            await _blogRepo.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var blog = await _blogRepo.GetByIdAsync(id);
            if (blog != null)
            {
                _blogRepo.Delete(blog);
                await _blogRepo.SaveAsync();
            }
        }

        Task IBlogApplication.AddAsync(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
