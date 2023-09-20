using FluentValidation;

namespace TicTacToe.Application.Commands
{
    public class AddPlayersCommandValidator : AbstractValidator<AddPlayersCommand>
    {
        public AddPlayersCommandValidator()
        {
            RuleFor(p => p.PlayerXUsername)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.PlayerOUsername)
                .NotNull()
                .NotEmpty();
        }
    }
}
