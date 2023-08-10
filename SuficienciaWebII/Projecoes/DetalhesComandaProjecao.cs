namespace SuficienciaWebII.Projecoes
{
    public class DetalhesComandaProjecao
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public IList<DetalhesComandaProdutoProjecao> Produtos { get; set; }
    }

    public class DetalhesComandaProdutoProjecao
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public double Preco { get; set; }
    }
}