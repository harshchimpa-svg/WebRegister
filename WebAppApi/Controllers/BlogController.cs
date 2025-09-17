using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiApplication.DTO;
using WebApiData;
using WebApiData.Migrations;

namespace WebAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly DataContext _db;
        public BlogController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _db.Blogs.Include(b => b.CreatedBy).ToListAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var blog = await _db.Blogs.Include(b => b.CreatedBy).FirstOrDefaultAsync(b => b.Id == id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(BlogDto dto)
        {
            var userId = int.Parse(User.FindFirst("UserId")!.Value);

            var blog = new blog
            {
                Title = dto.Title,
                Content = dto.Content,
                CreatedById = userId
            };


            await _db.SaveChangesAsync();
            return Ok(blog);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BlogDto dto)
        {
            var userId = int.Parse(User.FindFirst("UserId")!.Value);
            var blog = await _db.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            if (blog.CreatedById != userId) return Forbid();

            blog.Title = dto.Title;
            blog.Content = dto.Content;
            await _db.SaveChangesAsync();
            return Ok(blog);
        }
    }
}
