using Emprestimo.Domain.Entities;
using Emprestimo.Domain.Repositories;
using Emprestimo.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimo.Infra.Data.Repositorio
{
    public class EmprestimoRepositorio : IEmprestimosRepositorio
    {
        private readonly EmprestimoDbContext _db;
        public EmprestimoRepositorio(EmprestimoDbContext db)
        {
            _db = db;
        }
        public async Task<Emprestimos> IncluirAsync(Emprestimos emprestimo)
        {
            _db.Add(emprestimo);
            await _db.SaveChangesAsync();
            return emprestimo;
        }

        public async Task DeletarAsync(Emprestimos emprestimo)
        {
            _db.Remove(emprestimo);
            await _db.SaveChangesAsync();
        }

        public async Task EditarAsync(Emprestimos emprestimo)
        {
            _db.Update(emprestimo);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Emprestimos>> GetAllAsync()
        {
            return await _db.Emprestimos
                        .Include(x => x.Pessoa)
                        .Include(x => x.Jogos)
                        .ToListAsync();
        }

        public async Task<Emprestimos> GetByIdAsync(int id)
        {
            var emprestimo = await _db.Emprestimos
                           .Include(x => x.Pessoa)
                           .Include(x => x.Jogos)
                           .FirstOrDefaultAsync(x => x.Id == id);

            return emprestimo;
        }

        public async Task<ICollection<Emprestimos>> GetByPessoaIdAsync(int idPessoa)
        {
            return await _db.Emprestimos
                           .Include(x => x.Pessoa)
                           .Include(x => x.Jogos)
                           .Where(x => x.IdPessoa == idPessoa).ToListAsync();
        }

        public async Task<ICollection<Emprestimos>> GetByJogosIdAsync(int idJogo)
        {
            return await _db.Emprestimos
                          .Include(x => x.Pessoa)
                          .Include(x => x.Jogos)
                          .Where(x => x.IdJogo == idJogo).ToListAsync();
        }
    }
}
