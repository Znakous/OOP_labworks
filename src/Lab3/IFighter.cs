using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IFighter
{
    Health Health { get; }

    Attack Attack { get; }

    bool IsAlive { get; }

    void PerformAttackOn(IFighter enemy);

    void TakeDamage(Attack damage);

    void SetHealth(Health health);

    void SetAttack(Attack attack);

    IFighter Clone();
}