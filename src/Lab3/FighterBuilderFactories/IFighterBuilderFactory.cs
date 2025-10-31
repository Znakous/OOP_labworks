using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public interface IFighterBuilderFactory
{
    IEditableFighterBuilder Create();
}