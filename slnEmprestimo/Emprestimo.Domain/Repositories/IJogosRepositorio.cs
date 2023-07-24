using Emprestimo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimo.Domain.Repositories
{
    public  interface IJogosRepositorio
    {
        Task<Jogos> ObterIdAsync(int id);

        Task<ICollection<Jogos>> ObterJogosAsync();

        Task<Jogos> IncluirAsync(Jogos jogos);

        Task EditarAsync(Jogos jogos);

        Task DeletarAsync(Jogos Jogos);
        Task<int> ObterIdJogoAsync(string descricao);
    }
}
