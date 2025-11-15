using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ModifierFactories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class CharmMasterBuilderFactory : IFighterBuilderFactory
{
    public IFighterBuilder Create()
    {
        var magicShieldFactory = new MagicShieldFactory();
        var attackMasteryFactory = new AttackMasteryFactory();
        return CharmMaster.Builder.WithAttack(new Attack(5)).WithHealth(new Health(2))
            .WithModifierFrom(magicShieldFactory).WithModifierFrom(attackMasteryFactory);
    }
}