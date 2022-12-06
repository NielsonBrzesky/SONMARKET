using System.ComponentModel.DataAnnotations;

namespace SONMARKET.DTO
{
    public class ProdutoDTO
    {
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage = "Nome do produto é obrigatório!")]
        [StringLength(100, ErrorMessage = "Nome do produto só pode ter até 100 caracteres!")]
        [MinLength(2, ErrorMessage = "Nome do produto muito grande, tente um nome com mais de 2 caracteres!")]
        public string Nome {get; set;}
        
        [Required(ErrorMessage = "A categoria é obrigatório!")]
        public int CategoriaID {get; set;}
        
        [Required(ErrorMessage = "Nome do fornecedor é obrigatório!")]
        public int FornecedorID {get; set;}
        
        [Required(ErrorMessage = "Preço de custo do produto é obrigatório!")]
        public float PrecoDeCusto {get; set;}

        // [Required(ErrorMessage = "Preço de custo do produto é obrigatório!")]
        // public string PrecoDeCustoString {get; set;}
        
        [Required(ErrorMessage = "Preço de venda do produto é obrigatório!")]
        public float PrecoDeVenda {get; set;}

        // [Required(ErrorMessage = "Preço de venda do produto é obrigatório!")]
        // public string PrecoDeVendaString {get; set;}
        
        [Required(ErrorMessage = "Medição do produto é obrigatório!")]
        [Range(0,2, ErrorMessage = "Medição inválida!")]
        public int Medicao {get; set;}
    }
}