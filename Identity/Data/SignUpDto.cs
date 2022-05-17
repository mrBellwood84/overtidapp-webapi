using System.ComponentModel.DataAnnotations;

namespace Identity.Data
{
    /// <summary>
    /// DTO for signup requests
    /// </summary>
    public class SignUpDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,20}$", ErrorMessage = "Password requirement error")]
        public string Password { get; set; }
    }
}
