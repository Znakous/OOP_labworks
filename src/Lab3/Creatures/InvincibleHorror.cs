using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class InvincibleHorror : BaseCreature, IEditableFighter
{
    private bool _canResurrect;

    public void CopyFrom(InvincibleHorror other)
    {
        base.CopyFrom(other);
    }

    public void TakeDamage(Attack damage)
    {
        Health = Health.TakeDamage(damage);
        if (_canResurrect && !IsAlive)
        {
            _canResurrect = false;
            CopyFrom(GetResurrectedVersion());
        }
    }

    public void PerformAttackOn(IFighter enemy)
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

    public IEditableFighter Clone()
    {
        return new InvincibleHorror(Health, Attack, _canResurrect);
    }

    private static InvincibleHorror GetResurrectedVersion()
    {
        return new InvincibleHorrorBuilderResurrectedDirector()
            .Direct(new InvincibleHorrorEditableFighterBuilder())
            .Build();
    }

    private InvincibleHorror(Health health, Attack attack, bool canResurrect)
        : base(health, attack)
    {
        _canResurrect = canResurrect;
    }

    public class InvincibleHorrorEditableFighterBuilder : CreatureEditableFighterBuilder<InvincibleHorrorEditableFighterBuilder, InvincibleHorror>
    {
        private bool _canResurrect = true;

        public InvincibleHorrorEditableFighterBuilder WithResurrectionBan()
        {
            _canResurrect = false;
            return this;
        }

        public override InvincibleHorror Build()
        {
            return new InvincibleHorror(Health, Attack, _canResurrect);
        }
    }

    public class InvincibleHorrorBuilderDefaultDirector
    {
        public InvincibleHorrorEditableFighterBuilder Direct(InvincibleHorrorEditableFighterBuilder editableFighterBuilder)
        {
            return editableFighterBuilder
                .WithAttack(new Attack(4))
                .WithHealth(new Health(4));
        }
    }

    public class InvincibleHorrorBuilderResurrectedDirector
    {
        public InvincibleHorrorEditableFighterBuilder Direct(InvincibleHorrorEditableFighterBuilder editableFighterBuilder)
        {
            return new InvincibleHorrorBuilderDefaultDirector()
                .Direct(editableFighterBuilder)
                .WithHealth(new Health(1));
        }
    }
}