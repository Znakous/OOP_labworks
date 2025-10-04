namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.PassErrors;

public struct InsufficientSpeed : IPassError
{
    public string ErrorMessage { get; }

    public InsufficientSpeed(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}