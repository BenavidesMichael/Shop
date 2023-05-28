namespace Shop.Application.Exceptions
{
    public class NotFoundExecption : ApplicationException
    {
        public NotFoundExecption(string name, object key)
            : base($"""Entity "{name}" ({key}) was not founded """)
        { }

        public NotFoundExecption() : base() { }

        public NotFoundExecption(string? message) : base(message) { }

        public NotFoundExecption(string? message, Exception? innerException) : base(message, innerException) { }
    }
}