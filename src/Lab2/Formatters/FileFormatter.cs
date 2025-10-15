namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class FileFormatter : IFormatter, IDisposable
{
    private readonly StreamWriter _writer;

    public FileFormatter(string filename)
    {
        _writer = new StreamWriter(filename);
    }

    public IFormatter WriteHeader(string header)
    {
        _writer.WriteLine("$#" + header + "$");
        return this;
    }

    public IFormatter WriteBody(string body)
    {
        _writer.WriteLine("$" + body + "$");
        return this;
    }

    public void Dispose()
    {
        _writer.Dispose();
    }
}