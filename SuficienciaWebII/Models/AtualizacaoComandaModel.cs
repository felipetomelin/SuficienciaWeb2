using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuficienciaWebII.Models
{
    public class AtualizacaoComandaModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Campo 'IdUsuario' deve ser maior que zero.")]
        [JsonPropertyName("idUsuario")]
        public int? IdUsuario { get; set; }

        [JsonPropertyName("nomeUsuario")]
        public string? NomeUsuario { get; set; }

        [StringLength(maximumLength: 11, MinimumLength = 10, ErrorMessage = "Campo 'TelefoneUsuario' deve conter 10 ou 11 digitos (ex: 47940028922 ou 4740028922).")]
        [JsonPropertyName("telefoneUsuario")]
        public string? TelefoneUsuario { get; set; }

        [JsonPropertyName("produtos")]
        public IList<AtualizacaoProdutoModel>? Produtos { get; set; }
    }

    public class AtualizacaoProdutoModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Campo 'Produtos.Id' deve ser maior que zero.")]
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Campo 'Produtos.Preco' deve ser maior que zero.")]
        [JsonPropertyName("preco")]
        public double? Preco { get; set; }
    }
}