using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class CharmMasterBuilderFactory : IFighterBuilderFactory
{
    public IEditableFighterBuilder Create()
    {
        CharmMaster basicCharmMaster =
            new CharmMaster.CharmMasterBuilderDefaultDirector()
            .Direct(new CharmMaster.CharmMasterEditableFighterBuilder())
            .Build();

        IEditableFighter magicShieldApplied =
            new MagicShield.MagicShieldUnderlyingSelector()
                .WithUnderlying(basicCharmMaster).Build();

        IEditableFighterBuilder attackMasteryAppliedBuilder =
            new AttackMastery.AttackMasteryUnderlyingSelector()
                .WithUnderlying(magicShieldApplied);
        return attackMasteryAppliedBuilder;
    }
}