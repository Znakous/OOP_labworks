using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class AttackMastery : IEditableFighter
{
    private readonly IEditableFighter _underlying;
    private bool _isActive;

    public bool IsAlive => _underlying.IsAlive;

    public Health Health => _underlying.Health;

    public Attack Attack => _underlying.Attack;

    public AttackMastery(IEditableFighter underlying)
    {
        _underlying = underlying;
        _isActive = true;
    }

    public void TakeDamage(Attack damage)
    {
        _underlying.TakeDamage(damage);
    }

    public void PerformAttackOn(IFighter enemy)
    {
        _underlying.PerformAttackOn(enemy);
        if (_isActive && enemy.IsAlive)
        {
            _isActive = false;
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

    public IEditableFighter Clone()
    {
        return _isActive ? new AttackMastery(_underlying.Clone()) : _underlying.Clone();
    }

    public class AttackMasteryUnderlyingSelector
    {
        public AttackMasteryUnderlyingSelector() { }

        public AttackMasteryEditableFighterBuilder WithUnderlying(IEditableFighter underlying)
        {
            return new AttackMasteryEditableFighterBuilder(underlying ?? throw new ArgumentNullException(nameof(underlying)));
        }
    }

    public class AttackMasteryEditableFighterBuilder : IEditableFighterBuilder
    {
        private readonly IEditableFighter _underlying;

        public AttackMasteryEditableFighterBuilder(IEditableFighter underlying)
        {
            _underlying = underlying ?? throw new ArgumentNullException(nameof(underlying));
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

            return new AttackMastery(_underlying);
        }
    }
}