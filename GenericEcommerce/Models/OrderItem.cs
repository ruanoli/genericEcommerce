using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericEcommerce.Models
{
    public class OrderItem
    {
        public long OrderItemId { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public long GameId { get; set; }
        [ForeignKey("GameId")]
        public virtual Game? Game { get; set; }

        public long OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
    }
}
