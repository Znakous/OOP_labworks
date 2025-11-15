using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class CharmMasterBuilderFactory : IFighterBuilderFactory
{
    public IFighterOnTableBuilder Create()
    {
        IFighterOnTableBuilder basicCharmMaster =
            CharmMaster.Builder.WithAttack(new Attack(5)).WithHealth(new Health(2));

        IFighterOnTableBuilder magicShieldApplied = MagicShield.Builder
                .WithUnderlying(basicCharmMaster);

        IFighterOnTableBuilder attackMasteryApplied = AttackMastery.Builder
                .WithUnderlying(magicShieldApplied);
        return attackMasteryApplied;
    }
}