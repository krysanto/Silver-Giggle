using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemGreen: Character
{
    public override void Awake()
    {
        Leben = 250;
        MaxHealth = Leben;
        Schaden = 20;
        Dodge = 0;
        Cost = 3;
        healthbar.SetHealth(Leben, MaxHealth);
    }

    public override void ReduceHealth(int damage)
    {
        if (Random.Range(1, 100) > Dodge)
        {
            myAnimator.Play("GolemGreen_Hurt");
            base.ReduceHealth(damage);
        }
    }

    public override bool Attack(Character Gegner)
    {
        int rand = Random.Range(1, 7);
        if (rand == 6)
        {
            myAnimator.Play("GolemGreen_Attack");
            return base.Attack2(Gegner);
        }
        else
        {
            myAnimator.Play("GolemGreen_Attack2");
            return base.Attack(Gegner);
        }
    }

    public override void Die()
    {
        myAnimator.Play("GolemGreen_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("GolemGreen_Idle");
        base.Finished();
    }
}
