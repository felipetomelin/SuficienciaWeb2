using System.Text.Json.Serialization;

namespace SuficienciaWebII.Views
{
    public class ListagemComandaViewModel
    {
        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        [JsonPropertyName("nomeUsuario")]
        public string NomeUsuario { get; set; }

        [JsonPropertyName("telefoneUsuario")]
        public string TelefoneUsuario { get; set; }
    }
}