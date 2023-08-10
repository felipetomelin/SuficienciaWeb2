using Microsoft.EntityFrameworkCore;
using SuficienciaWebII.Database;
using SuficienciaWebII.Entities;
using SuficienciaWebII.Projecoes;

namespace SuficienciaWebII.DAOs
{
    public class ComandasDAO : IComandasDAO
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Comanda> _entity;

        public ComandasDAO(DatabaseContext context)
        {
            _context = context;
            _entity = _context.Set<Comanda>();
        }

        public async Task<IList<ListagemComandaProjecao>> ObterComandasParaListagem()
        {
            return await _entity
                .Select(x => new ListagemComandaProjecao
                {
                    IdUsuario = x.IdUsuario,
                    NomeUsuario = x.NomeUsuario,
                    TelefoneUsuario = x.TelefoneUsuario,
                })
                .ToListAsync();
        }

        public Task<DetalhesComandaProjecao> ObterComandaParaDetalhes(int id)
        {
            return _entity
                .Include(x => x.Produtos)
                .Where(x => x.Id == id)
                .Select(x => new DetalhesComandaProjecao
                {
                    IdUsuario = x.IdUsuario,
                    NomeUsuario = x.NomeUsuario,
                    TelefoneUsuario = x.TelefoneUsuario,
                    Produtos = x.Produtos
                        .Select(y => new DetalhesComandaProdutoProjecao
                        {
                            Id = y.Id,
                            Nome = y.Nome,
                            Preco = y.Preco,
                        }).ToList(),
                })
                .FirstOrDefaultAsync();
        }

        public Task<Comanda> ObterComanda(int id)
        {
            return _entity
                .Include(x => x.Produtos)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> InserirComanda(Comanda comanda)
        {
            var comandaInserida = _entity.Add(comanda).Entity;
            await _context.SaveChangesAsync();
            return comandaInserida.Id;
        }

        public async Task AtualizarComanda(Comanda comanda)
        {
            _entity.Update(comanda);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverComanda(Comanda comanda)
        {
            _entity.Remove(comanda);
            await _context.SaveChangesAsync();
        }
    }
}