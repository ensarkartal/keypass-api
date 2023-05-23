namespace WebApi.Core.Exceptions;

public class AppNullException : Exception
{
    public AppNullException(string message) : base(String.Format(message))
    {

    }
}