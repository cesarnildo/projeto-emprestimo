using Emprestimo.Domain.Entities;
using Emprestimo.Domain.Repositories;
using Emprestimo.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Emprestimo.Infra.Data.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly EmprestimoDbContext _db;
        public PessoaRepositorio(EmprestimoDbContext db)
        {
            _db = db;
        }
        public async Task DeletarAsync(Pessoa pessoa)
        {
            _db.Remove(pessoa);
            await _db.SaveChangesAsync();

        }

        public async Task EditarAsync(Pessoa pessoa)
        {
            _db.Update(pessoa);
            await _db.SaveChangesAsync();
        }

        public async Task<Pessoa> IncluirAsync(Pessoa pessoa)
        {
            _db.Add(pessoa);
            await _db.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa> ObterIdAsync(int id)
        {
            return  await _db.Pessoa.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> ObterIdPessoaAsync(string nome)
        {
            return (await _db.Pessoa.FirstOrDefaultAsync(x => x.Nome == nome))?.Id ?? 0;
        }

        public async Task<ICollection<Pessoa>> ObterPessoasAsync()
        {
            return await _db.Pessoa.ToListAsync();
        }
    }
}
