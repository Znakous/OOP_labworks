using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinkFactories;

public class DisconnectCommandLinkFactory : ICommandLinkFactory
{
    public ICommandParsingLink Create()
    {
        return new DisconnectCommandParsingLink();
    }
}