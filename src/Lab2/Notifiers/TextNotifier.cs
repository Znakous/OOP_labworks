namespace Itmo.ObjectOrientedProgramming.Lab2.Notifiers;

public class TextNotifier : INotifier
{
    private readonly string _text;

    public TextNotifier(string text)
    {
        _text = text;
    }

    public void Notify()
    {
        Console.WriteLine(_text);
    }
}