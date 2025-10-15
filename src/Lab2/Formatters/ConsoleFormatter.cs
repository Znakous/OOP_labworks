namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class ConsoleFormatter : IFormatter
{
    public IFormatter WriteHeader(string header)
    {
        Console.WriteLine("$#" + header + "$");
        return this;
    }

    public IFormatter WriteBody(string body)
    {
        Console.WriteLine("$" + body + "$");
        return this;
    }
}