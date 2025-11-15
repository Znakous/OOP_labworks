using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class InvincibleHorror : BaseCreature, IFighter
{
    private readonly Attack _constructionAttack;

    private bool _canResurrect;

    private InvincibleHorror(Health health, Attack attack, bool canResurrect)
    {
        Health = health;
        Attack = attack;
        _canResurrect = canResurrect;
        _constructionAttack = attack;
    }

    public override void TakeDamage(Attack damage)
    {
        Health = Health.TakeDamage(damage);
        if (_canResurrect && !IsAlive)
        {
            _canResurrect = false;
            Health = new Health(1);
            Attack = _constructionAttack;
        }
    }

    public IFighter Clone()
    {
        return new InvincibleHorror(Health, Attack, _canResurrect);
    }

    public static InvincibleHorrorBuilder Builder => new InvincibleHorrorBuilder();

    public class InvincibleHorrorBuilder : CreatureBuilder
    {
        public override IFighter Build()
        {
            return ApplyModifiers(new InvincibleHorror(Health, Attack, true));
        }
    }
}