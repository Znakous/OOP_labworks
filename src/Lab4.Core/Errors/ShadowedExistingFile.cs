namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

public class ShadowedExistingFile : IError
{
    public string Message { get; }

    public ShadowedExistingFile(string message)
    {
        Message = message;
    }
}