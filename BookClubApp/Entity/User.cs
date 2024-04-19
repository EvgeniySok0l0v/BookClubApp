using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClubApp.Entity
{
    [Table("Users", Schema = "libraryDB")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName {
            get;
            set;

        }

        public User(string userName)
        {
            UserName = userName;
        }
        public ICollection<UserBook>? UserBooks { get; set; }
    }
}
