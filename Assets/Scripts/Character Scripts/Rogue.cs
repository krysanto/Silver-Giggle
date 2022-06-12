using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : Character
{
    public override void Awake()
    {
        Leben = 70;
        MaxHealth = Leben;
        Schaden = 25;
        Dodge = 40;
        Cost = 3;
        SpecialDamage = Schaden * 3;
        healthbar.SetHealth(Leben, MaxHealth);
    }

    public override void ReduceHealth(int damage)
    {
        if (Random.Range(1, 100) > Dodge)
        {
            myAnimator.Play("Rogue_Hurt");
            base.ReduceHealth(damage);
        }
    }

    public override bool Attack(Character Gegner)
    {
        int rand = Random.Range(1, 7);
        if (rand == 6)
        {
            myAnimator.Play("Rogue_Attack2");
            return base.Attack2(Gegner);
        }
        else
        {
            myAnimator.Play("Rogue_Attack");
            return base.Attack(Gegner);
        }
    }

    public override void Die()
    {
        myAnimator.Play("Rogue_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Rogue_Idle");
        base.Finished();
    }

    public override void DestroyMe()
    {
        base.DestroyMe();
    }
}
