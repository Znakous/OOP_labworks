namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.AddMessageErrors;

public class BannedWordInMessage : IMessageAddError
{
    public string ErrorMessage { get; }

    public BannedWordInMessage(string banWord)
    {
        ErrorMessage = banWord;
    }
}