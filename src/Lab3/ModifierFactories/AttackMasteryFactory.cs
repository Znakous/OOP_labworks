using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.ModifierFactories;

public class AttackMasteryFactory
{
    public IFighterOnTable Create(IFighterOnTable fighter)
    {
        return new AttackMastery(fighter);
    }
}