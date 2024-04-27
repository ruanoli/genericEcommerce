using System.ComponentModel.DataAnnotations;

namespace GenericEcommerce.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(255, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }
        [StringLength(500, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string? Description { get; set; }

        public IList<Game>? Games { get; set; }
    }
}
