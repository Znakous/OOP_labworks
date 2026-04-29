using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;

public class TreeGoToCommandParsingLink : CommandParsingLinkBase<TreeGoToCommandBuilder>
{
    public TreeGoToCommandParsingLink(IParameterParsingLink<TreeGoToCommandBuilder> parameterParsers)
        : base(parameterParsers, "goto") { }
}