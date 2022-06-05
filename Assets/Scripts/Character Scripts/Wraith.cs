using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : Character
{
    public override void ReduceHealth(int damage)
    {
        myAnimator.Play("Wraith_Hurt");
        base.ReduceHealth(damage);
    }

    public override bool Attack(Character Gegner)
    {
        myAnimator.Play("Wraith_Attack");
        return base.Attack(Gegner);
    }

    public override bool Attack2(Character Gegner)
    {
        myAnimator.Play("Wraith_Attack2");
        return base.Attack2(Gegner);
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
