using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : Character
{
    public override void Awake()
    {
        Leben = 100;
        MaxHealth = Leben;
        Schaden = 20;
        Dodge = 25;
        Cost = 2;
        SpecialDamage = Schaden;
        healthbar.SetHealth(Leben, MaxHealth);
    }

    public override void ReduceHealth(int damage)
    {
        if (Random.Range(1, 100) > Dodge)
        {
            myAnimator.Play("Wraith_Hurt");
            base.ReduceHealth(damage);
        }
    }

    public override bool Attack(Character Gegner)
    {
        int rand = Random.Range(1, 7);
        if (rand == 6)
        {
            Leben += 5;
            if (Leben >= MaxHealth) Leben = MaxHealth;
            myAnimator.Play("Wraith_Attack2");
            return base.Attack2(Gegner);
        }
        else
        {
            myAnimator.Play("Wraith_Attack");
            return base.Attack(Gegner);
        }
    }

    public override void Die()
    {
        myAnimator.Play("Wraith_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Wraith_Idle");
        base.Finished();
    }
}
