using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;

public class TreeListCommandParsingLink : CommandParsingLinkBase<TreeListCommandBuilder>
{
    public TreeListCommandParsingLink(IParameterParsingLink<TreeListCommandBuilder> parameterParsers)
        : base(parameterParsers, "list") { }
}