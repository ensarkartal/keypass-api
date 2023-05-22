namespace Core.Exceptions;

public class DevNetAlertException : Exception
{
    public DevNetAlertException(string message) : base(string.Format(message))
    {

    }
}