namespace WebApi.Core.Exceptions;

public class AppValidationException : Exception
{
    public AppValidationException(string message) : base(string.Format(message))
    {

    }
}