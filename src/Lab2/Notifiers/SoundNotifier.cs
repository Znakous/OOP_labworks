namespace Itmo.ObjectOrientedProgramming.Lab2.Notifiers;

public class SoundNotifier : INotifier
{
    public void Notify()
    {
        Console.Beep();
    }
}