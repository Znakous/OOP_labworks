using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.ModifierFactories;

public class MagicShieldFactory : IModifierFactory
{
    public IFighterOnTable Create(IFighterOnTable fighter)
    {
        return new MagicShield(fighter);
    }
}