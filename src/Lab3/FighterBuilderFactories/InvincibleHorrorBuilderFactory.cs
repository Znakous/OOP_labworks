using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class InvincibleHorrorBuilderFactory : IFighterBuilderFactory
{
    public IFighterOnTableBuilder Create()
    {
        return InvincibleHorror.Builder.WithAttack(new Attack(4)).WithHealth(new Health(4));
    }
}