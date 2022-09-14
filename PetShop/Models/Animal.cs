using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Use letters only please")]
        [Required]
        [StringLength(10)]
        public string? Name { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Age { get; set; }
        [Required]
        public string? PictureSrc { get; set; }
        [Required]
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
