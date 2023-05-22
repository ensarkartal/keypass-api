namespace Core.Exceptions;

public class NotSupportedException : Exception
{
    public NotSupportedException(string message) : base(String.Format(message))
    {

    }
}