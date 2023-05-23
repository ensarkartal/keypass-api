namespace Core.Exceptions;

public class AppUnauthorizedException : Exception
{
    public AppUnauthorizedException(string message) : base(string.Format(message))
    {

    }
}