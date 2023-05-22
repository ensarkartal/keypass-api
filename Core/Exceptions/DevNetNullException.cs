namespace Core.Exceptions;

public class DevNetNullException : Exception
{
    public DevNetNullException(string message) : base(String.Format(message))
    {

    }
}