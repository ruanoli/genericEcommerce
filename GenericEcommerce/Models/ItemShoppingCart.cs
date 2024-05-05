using System.ComponentModel.DataAnnotations;

namespace GenericEcommerce.Models
{
    public class ItemShoppingCart
    {
        public int ItemShoppingCartId { get; set; }
        public Game? Game { get; set; }
        public int Quantity { get; set; }
        [StringLength(200)]
        public string? ShoppingCartId { get; set; }
    }
}
