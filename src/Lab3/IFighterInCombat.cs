using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IFighterInCombat
{
    bool IsAlive { get; }

    Health Health { get; }

    Attack Attack { get; }

    void TakeDamage(Attack damage);

    void PerformAttackOn(IFighterInCombat enemy);
}