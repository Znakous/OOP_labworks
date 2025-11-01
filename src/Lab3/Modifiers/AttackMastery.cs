using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class AttackMastery : IFighterOnTable
{
    private readonly IFighterOnTable _underlying;
    private bool _isActive;

    public bool IsAlive => _underlying.IsAlive;

    public Health Health => _underlying.Health;

    public Attack Attack => _underlying.Attack;

    public AttackMastery(IFighterOnTable underlying)
    {
        _underlying = underlying;
        _isActive = true;
    }

    public void TakeDamage(Attack damage)
    {
        _underlying.TakeDamage(damage);
    }

    public void PerformAttackOn(IFighterInCombat enemy)
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

    public IFighterOnTable Clone()
    {
        return _isActive ? new AttackMastery(_underlying.Clone()) : _underlying.Clone();
    }

    public static AttackMasteryUnderlyingSelector Builder => new AttackMasteryUnderlyingSelector();

    public class AttackMasteryUnderlyingSelector
    {
        public AttackMasteryUnderlyingSelector() { }

        public AttackMasteryFighterOnTableBuilder WithUnderlying(IFighterOnTable underlying)
        {
            return new AttackMasteryFighterOnTableBuilder(underlying ?? throw new ArgumentNullException(nameof(underlying)));
        }
    }

    public class AttackMasteryFighterOnTableBuilder : IFighterOnTableBuilder
    {
        private readonly IFighterOnTable _underlying;

        public AttackMasteryFighterOnTableBuilder(IFighterOnTable underlying)
        {
            _underlying = underlying ?? throw new ArgumentNullException(nameof(underlying));
        }

        IFighterOnTableBuilder IFighterOnTableBuilder.WithAttack(Attack attack)
        {
            _underlying.SetAttack(attack);
            return this;
        }

        IFighterOnTableBuilder IFighterOnTableBuilder.WithHealth(Health health)
        {
            _underlying.SetHealth(health);
            return this;
        }

        public IFighterOnTable Build()
        {
            if (_underlying is null)
            {
                throw new NullReferenceException("The underlying builder is null.");
            }

            return new AttackMastery(_underlying);
        }
    }
}