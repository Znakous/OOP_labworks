namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public struct Message
{
    public string Header { get; }

    public string Body { get; }

    public ImportanceLevel Importance { get; }

    public Message(string header, string body, ImportanceLevel importance)
    {
        Header = header;
        Body = body;
        Importance = importance;
    }
}