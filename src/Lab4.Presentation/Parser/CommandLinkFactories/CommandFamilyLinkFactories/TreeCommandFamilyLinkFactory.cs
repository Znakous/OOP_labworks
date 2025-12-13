using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandFamilyLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinkFactories.CommandFamilyLinkFactories;

public class TreeCommandFamilyLinkFactory : ICommandLinkFactory
{
    public ICommandParsingLink Create()
    {
        return new TreeCommandFamilyLink(new TreeListCommandLinkFactory().Create()
            .AddNext(new TreeGoToCommandLinkFactory().Create()));
    }
}