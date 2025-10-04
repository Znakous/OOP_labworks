namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.PassErrors;

public struct ForceThresholdExceeded : IPassError
{
    public string ErrorMessage { get; }

    public ForceThresholdExceeded(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}