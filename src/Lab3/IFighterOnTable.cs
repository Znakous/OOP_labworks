using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IFighterOnTable
{
    Health Health { get; }

    Attack Attack { get; }

    bool IsAlive { get; }

    void PerformAttackOn(IFighterOnTable enemy);

    void TakeDamage(Attack damage);

    void SetHealth(Health health);

    void SetAttack(Attack attack);

    IFighterOnTable Clone();
}