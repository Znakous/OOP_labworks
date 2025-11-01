namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class ConsoleFormatter : IFormatter
{
    public void WriteHeader(string header)
    {
        Console.WriteLine(header);
    }

    public void WriteBody(string body)
    {
        Console.WriteLine(body);
    }
}