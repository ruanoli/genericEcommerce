using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericEcommerce.Models
{
    public class Game
    {
        public long GameId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(255, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [StringLength(500, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
        [Display(Name = "Descrição")]
        public string? ShortDescription { get; set; }

        [StringLength(700, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
        [Display(Name = "Detalhes do Game")]
        public string? LongDescription { get; set; }

        [StringLength(255, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
        [Display(Name = "URL da Imagem")]
        public string? ImageURL { get; set; }

        [StringLength(255, ErrorMessage = "Tamanho máximo de {1} caracteres.")]
        [Display(Name = "Thumbnail")]
        public string? ImageURLThumbnail { get; set; }

        [Display(Name = " Game Favorito?")]
        public bool IsFavorite { get; set; }

        [Display(Name = "Tem em Estoque?")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1, 999.99, ErrorMessage = "Valor inaceitável.")]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
