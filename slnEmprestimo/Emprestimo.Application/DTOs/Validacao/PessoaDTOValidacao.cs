using FluentValidation;

namespace Emprestimo.Application.DTOs.Validacao
{
    public  class PessoaDTOValidacao: AbstractValidator<PessoaDTO>
    {
        public PessoaDTOValidacao()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome da pessoa deve ser informado!");

            //RuleFor(x => x.Telefone)
            //    .NotEmpty()
            //    .NotNull()
            //    .WithMessage("O telefone deve ser informado!");
        }
    }
}
