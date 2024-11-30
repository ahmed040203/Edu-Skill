
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Online.Models
{
    public class Users : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public bool IsAgree { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    }
}
