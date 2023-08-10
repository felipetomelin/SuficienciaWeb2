using System.Text.Json.Serialization;

namespace SuficienciaWebII.Views
{
    public class CadastroComandaViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        [JsonPropertyName("nomeUsuario")]
        public string NomeUsuario { get; set; }

        [JsonPropertyName("telefoneUsuario")]
        public string TelefoneUsuario { get; set; }

        [JsonPropertyName("produtos")]
        public IList<CadastroProdutoViewModel> Produtos { get; set; }
    }

    public class CadastroProdutoViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("preco")]
        public double Preco { get; set; }
    }
}