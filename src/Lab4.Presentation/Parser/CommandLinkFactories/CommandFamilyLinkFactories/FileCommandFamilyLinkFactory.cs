using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandFamilyLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinkFactories.CommandFamilyLinkFactories;

public class FileCommandFamilyLinkFactory : ICommandLinkFactory
{
    public ICommandParsingLink Create()
    {
        return new FileCommandParsingLink(
            new FileCopyCommandLinkFactory().Create()
                .AddNext(new FileMoveCommandLinkFactory().Create())
                    .AddNext(new FileRenameCommandLinkFactory().Create())
                        .AddNext(new FileDeleteCommandLinkFactory().Create())
                            .AddNext(new FileShowCommandLinkFactory().Create()));
    }
}