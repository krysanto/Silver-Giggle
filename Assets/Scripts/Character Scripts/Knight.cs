using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Character
{
    public override void Awake()
    {
        Leben = 120;
        MaxHealth = Leben;
        Schaden = 25;
        Dodge = 25;
        Cost = 3;
        SpecialDamage = 100;
        healthbar.SetHealth(Leben, MaxHealth);
    }

    public override void ReduceHealth(int damage)
    {
        if (Random.Range(1, 100) > Dodge)
        {
            myAnimator.Play("Knight_Hurt");
            base.ReduceHealth(damage);
        }
    }

    public override bool Attack(Character Gegner)
    {
        int rand = Random.Range(1, 7);
        if (rand == 6)
        {
            myAnimator.Play("Knight_Attack2");
            if(Random.Range(1, 3) == 2)
            {
                return base.Attack2(Gegner);
            } else
            {
                return false;
            }
        }
        else
        {
            myAnimator.Play("Knight_Attack");
            return base.Attack(Gegner);
        }
    }

    public override void Die()
    {
        myAnimator.Play("Knight_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Knight_Idle");
        base.Finished();
    }
}
