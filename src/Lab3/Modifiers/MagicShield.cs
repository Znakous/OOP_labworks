using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class MagicShield : IFighterOnTable
{
    private readonly IFighterOnTable _underlying;

    private bool _isActive;

    public bool IsAlive => _underlying.IsAlive;

    public Health Health => _underlying.Health;

    public Attack Attack => _underlying.Attack;

    public MagicShield(IFighterOnTable underlying)
    {
        _underlying = underlying;
        _isActive = true;
    }

    public void TakeDamage(Attack damage)
    {
        if (_isActive)
        {
            _isActive = false;
            return;
        }

        _underlying.TakeDamage(damage);
    }

    public void PerformAttackOn(IFighterOnTable enemy)
    {
        _underlying.PerformAttackOn(enemy);
    }

    public void SetHealth(Health health)
    {
        _underlying.SetHealth(health);
    }

    public void SetAttack(Attack attack)
    {
        _underlying.SetAttack(attack);
    }

    public IFighterOnTable Clone()
    {
        return _isActive ? new MagicShield(_underlying.Clone()) : _underlying.Clone();
    }
}