using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IFighterOnTableBuilder
{
    IFighterOnTableBuilder WithHealth(Health health);

    IFighterOnTableBuilder WithAttack(Attack attack);

    IFighterOnTable Build();
}