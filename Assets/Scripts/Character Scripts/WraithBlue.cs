using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithBlue : Character
{
    public override void Awake()
    {
        Leben = 150;
        MaxHealth = Leben;
        Schaden = 40;
        Dodge = 30;
        Cost = 4;
        SpecialDamage = Schaden;
        healthbar.SetHealth(Leben, MaxHealth);
    }

    public override void ReduceHealth(int damage)
    {
        if (Random.Range(1, 100) > Dodge)
        {
            myAnimator.Play("WraithBlue_Hurt");
            base.ReduceHealth(damage);
        }
    }

    public override bool Attack(Character Gegner)
    {
        int rand = Random.Range(1, 7);
        if (rand == 6)
        {
            Leben += 15;
            if (Leben >= MaxHealth) Leben = MaxHealth;
            myAnimator.Play("WraithBlue_Attack2");
            return base.Attack2(Gegner);
        }
        else
        {
            myAnimator.Play("WraithBlue_Attack");
            return base.Attack(Gegner);
        }
    }

    public override void Die()
    {
        myAnimator.Play("WraithBlue_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("WraithBlue_Idle");
        base.Finished();
    }
}
