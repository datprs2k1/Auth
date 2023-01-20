using System.ComponentModel.DataAnnotations;

namespace POST.Models
{
    public class SigninModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
