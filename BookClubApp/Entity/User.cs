using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClubApp.Entity
{
    /// <summary>
    /// User entity
    /// </summary>
    /// <param name="userName">username</param>
    [Table("Users", Schema = "libraryDB")]
    public class User(string userName)
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; } = userName;
        public ICollection<UserBook>? UserBooks { get; set; }
    }
}
