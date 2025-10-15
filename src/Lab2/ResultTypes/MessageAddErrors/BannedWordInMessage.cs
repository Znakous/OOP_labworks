namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.MessageAddErrors;

public class BannedWordInMessage : IMessageAddError
{
    public string ErrorMessage { get; }

    public BannedWordInMessage(string banWord)
    {
        ErrorMessage = banWord;
    }
}