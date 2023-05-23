namespace WebApi.Core.Exceptions;

public class AppSecurityException : Exception
{
    public AppSecurityException(string message) : base(string.Format(message))
    {

    }
}