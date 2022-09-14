namespace PetShop.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }

    }
}
