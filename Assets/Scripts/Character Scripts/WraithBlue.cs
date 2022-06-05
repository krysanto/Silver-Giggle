using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithBlue : Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("WraithBlue_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        int rand = Random.Range(1, 6);
        if (rand == 6)
        {
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
