namespace CW._21.WebAPI.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message)
        : base(message)
    {
    }
}