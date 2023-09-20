using FluentValidation;

namespace TicTacToe.Application.Commands
{
    public class AddNewGameCommandValidator : AbstractValidator<AddNewGameCommand>
    {
        public AddNewGameCommandValidator()
        {
            RuleFor(p => p.PlayerXId)
                .NotEqual(p => p.PlayerOId)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.PlayerOId)
                .NotEqual(p => p.PlayerXId)
                .NotNull()
                .NotEmpty();
        }
    }
}
