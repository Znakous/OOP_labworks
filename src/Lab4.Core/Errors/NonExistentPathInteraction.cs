namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

public class NonExistentPathInteraction : IError
{
    public string Message { get; }

    public NonExistentPathInteraction(string message)
    {
        Message = message;
    }
}