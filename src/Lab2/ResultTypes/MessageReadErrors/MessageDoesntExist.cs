namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.MessageReadErrors;

public class MessageDoesntExist : IMessageReadError
{
    public string ErrorMessage { get; }

    public MessageDoesntExist(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}