namespace Core.Exceptions;

public class AppApplicationException : Exception
{
    public AppApplicationException(string message) : base(string.Format(message))
    {

    }
}