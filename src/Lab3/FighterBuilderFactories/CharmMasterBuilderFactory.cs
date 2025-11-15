using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class CharmMasterBuilderFactory : IFighterBuilderFactory
{
    public IFighterOnTableBuilder Create()
    {
        return CharmMaster.Builder.WithAttack(new Attack(5)).WithHealth(new Health(2));
    }
}