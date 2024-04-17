using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClubApp.Entity
{
    [Table("Books", Schema = "libraryDB")]
    public class Book
    {
        
        
        [Key]
        public int Id { get; set; }
        public string? Title 
        {
            get; set;
        }

        public Book(string title)
        {
            Title = title;
        }
        public ICollection<User>? Users { get; set; }
    }
}
