namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.MessageReadErrors;

public class MessageAlreadyRead : IMessageReadError
{
    public string ErrorMessage { get; }

    public MessageAlreadyRead(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}