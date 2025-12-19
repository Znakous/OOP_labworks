namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

public class DirectoryShowCall : IError
{
    public string Message { get; }

    public DirectoryShowCall(string message)
    {
        Message = message;
    }
}