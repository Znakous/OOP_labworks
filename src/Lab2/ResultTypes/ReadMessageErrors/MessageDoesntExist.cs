namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.ReadMessageErrors;

public class MessageDoesntExist : IReadMessageError
{
    public string ErrorMessage { get; }

    public MessageDoesntExist(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}