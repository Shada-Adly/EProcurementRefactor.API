namespace EProcurementRefactor.Application.Exceptions
{
    public class UnAuthenticatedException : Exception
    {
        public UnAuthenticatedException(string message) : base(message)
        {
        }
    }
}
