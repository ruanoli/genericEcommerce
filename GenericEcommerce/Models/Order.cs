
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericEcommerce.Models
{
    public class Order
    {
        public long OrderId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(50)]
        public string? Name { get; set; }
       
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(50)]
        public string? Surname { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        [Display(Name = "CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string? Cep { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        public string? Telephone { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "O e-mail não possui um formato correto")]
        public string? Email { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalOrderValue { get; set; }

        [ScaffoldColumn(false)]
        public int TotalOrderItems { get; set; }

        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDispatched { get; set; }

        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDeliveredTo { get; set; }

        public IList<OrderItem>? OrderItems { get; set; }
    }
}
