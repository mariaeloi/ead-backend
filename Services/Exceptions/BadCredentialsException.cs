namespace Services.Exceptions;

public class BadCredentialsException : Exception
{
    public BadCredentialsException()
    {
    }

    public BadCredentialsException(string message)
        : base(message)
    {
    }

    public BadCredentialsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
