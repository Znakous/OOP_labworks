using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinkFactories;

public class ConnectCommandLinkFactory : ICommandLinkFactory
{
    public ICommandParsingLink Create()
    {
        FlagParsingLink<ConnectCommandBuilder> flagsLink = FlagParsingLink<ConnectCommandBuilder>.Builder
            .WithFlagParser(new ModeForConnectParser())
            .Build();
        return new ConnectCommandParsingLink(
            new AddressForConnectParsingLink()
                .AddNext(flagsLink));
    }
}