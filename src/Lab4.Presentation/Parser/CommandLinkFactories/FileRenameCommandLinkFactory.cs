using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinkFactories;

public class FileRenameCommandLinkFactory : ICommandLinkFactory
{
    public ICommandParsingLink Create()
    {
        return new FileRenameCommandParsingLink(
            new AddressForRenameParsingLink()
                .AddNext(new NameForRenameParsingLink()));
    }
}