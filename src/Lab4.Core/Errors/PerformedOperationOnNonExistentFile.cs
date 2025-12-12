namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

public class PerformedOperationOnNonExistentFile : IError
{
    public string Message { get; }

    public PerformedOperationOnNonExistentFile(string message)
    {
        Message = message;
    }
}