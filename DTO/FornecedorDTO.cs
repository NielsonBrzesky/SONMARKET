using System.ComponentModel.DataAnnotations;

namespace SONMARKET.DTO
{
    public class FornecedorDTO
    {
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage = "Nome de Fornecedor é obrigatório!")]
        [StringLength(100, ErrorMessage = "Nome de Fornecedor muito grande, tente um nome menor!")]
        [MinLength(2, ErrorMessage = "Nome de Fornecedor muito grande, tente um nome com mais de 2 caracteres!")]
        public string Nome {get; set;}

        [Required(ErrorMessage = "E-mail do Fornecedor é obrigatório!")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email {get; set;}
        
        [Required(ErrorMessage = "Telefone do Fornecedor é obrigatório!")]
        [Phone(ErrorMessage = "Número de Telefone inválido!")]
        public string Telefone {get; set;}
    }
}