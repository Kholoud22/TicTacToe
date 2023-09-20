using FluentValidation.TestHelper;
using TicTacToe.Application.Commands;

namespace TicTacToe.Test.UnitTests
{
    public class AddPlayersCommandValidatorTests
    {
        private readonly AddPlayersCommandValidator _validator;
        private readonly AddPlayersCommand _command;

        public AddPlayersCommandValidatorTests()
        {
            _validator = new AddPlayersCommandValidator();
            _command = new AddPlayersCommand()
            {
                PlayerOUsername = "playerO",
                PlayerXUsername = "playerX"
            };
        }

        [Fact]
        public void ShouldPass()
        {
            var result = _validator.TestValidate(_command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void ShouldNotAcceptEmptyPlayerOUsrname()
        {
            _command.PlayerOUsername = "";
            var result = _validator.TestValidate(_command);

            result.ShouldHaveValidationErrorFor(p => p.PlayerOUsername);
        }

        [Fact]
        public void ShouldNotAcceptEmptyPlayerXUsrname()
        {
            _command.PlayerXUsername = "";
            var result = _validator.TestValidate(_command);

            result.ShouldHaveValidationErrorFor(p => p.PlayerXUsername);
        }
    }
}
