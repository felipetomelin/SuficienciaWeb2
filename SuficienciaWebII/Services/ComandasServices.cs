using SuficienciaWebII.DAOs;
using SuficienciaWebII.Entities;
using SuficienciaWebII.Exceptions;
using SuficienciaWebII.Models;
using SuficienciaWebII.Views;

namespace SuficienciaWebII.Services
{
    public class ComandasServices : IComandasServices
    {
        private readonly IComandasDAO _comandasDao;
        private readonly IValidacoesService _validacoesService;

        public ComandasServices(IComandasDAO comandasDao, IValidacoesService validacoesService)
        {
            _comandasDao = comandasDao;
            _validacoesService = validacoesService;
        }

        public async Task<IList<ListagemComandaViewModel>> ListarComandas()
        {
            var comandas = await _comandasDao.ObterComandasParaListagem();

            return comandas
                .Select(x => new ListagemComandaViewModel
                {
                    IdUsuario = x.IdUsuario,
                    NomeUsuario = x.NomeUsuario,
                    TelefoneUsuario = x.TelefoneUsuario,
                })
                .ToArray();
        }

        public async Task<DetalhesComandaViewModel> DetalharComanda(int idComanda)
        {
            var comanda = await _comandasDao.ObterComandaParaDetalhes(idComanda);

            if (comanda == null)
                throw new EntidadeNaoEncontradaException($"Comanda de id:{idComanda} não encontrada");
            
            return new DetalhesComandaViewModel
            {
                IdUsuario = comanda.IdUsuario,
                NomeUsuario = comanda.NomeUsuario,
                TelefoneUsuario = comanda.TelefoneUsuario,
                Produtos = comanda.Produtos
                    .Select(x => new DetalhesProdutoViewModel
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Preco = x.Preco,
                    })
                    .ToArray(),
            };
        }

        public async Task<CadastroComandaViewModel> CadastrarComanda(CadastroComandaModel model)
        {
            var comanda = new Comanda
            {
                IdUsuario = model.IdUsuario,
                NomeUsuario = model.NomeUsuario,
                TelefoneUsuario = model.TelefoneUsuario,
                Produtos = model.Produtos
                    .Select(x => new Produto
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Preco = x.Preco,
                    })
                    .ToArray(),
            };

            var idComanda = await _comandasDao.InserirComanda(comanda);

            return new CadastroComandaViewModel
            {
                Id = idComanda,
                IdUsuario = comanda.IdUsuario,
                NomeUsuario = comanda.NomeUsuario,
                TelefoneUsuario = comanda.TelefoneUsuario,
                Produtos = comanda.Produtos
                    .Select(x => new CadastroProdutoViewModel
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Preco = x.Preco,
                    })
                    .ToList(),
            };
        }

        public async Task AtualizarComanda(int idComanda, AtualizacaoComandaModel model)
        {
            var comanda = await _comandasDao.ObterComanda(idComanda);

            if (comanda == null)
                throw new EntidadeNaoEncontradaException($"Comanda de id:{idComanda} não encontrada");
            
            comanda.IdUsuario = model.IdUsuario ?? comanda.IdUsuario;
            comanda.NomeUsuario = model.NomeUsuario ?? comanda.NomeUsuario;
            comanda.TelefoneUsuario = model.TelefoneUsuario ?? comanda.TelefoneUsuario;

            foreach (var modelProduto in model.Produtos ?? new List<AtualizacaoProdutoModel>())
            {
                var comandaProduto = comanda.Produtos.FirstOrDefault(x => x.Id == modelProduto.Id);

                if (comandaProduto == null)
                {
                    comandaProduto = new Produto
                    {
                        Id = (int)modelProduto.Id!,
                        Nome = modelProduto.Nome,
                        Preco = (double) modelProduto.Preco!,
                    };
                    comanda.Produtos.Add(comandaProduto);
                }
                else
                {
                    comandaProduto.Id = modelProduto.Id ?? comandaProduto.Id;
                    comandaProduto.Nome = modelProduto.Nome ?? comandaProduto.Nome;
                    comandaProduto.Preco = modelProduto.Preco ?? comandaProduto.Preco;
                }
            }

            await _comandasDao.AtualizarComanda(comanda);
        }

        public async Task<RemocaoComandaViewModel> RemoverComanda(int idComanda)
        {
            var comanda = await _comandasDao.ObterComanda(idComanda);

            if (comanda == null)
                throw new EntidadeNaoEncontradaException($"Comanda de id:{idComanda} não encontrada");
            
            await _comandasDao.RemoverComanda(comanda);

            return new RemocaoComandaViewModel
            {
                Success = new SuccessViewModel
                {
                    Text = "comanda removida",
                },
            };
        }
    }
}