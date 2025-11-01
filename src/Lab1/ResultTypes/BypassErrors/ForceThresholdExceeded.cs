namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.BypassErrors;

public struct ForceThresholdExceeded : IBypassError
{
    public string ErrorMessage { get; }

    public ForceThresholdExceeded(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}