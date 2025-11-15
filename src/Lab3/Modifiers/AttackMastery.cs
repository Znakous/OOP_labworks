using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class AttackMastery : IFighter
{
    private readonly IFighter _underlying;

    public bool IsAlive => _underlying.IsAlive;

    public Health Health => _underlying.Health;

    public Attack Attack => _underlying.Attack;

    public AttackMastery(IFighter underlying)
    {
        _underlying = underlying;
    }

    public void TakeDamage(Attack damage)
    {
        _underlying.TakeDamage(damage);
    }

    public void PerformAttackOn(IFighter enemy)
    {
        _underlying.PerformAttackOn(enemy);
        if (enemy.IsAlive)
        {
            _underlying.PerformAttackOn(enemy);
        }
    }

    public void SetHealth(Health health)
    {
        _underlying.SetHealth(health);
    }

    public void SetAttack(Attack attack)
    {
        _underlying.SetAttack(attack);
    }

    public IFighter Clone()
    {
        return new AttackMastery(_underlying.Clone());
    }
}