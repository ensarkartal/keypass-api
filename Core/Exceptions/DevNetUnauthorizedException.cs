namespace Core.Exceptions;

public class DevNetUnauthorizedException : Exception
{
    public DevNetUnauthorizedException(string message) : base(string.Format(message))
    {

    }
}