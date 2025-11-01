namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class FileFormatter : IFormatter
{
    private readonly string _filePath;

    public FileFormatter(string filePath)
    {
        _filePath = filePath;
    }

    public void WriteHeader(string header)
    {
        File.WriteAllText(_filePath, header);
    }

    public void WriteBody(string body)
    {
        File.WriteAllText(_filePath, body);
    }
}