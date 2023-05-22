namespace Core.Exceptions;

public class DevNetApplicationException : Exception
{
    public DevNetApplicationException(string message) : base(string.Format(message))
    {

    }
}