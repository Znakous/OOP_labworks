using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class AttackMastery : IFighterOnTable
{
    private readonly IFighterOnTable _underlying;

    public bool IsAlive => _underlying.IsAlive;

    public Health Health => _underlying.Health;

    public Attack Attack => _underlying.Attack;

    public AttackMastery(IFighterOnTable underlying)
    {
        _underlying = underlying;
    }

    public void TakeDamage(Attack damage)
    {
        _underlying.TakeDamage(damage);
    }

    public void PerformAttackOn(IFighterOnTable enemy)
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

    public IFighterOnTable Clone()
    {
        return new AttackMastery(_underlying.Clone());
    }

    public static AttackMasteryUnderlyingSelector Builder => new AttackMasteryUnderlyingSelector();

    public class AttackMasteryUnderlyingSelector
    {
        public AttackMasteryUnderlyingSelector() { }

        public AttackMasteryFighterOnTableBuilder WithUnderlying(IFighterOnTableBuilder underlying)
        {
            return new AttackMasteryFighterOnTableBuilder(underlying ?? throw new ArgumentNullException(nameof(underlying)));
        }
    }

    public class AttackMasteryFighterOnTableBuilder : IFighterOnTableBuilder
    {
        private readonly IFighterOnTableBuilder _underlying;

        public AttackMasteryFighterOnTableBuilder(IFighterOnTableBuilder underlying)
        {
            _underlying = underlying ?? throw new ArgumentNullException(nameof(underlying));
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
            if (_underlying is null)
            {
                throw new NullReferenceException("The underlying builder is null.");
            }

            return new AttackMastery(_underlying.Build());
        }
    }
}