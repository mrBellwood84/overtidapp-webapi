using System.ComponentModel.DataAnnotations;

namespace Identity.Data
{
    /// <summary>
    /// DTO for signin requests
    /// </summary>
    public class SignInDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,20}$", ErrorMessage = "Password requirement error")]
        public string Password { get; set; }
    }
}
