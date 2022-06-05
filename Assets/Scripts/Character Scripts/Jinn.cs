using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jinn : Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("Jinn_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        int rand = Random.Range(1, 6);
        if (rand == 6)
        {
            myAnimator.Play("Jinn_Attack2");
            return base.Attack2(Gegner);
        }
        else
        {
            myAnimator.Play("Jinn_Attack");
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