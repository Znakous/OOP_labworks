using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.ModifierFactories;

public class AttackMasteryFactory : IModifierFactory
{
    public IFighter Create(IFighter fighter)
    {
        return new AttackMastery(fighter);
    }
}