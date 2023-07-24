using Emprestimo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimo.Application.Servico.Interface
{
    public  interface IJogosServico
    {
        Task<ResultServico<JogosDTO>> InserirAsync(JogosDTO jogosDTO);

        Task<ResultServico<ICollection<JogosDTO>>> ObterAsync();

        Task<ResultServico<JogosDTO>> ObterPorIdAsync(int id);

        Task<ResultServico> AlterarAsync(JogosDTO jogosDTO);

        Task<ResultServico> DeletarAsync(int id);
    }
}
