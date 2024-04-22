using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClubApp.Entity
{
    /// <summary>
    /// Book entity
    /// </summary>
    /// <param name="title">title</param>
    [Table("Books", Schema = "libraryDB")]
    public class Book(string title)
    {
        
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; } = title;
        public ICollection<UserBook>? UserBooks { get; set; }
    }
}
