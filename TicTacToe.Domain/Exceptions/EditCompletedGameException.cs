namespace TicTacToe.Domain.Exceptions
{
    public class EditCompletedGameException : Exception
    {
        public EditCompletedGameException(Guid id) : base($"Completed game with Id: {id} Can't be edited")
        {
        }

        public EditCompletedGameException(string message) : base(message)
        {
        }

        public EditCompletedGameException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}