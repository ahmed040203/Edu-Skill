using System.ComponentModel.DataAnnotations;

namespace Online.ViewModels.Auth
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The password must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }

        public bool IsAgree { get; set; }


        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime BirthDate { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

    }
}
