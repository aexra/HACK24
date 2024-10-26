using System.ComponentModel.DataAnnotations;
using Hack24.Data.Models;

namespace Hack24.Data.Models;
public class Post
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }

    public virtual ICollection<User> Users { get; set; }
}
