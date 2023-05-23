namespace WebApi.Core.Exceptions;

public class AppInfoException : Exception
{
    public AppInfoException(string message) : base(string.Format(message))
    {

    }
}