using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{
    public override void Awake()
    {
        Leben = 90;
        MaxHealth = Leben;
        Schaden = 50;
        Dodge = 10;
        Cost = 3;
        SpecialDamage = (int)(Schaden * 1.5f);
        healthbar.SetHealth(Leben, MaxHealth);
    }

    public override void ReduceHealth(int damage)
    {
        if (Random.Range(1, 100) > Dodge)
        {
            myAnimator.Play("Mage_Hurt");
            base.ReduceHealth(damage);
        }
    }

    public override bool Attack(Character Gegner)
    {
        int rand = Random.Range(1, 7);
        if (rand == 6)
        {
            myAnimator.Play("Mage_Attack2");
            return base.Attack2(Gegner);
        }
        else
        {
            myAnimator.Play("Mage_Attack");
            return base.Attack(Gegner);
        }
    }

    public override void Die()
    {
        myAnimator.Play("Mage_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Mage_Idle");
        base.Finished();
    }

    public override void DestroyMe()
    {
        base.DestroyMe();
    }
}
