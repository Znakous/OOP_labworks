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

    public class MagicShieldUnderlyingSelector
    {
        public MagicShieldUnderlyingSelector() { }

        public MagicShieldEditableFighterBuilder WithUnderlying(IEditableFighter underlying)
        {
            return new MagicShieldEditableFighterBuilder(underlying);
        }
    }

    public class MagicShieldEditableFighterBuilder : IEditableFighterBuilder
    {
        private readonly IEditableFighter _underlying;

        public MagicShieldEditableFighterBuilder(IEditableFighter underlying)
        {
            _underlying = underlying;
        }

        IEditableFighterBuilder IEditableFighterBuilder.WithAttack(Attack attack)
        {
            _underlying.SetAttack(attack);
            return this;
        }

        IEditableFighterBuilder IEditableFighterBuilder.WithHealth(Health health)
        {
            _underlying.SetHealth(health);
            return this;
        }

        public IEditableFighter Build()
        {
            if (_underlying is null)
            {
                throw new NullReferenceException("The underlying builder is null.");
            }

            return new MagicShield(_underlying);
        }
    }
}