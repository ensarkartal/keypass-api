namespace Core.Exceptions;

public class DevNetInfoException : Exception
{
    public DevNetInfoException(string message) : base(string.Format(message))
    {

    }
}