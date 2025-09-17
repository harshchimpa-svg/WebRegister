namespace WebApiDomain.Model
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public int CreatedById { get; set; }
        public Employee CreatedBy { get; set; } = default!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
