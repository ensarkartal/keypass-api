namespace Core.Exceptions;

public class DevNetNullArgumentException : Exception
{
    public DevNetNullArgumentException(string message) : base(string.Format(message))
    {

    }
}