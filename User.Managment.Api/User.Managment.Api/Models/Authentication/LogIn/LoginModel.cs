using System.ComponentModel.DataAnnotations;

namespace User.Managment.Api.Models.Authentication.LogIn
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is mandatory")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        public string? Password { get; set; }

    }
}
