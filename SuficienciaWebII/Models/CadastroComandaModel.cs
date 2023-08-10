using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuficienciaWebII.Models
{
    public class CadastroComandaModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Campo 'IdUsuario' deve ser maior que zero.")]
        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo 'NomeUsuario' deve ser preenchido.")]
        [JsonPropertyName("nomeUsuario")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Campo 'TelefoneUsuario' deve ser preenchido.")]
        [StringLength(maximumLength: 11, MinimumLength = 10, ErrorMessage = "Campo 'TelefoneUsuario' deve conter 10 ou 11 digitos (ex: 47940028922 ou 4740028922).")]
        [JsonPropertyName("telefoneUsuario")]
        public string TelefoneUsuario { get; set; }

        [Required(ErrorMessage = "Campo 'Produtos' deve ser preenchido.")]
        [JsonPropertyName("produtos")]
        public IList<CadastroProdutoModel> Produtos { get; set; }
    }

    public class CadastroProdutoModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Campo 'Produtos.Id' deve ser maior que zero.")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo 'Produtos.Nome' deve ser preenchido.")]
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [Required]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Campo 'Produtos.Preco' deve ser maior que zero.")]
        [JsonPropertyName("preco")]
        public double Preco { get; set; }
    }
}