using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinkFactories;

public class FileMoveCommandLinkFactory : ICommandLinkFactory
{
    public ICommandParsingLink Create()
    {
        return new FileMoveCommandParsingLink(
            new SourcePathForMoveParsingLink()
                .AddNext(new DestinationPathForMoveParsingLink()));
    }
}