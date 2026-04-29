using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders;

public interface ICommandBuilder
{
    ICommand? Build();
}