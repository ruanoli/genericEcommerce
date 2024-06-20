using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericEcommerce.Models
{
    public class ItemShoppingCart
    {
        public int ItemShoppingCartId { get; set; }
        public long GameId { get; set; }
        [ForeignKey("GameId")]
        public Game? Game { get; set; }
        public int Quantity { get; set; }
        [StringLength(200)]
        public string? ShoppingCartId { get; set; }
    }
}
