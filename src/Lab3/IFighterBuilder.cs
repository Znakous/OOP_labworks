using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IFighterBuilder
{
    IFighterBuilder WithModifierFrom(IModifierFactory modifierFactory);

    IFighterBuilder WithHealth(Health health);

    IFighterBuilder WithAttack(Attack attack);

    IFighter Build();
}