using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IFighterOnTable : IFighterInCombat
{
    void SetHealth(Health health);

    void SetAttack(Attack attack);

    IFighterOnTable Clone();
}