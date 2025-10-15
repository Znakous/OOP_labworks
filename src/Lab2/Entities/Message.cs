using Itmo.ObjectOrientedProgramming.Lab2.ImportanceLevels;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public struct Message
{
    public string Header { get; }

    public string Body { get; }

    public ImportanceLevel ImportanceLevel { get; }

    public Message(string header, string body, ImportanceLevel importanceLevel)
    {
        Header = header;
        Body = body;
        ImportanceLevel = importanceLevel;
    }

    public bool Contains(string banWord)
    {
        return Body.Contains(banWord, StringComparison.OrdinalIgnoreCase)
            || Header.Contains(banWord, StringComparison.OrdinalIgnoreCase);
    }
}