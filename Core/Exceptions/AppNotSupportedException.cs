namespace Core.Exceptions;

public class AppNotSupportedException : Exception
{
    public AppNotSupportedException(string message) : base(string.Format(message))
    {

    }
}