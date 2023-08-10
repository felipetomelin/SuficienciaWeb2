using SuficienciaWebII.Models;
using SuficienciaWebII.Views;

namespace SuficienciaWebII.Services
{
    public interface IComandasServices
    {
        Task<IList<ListagemComandaViewModel>> ListarComandas();
        Task<DetalhesComandaViewModel> DetalharComanda(int idComanda);
        Task<CadastroComandaViewModel> CadastrarComanda(CadastroComandaModel model);
        Task AtualizarComanda(int id, AtualizacaoComandaModel model);
        Task<RemocaoComandaViewModel> RemoverComanda(int idComanda);
    }
}