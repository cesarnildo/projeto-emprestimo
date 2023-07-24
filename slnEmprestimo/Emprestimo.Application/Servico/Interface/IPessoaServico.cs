using Emprestimo.Application.DTOs;

namespace Emprestimo.Application.Servico.Interface
{
    public interface IPessoaServico
    {
        Task<ResultServico<PessoaDTO>> IncluirAsync(PessoaDTO pessoaDTO);

        Task<ResultServico<ICollection<PessoaDTO>>> ObterAsync();

        Task<ResultServico<PessoaDTO>> ObterPorIdAsync(int id);

        Task<ResultServico> AlterarAsync(PessoaDTO pessoaDTO);

        Task<ResultServico> DeletarAsync(int id);

    }
}
