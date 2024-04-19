using System.ComponentModel.DataAnnotations;

namespace BookClubApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Username")]
        public string? UserName { get; set; }
    }
}
