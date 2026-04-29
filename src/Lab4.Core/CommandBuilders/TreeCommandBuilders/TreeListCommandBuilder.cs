using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.TreeCommandBuilders;

public class TreeListCommandBuilder : ICommandBuilder
{
    private IOutput? _output;

    private int? _depth;

    public TreeListCommandBuilder WithOutput(IOutput output)
    {
        _output = output;
        return this;
    }

    public TreeListCommandBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public ICommand? Build()
    {
        if (_output is null || _depth is null)
        {
            return null;
        }

        return new TreeListCommand(_output, _depth.Value);
    }
}