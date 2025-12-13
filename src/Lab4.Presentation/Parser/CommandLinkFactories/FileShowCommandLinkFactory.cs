using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinkFactories;

public class FileShowCommandLinkFactory : ICommandLinkFactory
{
    public ICommandParsingLink Create()
    {
        FlagParsingLink<FileShowCommandBuilder> flags = FlagParsingLink<FileShowCommandBuilder>.Builder
            .WithFlag(new ModeForFileShowFlagParser()).Build();
        return new FileShowCommandParsingLink(
            new PathForFileShowCommandParsingLink()
                .AddNext(flags));
    }
}