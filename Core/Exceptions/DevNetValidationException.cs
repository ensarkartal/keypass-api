namespace Core.Exceptions;

public class DevNetValidationException : Exception
{
    public DevNetValidationException(string message) : base(string.Format(message))
    {

    }
}