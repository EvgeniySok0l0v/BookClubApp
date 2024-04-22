using System.ComponentModel.DataAnnotations.Schema;

namespace BookClubApp.Entity
{
    /// <summary>
    /// UserBook table link
    /// </summary>
    /// <param name="userId">user Id</param>
    /// <param name="bookId">book Id</param>
    [Table("UserBook", Schema = "libraryDB")]
    public class UserBook(int userId, int bookId)
    {
        public int UserId { get; set; } = userId;
        public User User { get; set; }
        public int BookId { get; set; } = bookId;
        public Book Book { get; set; }
    }
}
