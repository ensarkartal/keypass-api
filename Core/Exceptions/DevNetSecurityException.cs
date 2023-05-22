namespace Core.Exceptions;

public class DevNetSecurityException : Exception
{
    public DevNetSecurityException(string message) : base(string.Format(message))
    {

    }
}