using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterFactories;

public class CharmMasterFactory : IFighterFactory
{
    public IBuilder Create()
    {
        CharmMaster.CharmMasterBuilder basicCharmMasterBuilder =
            new CharmMaster.CharmMasterBuilderDefaultDirector()
            .Direct(new CharmMaster.CharmMasterBuilder());
        MagicShield.MagicShieldBuilder magicShieldBuilder =
            new MagicShield.MagicShieldBuilder().WithUnderlying(basicCharmMasterBuilder);
        AttackMastery.AttackMasteryBuilder attackMasteryBuilder =
            new AttackMastery.AttackMasteryBuilder().WithUnderlying(magicShieldBuilder);
        return attackMasteryBuilder;
    }
}