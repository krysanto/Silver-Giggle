using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("Knight_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        int rand = Random.Range(1, 6);
        if (rand == 6)
        {
            myAnimator.Play("Knight_Attack2");
            return base.Attack2(Gegner);
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
