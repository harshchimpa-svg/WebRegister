using System.ComponentModel.DataAnnotations;

namespace WebApiDomain.Model;

public class Role
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
}
