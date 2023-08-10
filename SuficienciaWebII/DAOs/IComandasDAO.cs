using SuficienciaWebII.Entities;
using SuficienciaWebII.Projecoes;

namespace SuficienciaWebII.DAOs
{
    public interface IComandasDAO
    {
        Task<IList<ListagemComandaProjecao>> ObterComandasParaListagem();
        Task<DetalhesComandaProjecao> ObterComandaParaDetalhes(int id);
        Task<Comanda> ObterComanda(int id);
        Task<int> InserirComanda(Comanda comanda);
        Task AtualizarComanda(Comanda comanda);
        Task RemoverComanda(Comanda comanda);
    }
}