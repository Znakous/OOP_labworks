using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class InvincibleHorror : IFighterOnTable
{
    public Health Health { get; private set; }

    public Attack Attack { get; private set; }

    public bool IsAlive => Health.IsAlive;

    private bool _canResurrect;

    public void CopyFrom(InvincibleHorror other)
    {
        Health = other.Health;
        Attack = other.Attack;
    }

    public void TakeDamage(Attack damage)
    {
        Health = Health.TakeDamage(damage);
        if (_canResurrect && !IsAlive)
        {
            _canResurrect = false;
            CopyFrom(ResurrectedVersionBuilder.Build());
        }
    }

    public void PerformAttackOn(IFighterInCombat enemy)
    {
        enemy.TakeDamage(Attack);
    }

    public void SetHealth(Health health)
    {
        Health = health;
    }

    public void SetAttack(Attack attack)
    {
        Attack = attack;
    }

    public IFighterOnTable Clone()
    {
        return new InvincibleHorror(Health, Attack, _canResurrect);
    }

    public static InvincibleHorrorBuilder Builder => new InvincibleHorrorBuilder();

    public static InvincibleHorrorBuilder DefaultBuilder
        => InvincibleHorrorBuilderDefaultDirector.Direct(new InvincibleHorrorBuilder());

    private static InvincibleHorrorBuilder ResurrectedVersionBuilder
        => InvincibleHorrorBuilderResurrectedDirector.Direct(new InvincibleHorrorBuilder());

    private InvincibleHorror(Health health, Attack attack, bool canResurrect)
    {
        Health = health;
        Attack = attack;
        _canResurrect = canResurrect;
    }

    public class InvincibleHorrorBuilder : CreatureOnTableBuilder<InvincibleHorrorBuilder, InvincibleHorror>
    {
        private bool _canResurrect = true;

        public InvincibleHorrorBuilder WithResurrectionBan()
        {
            _canResurrect = false;
            return this;
        }

        public override InvincibleHorror Build()
        {
            return new InvincibleHorror(Health, Attack, _canResurrect);
        }
    }

    private class InvincibleHorrorBuilderDefaultDirector
    {
        public static InvincibleHorrorBuilder Direct(InvincibleHorrorBuilder builder)
        {
            return builder
                .WithAttack(new Attack(4))
                .WithHealth(new Health(4));
        }
    }

    private class InvincibleHorrorBuilderResurrectedDirector
    {
        public static InvincibleHorrorBuilder Direct(InvincibleHorrorBuilder builder)
        {
            return InvincibleHorrorBuilderDefaultDirector.Direct(builder)
                .WithHealth(new Health(1));
        }
    }
}