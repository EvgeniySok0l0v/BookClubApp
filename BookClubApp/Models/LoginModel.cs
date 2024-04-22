using System.ComponentModel.DataAnnotations;

namespace BookClubApp.Models
{
    /// <summary>
    /// LoginModel
    /// </summary>
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Username")]
        public string? UserName { get; set; }
    }
}
