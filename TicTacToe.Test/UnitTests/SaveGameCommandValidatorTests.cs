using FluentValidation.TestHelper;
using TicTacToe.Application.Commands;

namespace TicTacToe.Test.UnitTests
{
    public class SaveGameCommandValidatorTests
    {
        private readonly SaveGameCommandValidator _validator;
        private readonly SaveGameCommand _command;

        public SaveGameCommandValidatorTests()
        {
            _validator = new SaveGameCommandValidator();
            _command = new SaveGameCommand()
            {
                GameId = Guid.NewGuid(),
                WinnerId = Guid.NewGuid(),
            };
        }

        [Fact]
        public void ShouldPass()
        {
            var result = _validator.TestValidate(_command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void ShouldNotAcceptEmptyGameId()
        {
            _command.GameId = Guid.Empty;
            var result = _validator.TestValidate(_command);

            result.ShouldHaveValidationErrorFor(p => p.GameId);
        }

        [Fact]
        public void ShouldAcceptEmptyWinnerId()
        {
            _command.WinnerId = Guid.Empty;
            var result = _validator.TestValidate(_command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
