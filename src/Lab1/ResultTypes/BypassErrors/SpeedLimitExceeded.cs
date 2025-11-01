namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.BypassErrors;

public struct SpeedLimitExceeded : IBypassError
{
    public string ErrorMessage { get; }

    public SpeedLimitExceeded(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}