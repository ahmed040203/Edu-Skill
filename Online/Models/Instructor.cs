using System.ComponentModel.DataAnnotations;

namespace Online.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Bio { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<Course> Course { get; set; }
    }
}
