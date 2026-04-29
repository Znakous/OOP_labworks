using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

public class AddressForConnectParsingLink : ParameterParsingLinkBase<ConnectCommandBuilder>
{
    public override ConnectCommandBuilder? Parse(IEnumerator<string> arguments, ConnectCommandBuilder builder)
    {
        builder = builder.WithAddress(arguments.Current);
        if (!arguments.MoveNext())
        {
            return builder;
        }

        return CallNext(arguments, builder);
    }
}