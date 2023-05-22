namespace Core.Exceptions;

public class DevNetNotSupportedException : Exception
{
    public DevNetNotSupportedException(string message) : base(string.Format(message))
    {

    }
}