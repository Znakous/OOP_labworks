using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class CharmMasterBuilderFactory : IFighterBuilderFactory
{
    public IFighterOnTableBuilder Create()
    {
        IFighterOnTableBuilder basicCharmMaster =
            CharmMaster.DefaultBuilder;

        IFighterOnTableBuilder magicShieldApplied = MagicShield.Builder
                .WithUnderlying(basicCharmMaster);

        IFighterOnTableBuilder attackMasteryApplied = AttackMastery.Builder
                .WithUnderlying(magicShieldApplied);
        return attackMasteryApplied;
    }
}