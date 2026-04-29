namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

public class DisconnectedSystemInteraction : IError
{
    public string Message { get; }

    public DisconnectedSystemInteraction(string message)
    {
        Message = message;
    }
}