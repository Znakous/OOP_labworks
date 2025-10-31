using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IEditableFighter : IFighter
{
    void SetHealth(Health health);

    void SetAttack(Attack attack);

    IEditableFighter Clone();
}