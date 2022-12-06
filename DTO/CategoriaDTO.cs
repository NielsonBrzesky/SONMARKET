using System.ComponentModel.DataAnnotations;

namespace SONMARKET.DTO
{
    public class CategoriaDTO
    {
        [Required]
        public int Id {get; set;}
        [Required(ErrorMessage = "Nome de Categoria é obrigatório!")]
        [StringLength(100, ErrorMessage = "Nome de Categoria muito grande, tente um nome menor!")]
        [MinLength(2, ErrorMessage = "Nome de Categoria muito grande, tente um nome com mais de 2 caracteres!")]
        public string Nome {get; set;}
    }
}