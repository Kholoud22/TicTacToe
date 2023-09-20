namespace TicTacToe.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(Guid id) : base($"Id: {id} not found")
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}