using FluentValidation;

namespace Emprestimo.Application.DTOs.Validacao
{
    public class EmprestimosDTOValidacao : AbstractValidator<EmprestimosDTO>
    {
        public EmprestimosDTOValidacao()
        {
            RuleFor(x => x.Nome)
              .NotEmpty()
              .NotNull()
              .WithMessage("O nome da pssoa deve ser informado!");

            RuleFor(x => x.Descricao)
             .NotEmpty()
             .NotNull()
             .WithMessage("A nome do Jogo deve ser informado!");

        }
    }
}
