using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem: Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("Golem_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        int rand = Random.Range(1, 6);
        if (rand == 6)
        {
            myAnimator.Play("Golem_Attack2");
            return base.Attack2(Gegner);
        }
        else
        {
            myAnimator.Play("Golem_Attack");
            return base.Attack(Gegner);
        }
    }

    public override void Die()
    {
        myAnimator.Play("Golem_Death");
        base.Die();
    }

    public override void Finished()
    {
        myAnimator.Play("Golem_Idle");
        base.Finished();
    }
}
