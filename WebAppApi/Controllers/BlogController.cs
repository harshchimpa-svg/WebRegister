using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiApplication.DTO;
using WebApiData;
using WebApiData.Migrations;
using WebApiData.Repository;


namespace WebAppApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly Repository _user;
        private readonly IConfiguration _configuration;
        public UserController(Repository user, IConfiguration configuration)
        {
            _user = user;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogDto dto)
        {
            var userId = int.Parse(User.FindFirst("UserId")!.Value);

            var blog = new blog
            {
                Title = dto.Title,
                Content = dto.Content,
            };


            await _user.SaveChangesAsync();
            return Ok(blog);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _user.Blogs.Include(b => b.CreatedBy).ToListAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var blog = await _user.Blogs.Include(b => b.CreatedBy).FirstOrDefaultAsync(b => b.Id == id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        [Authorize]

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BlogDto dto)
        {
            var userId = int.Parse(User.FindFirst("UserId")!.Value);
            var blog = await _user.Blogs.FindAsync(id);
            if (blog == null) return NotFound();
            if (blog.CreatedById != userId) return Forbid();

            blog.Title = dto.Title;
            blog.Content = dto.Content;
            await _user.SaveChangesAsync();
            return Ok(blog);
        }
    }
}
