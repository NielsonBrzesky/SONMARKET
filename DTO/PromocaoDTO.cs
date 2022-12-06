using System.ComponentModel.DataAnnotations;

namespace SONMARKET.DTO
{
    public class PromocaoDTO
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Nome da promoção só pode ter até 100 caracteres!")]
        [MinLength(3, ErrorMessage = "Nome da promoção muito grande, tente um nome com mais de 3 caracteres!")]
        public string Nome { get; set; }
        
        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "A porcentagem é obrigatória!")]
        [Range(0,100, ErrorMessage = "Procentagem inválida!")]
        public float Porcentagem { get; set; }
    }
}
