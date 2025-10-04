namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.BypassErrors;

public struct InsufficientSpeed : IBypassError
{
    public string ErrorMessage { get; }

    public InsufficientSpeed(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}