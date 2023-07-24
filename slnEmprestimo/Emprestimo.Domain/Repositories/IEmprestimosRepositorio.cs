using Emprestimo.Domain.Entities;

namespace Emprestimo.Domain.Repositories
{
    public interface IEmprestimosRepositorio
    {

        Task<Emprestimos> IncluirAsync(Emprestimos emprestimo);

        Task DeletarAsync(Emprestimos emprestimo);

        Task EditarAsync(Emprestimos emprestimo);

        Task<Emprestimos> GetByIdAsync(int id);

        Task<ICollection<Emprestimos>> GetByPessoaIdAsync(int emprestimo);

        Task<ICollection<Emprestimos>> GetByJogosIdAsync(int emprestimo);

        Task<ICollection<Emprestimos>> GetAllAsync();
       

    }
}
