using Emprestimo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimo.Domain.Repositories
{
    public interface IPessoaRepositorio
    {
        Task<Pessoa> ObterIdAsync(int id);

        Task<ICollection<Pessoa>> ObterPessoasAsync();

        Task<Pessoa> IncluirAsync(Pessoa pessoa);

        Task EditarAsync(Pessoa pessoa);

        Task DeletarAsync(Pessoa pessoa);

        Task<int> ObterIdPessoaAsync(string nome);
    }
}
