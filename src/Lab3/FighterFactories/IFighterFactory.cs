using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterFactories;

public interface IFighterFactory
{
    IBuilder Create();
}