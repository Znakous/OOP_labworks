namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class MarkdownFormatter : IFormatter
{
    public string FormatHeader(string header)
    {
        return "#" + header;
    }

    public string FormatText(string text)
    {
        return text;
    }
}