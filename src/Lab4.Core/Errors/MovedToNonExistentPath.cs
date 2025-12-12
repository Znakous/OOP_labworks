namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

public class MovedToNonExistentPath : IError
{
    public string Message { get; }

    public MovedToNonExistentPath(string message)
    {
        Message = message;
    }
}