using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;

public class ConnectCommandParsingLink : CommandParsingLinkBase<ConnectCommandBuilder>
{
    public ConnectCommandParsingLink(IParameterParsingLink<ConnectCommandBuilder> parameterParsers)
        : base(parameterParsers, "connect") { }
}