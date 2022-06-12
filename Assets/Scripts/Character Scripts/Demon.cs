using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Character
{
    public override void Awake()
    {
        Leben = 250;
        MaxHealth = Leben;
        Schaden = 20;
        Dodge = 20;
        Cost = 4;
        healthbar.SetHealth(Leben, MaxHealth);
    }

    public override void ReduceHealth(int damage)
    {
        if (Random.Range(1, 100) > Dodge)
        {
            myAnimator.Play("Demon_Hurt");
            base.ReduceHealth(damage);
        }
    }

    public override bool Attack(Character Gegner)
    {
        myAnimator.Play("Demon_Attack");
        return base.Attack(Gegner);
    }

    public override void Die()
    {
        myAnimator.Play("Demon_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Demon_Idle");
        base.Finished();
    }

    public override void DestroyMe()
    {
        base.DestroyMe();
    }
}
