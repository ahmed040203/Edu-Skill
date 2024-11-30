using System.ComponentModel.DataAnnotations;

namespace Online.ViewModels.Auth
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
