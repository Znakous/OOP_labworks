using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinkFactories;

public class FileCopyCommandLinkFactory : ICommandLinkFactory
{
    public ICommandParsingLink Create()
    {
        return new CopyCommandParsingLink(
            new SourcePathForCopyParsingLink()
                .AddNext(new DestinationPathForCopyParsingLink()));
    }
}