namespace GenericEcommerce.Models
{
    public class Game
    {
        public long IdGame { get; set; }
        public string? Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? ImageURL { get; set; }
        public string? ImageURLThumbnail { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
