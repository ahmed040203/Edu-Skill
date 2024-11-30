using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(10)")]
        public int Price { get; set; }
        public string Image {  get; set; }

        [NotMapped]
        public IFormFile clientFile { get; set; }

        // Foreign Keys
        [Required]
        public float Hours  { get; set; }
        [Required]
        public int Lesson { get; set; }
        public int CategoryId { get; set; }
        
        public int InstructorId { get; set; }

        // Navigation Properties
        
        public Category? Category { get; set; }
        public Instructor? Instructor { get; set; }
        public ICollection<CardItem> cardItem { get; set; }
    }
}
