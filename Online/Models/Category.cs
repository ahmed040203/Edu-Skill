using System.ComponentModel.DataAnnotations;

namespace Online.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        // Navigation Properties
        public ICollection<Course> Course { get; set; }
    }
}
