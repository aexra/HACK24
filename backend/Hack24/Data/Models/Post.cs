using System.ComponentModel.DataAnnotations;
using Web.Data.Models;

namespace Hack24.Data.Models;
public class Post
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }

    public virtual ICollection<User> Users { get; set; }
}
