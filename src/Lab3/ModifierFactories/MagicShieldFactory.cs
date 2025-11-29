using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.ModifierFactories;

public class MagicShieldFactory : IModifierFactory
{
    public IFighter Create(IFighter fighter)
    {
        return new MagicShield(fighter);
    }
}