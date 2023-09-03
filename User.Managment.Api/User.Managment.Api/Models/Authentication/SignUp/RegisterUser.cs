using System.ComponentModel.DataAnnotations;

namespace User.Managment.Api.Models.Authentication.SignUp
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "User name is mandatory")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required (ErrorMessage ="Password is mandatory")]
        public string? Password { get; set; }
    }
}
