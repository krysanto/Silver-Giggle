using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jinn : Character
{
    public override void Awake()
    {
        Leben = 150;
        MaxHealth = Leben;
        Schaden = 35;
        Dodge = 25;
        Cost = 5;
        SpecialDamage = Schaden;
        healthbar.SetHealth(Leben, MaxHealth);
    }

    public override void ReduceHealth(int damage)
    {
        if(Random.Range(1, 100) > Dodge)
        {
            myAnimator.Play("Jinn_Hurt");
            base.ReduceHealth(damage);
        }
    }

    public override bool Attack(Character Gegner)
    {
        int rand = Random.Range(1, 7);
        if (rand == 6)
        {
            myAnimator.Play("Jinn_Attack");
            Dodge = 100;
            return base.Attack2(Gegner);
        }
        else
        {
            myAnimator.Play("Jinn_Attack2");
            Dodge = 25;
            return base.Attack(Gegner);
        }
    }

    public override void Die()
    {
        myAnimator.Play("Jinn_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Jinn_Idle");
        base.Finished();
    }

    public override void DestroyMe()
    {
        base.DestroyMe();
    }
}
