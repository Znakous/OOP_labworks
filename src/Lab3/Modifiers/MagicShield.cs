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

    public void PerformAttackOn(IFighterInCombat enemy)
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

    public static MagicShieldUnderlyingSelector Builder => new MagicShieldUnderlyingSelector();

    public class MagicShieldUnderlyingSelector
    {
        public MagicShieldFighterOnTableBuilder WithUnderlying(IFighterOnTableBuilder underlying)
        {
            return new MagicShieldFighterOnTableBuilder(underlying);
        }
    }

    public class MagicShieldFighterOnTableBuilder : IFighterOnTableBuilder
    {
        private readonly IFighterOnTableBuilder _underlying;

        public MagicShieldFighterOnTableBuilder(IFighterOnTableBuilder underlying)
        {
            _underlying = underlying;
        }

        IFighterOnTableBuilder IFighterOnTableBuilder.WithAttack(Attack attack)
        {
            _underlying.WithAttack(attack);
            return this;
        }

        IFighterOnTableBuilder IFighterOnTableBuilder.WithHealth(Health health)
        {
            _underlying.WithHealth(health);
            return this;
        }

        public IFighterOnTable Build()
        {
            return new MagicShield(_underlying.Build());
        }
    }
}