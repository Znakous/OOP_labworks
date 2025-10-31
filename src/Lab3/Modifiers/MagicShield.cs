using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class MagicShield : IEditableFighter
{
    private readonly IEditableFighter _underlying;

    private bool _isActive;

    public bool IsAlive => _underlying.IsAlive;

    public Health Health => _underlying.Health;

    public Attack Attack => _underlying.Attack;

    public MagicShield(IEditableFighter underlying)
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

    public void PerformAttackOn(IFighter enemy)
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

    public IEditableFighter Clone()
    {
        return _isActive ? new MagicShield(_underlying.Clone()) : _underlying.Clone();
    }

    public class MagicShieldBuilder : IBuilder
    {
        private IBuilder? _underlying;

        public MagicShieldBuilder() { }

        public MagicShieldBuilder WithUnderlying(IBuilder underlying)
        {
            _underlying = underlying;
            return this;
        }

        public IEditableFighter Build()
        {
            if (_underlying is null)
            {
                throw new NullReferenceException("The underlying builder is null.");
            }

            return new MagicShield(_underlying.Build());
        }
    }
}