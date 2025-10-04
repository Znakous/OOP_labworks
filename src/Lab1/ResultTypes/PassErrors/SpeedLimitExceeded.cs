namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.PassErrors;

public struct SpeedLimitExceeded : IPassError
{
    public string ErrorMessage { get; }

    public SpeedLimitExceeded(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}