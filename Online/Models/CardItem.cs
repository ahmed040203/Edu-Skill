using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Online.Models
{
    public class CardItem
    {
        [Key]
        public int CartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        // Foreign Key
        public int CourseId {  get; set; }
        
        public int? StudentId { get; set; }
        public int Quantity { get; set; } = 1;

        public DateTime CreatedDate { get; set; }

        // Navigation Properties
        public Student? Student { get; set; }
        public Course Course { get; set; }
    }
}
