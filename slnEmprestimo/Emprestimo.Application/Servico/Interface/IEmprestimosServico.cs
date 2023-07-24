using Emprestimo.Application.DTOs;

namespace Emprestimo.Application.Servico.Interface
{
    public interface IEmprestimosServico
    {
        Task<ResultServico<EmprestimosDTO>> IncluirAsync(EmprestimosDTO emprestimosDTO);

        Task<ResultServico<DetalhesEmprestimosDTO>> ObterDetaheIdAsync(int id);

        Task<ResultServico<ICollection<DetalhesEmprestimosDTO>>> ObterDetalheAsync();
    }
}
