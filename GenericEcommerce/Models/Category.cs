namespace GenericEcommerce.Models
{
    public class Category
    {
        public int IdCategory { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IList<Game> Games { get; set; }
    }
}
