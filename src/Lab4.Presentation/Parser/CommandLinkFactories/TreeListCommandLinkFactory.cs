using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinkFactories;

public class TreeListCommandLinkFactory : ICommandLinkFactory
{
    public ICommandParsingLink Create()
    {
        FlagParsingLink<TreeListCommandBuilder> flags = FlagParsingLink<TreeListCommandBuilder>.Builder.WithFlag(new DepthForTreeListFlagParser()).Build();
        return new TreeListCommandParsingLink(flags);
    }
}