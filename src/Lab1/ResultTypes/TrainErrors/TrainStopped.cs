namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.TrainErrors;

public struct TrainStopped : ITrainError
{
    public string ErrorMessage { get; }

    public TrainStopped(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}