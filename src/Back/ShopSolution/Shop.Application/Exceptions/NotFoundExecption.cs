namespace Shop.Application.Exceptions
{
    public class NotFoundExecption : ApplicationException
    {
        public NotFoundExecption(string name, object key)
            : base($"""Entity "{name}" ({key}) was not founded """)
        {
        }
    }
}