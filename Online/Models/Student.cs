using System.ComponentModel.DataAnnotations;

namespace Online.Models
{
    public class Student
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public DateTime DateRegistered { get; set; }= DateTime.Now;

        
        public CardItem? cardItem { get; set; }
    }
}
