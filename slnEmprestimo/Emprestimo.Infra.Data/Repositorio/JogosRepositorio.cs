using Emprestimo.Domain.Entities;
using Emprestimo.Domain.Repositories;
using Emprestimo.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Emprestimo.Infra.Data.Repositorio
{
    public class JogosRepositorio : IJogosRepositorio
    {
        private readonly EmprestimoDbContext _db;

        public JogosRepositorio(EmprestimoDbContext db)
        {
            _db = db;
        }

        public async Task DeletarAsync(Jogos jogo)
        {
            _db.Remove(jogo);
            await _db.SaveChangesAsync();
        }

        public async Task EditarAsync(Jogos jogo)
        {
            _db.Update(jogo);
            await _db.SaveChangesAsync();
        }

        public async Task<Jogos> IncluirAsync(Jogos jogo)
        {
            _db.Add(jogo);
            await _db.SaveChangesAsync();
            return jogo;
        }

        public async Task<Jogos> ObterIdAsync(int id)
        {
            return await _db.jogos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> ObterIdJogoAsync(string descricao)
        {
            return (await _db.jogos.FirstOrDefaultAsync(x => x.Descricao == descricao))?.Id ?? 0;
        }

        public async Task<ICollection<Jogos>> ObterJogosAsync()
        {
            return await _db.jogos.ToListAsync();
        }
    }
}
