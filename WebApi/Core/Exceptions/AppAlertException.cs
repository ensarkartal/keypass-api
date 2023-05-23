namespace WebApi.Core.Exceptions;

public class AppAlertException : Exception
{
    public AppAlertException(string message) : base(string.Format(message))
    {

    }
}