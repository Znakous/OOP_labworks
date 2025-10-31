using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface IEditableFighterBuilder
{
    IEditableFighterBuilder WithHealth(Health health);

    IEditableFighterBuilder WithAttack(Attack attack);

    IEditableFighter Build();
}