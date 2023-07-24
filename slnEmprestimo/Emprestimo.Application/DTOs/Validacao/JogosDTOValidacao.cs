using FluentValidation;

namespace Emprestimo.Application.DTOs.Validacao
{
    public class JogosDTOValidacao : AbstractValidator<JogosDTO>
    {
        public JogosDTOValidacao()
        {
            RuleFor(x => x.Descricao)
               .NotEmpty()
               .NotNull()
               .WithMessage("A descrição do jogo deve ser informado!");
        }
    }
}
