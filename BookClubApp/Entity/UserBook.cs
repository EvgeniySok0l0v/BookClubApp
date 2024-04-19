using System.ComponentModel.DataAnnotations.Schema;

namespace BookClubApp.Entity
{
    [Table("UserBook", Schema = "libraryDB")]
    public class UserBook
    {
        public UserBook(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }

        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
