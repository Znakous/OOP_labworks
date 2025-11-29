using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class CombatAnalystBuilderFactory : IFighterBuilderFactory
{
    public IFighterBuilder Create()
    {
        return CombatAnalyst.Builder.WithAttack(new Attack(2)).WithHealth(new Health(4));
    }
}