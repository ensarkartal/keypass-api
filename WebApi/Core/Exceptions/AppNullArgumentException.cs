namespace WebApi.Core.Exceptions;

public class AppNullArgumentException : Exception
{
    public AppNullArgumentException(string message) : base(string.Format(message))
    {

    }
}