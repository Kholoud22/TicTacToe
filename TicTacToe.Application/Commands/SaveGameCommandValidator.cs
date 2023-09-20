using FluentValidation;

namespace TicTacToe.Application.Commands
{
    public class SaveGameCommandValidator : AbstractValidator<SaveGameCommand>
    {
        public SaveGameCommandValidator()
        {
            RuleFor(p => p.GameId)
                .NotNull()
                .NotEmpty();
        }
    }
}
